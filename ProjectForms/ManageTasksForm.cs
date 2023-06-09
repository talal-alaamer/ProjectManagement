using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectManagement;
using ProjectForms;
using ProjectManagementBusinessObjects;

namespace ProjectForms
{
    public partial class ManageTasksForm : Form
    {

        private ProjectManagementBusinessObjects.ProjectManagementDBContext context;

        public ManageTasksForm()
        {
            InitializeComponent();
            context = new ProjectManagementBusinessObjects.ProjectManagementDBContext();

            // making the form open up in the center and not allowing the user to resize the forms
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

        }

        private void ManageTasksForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadTasks();
                ddlStatus.DataSource = context.TaskStatuses.ToList();
                ddlStatus.ValueMember = "TaskStatusId";
                ddlStatus.DisplayMember = "Status";
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void btnCreateTask_Click(object sender, EventArgs e)
        {
            try
            {
                //Validation for input fields
                int userid = Convert.ToInt32(context.Users.Where(x => x.Email == Global.SelectedUser.Email).FirstOrDefault()?.UserId);
                if (string.IsNullOrWhiteSpace(txtTaskName.Text) || string.IsNullOrWhiteSpace(txtDescription.Text))
                {
                    MessageBox.Show("Please Do not leave any of the fields empty.");
                    return;
                }
                else
                {

                    // Create a new task with the selected project member and other details
                    var newTask = new ProjectManagementBusinessObjects.Task
                    {
                        TaskName = txtTaskName.Text,
                        Description = txtDescription.Text,
                        AssignDate = DateTime.Now,
                        Deadline = dtpDeadline.Value,
                        StatusId = (int)ddlStatus.SelectedValue,
                        ProjectId = Global.SelectedProject.ProjectId,

                    };

                    //Audit the changes
                    var auditLog = new Audit
                    {
                        ChangeType = "Create",
                        TableName = "Tasks",
                        RecordId = newTask.TaskId,
                        CurrentValue = GetTaskValues(newTask),
                        OldValue = null,
                        UserId = userid,
                    };

                    //Save the new task to the database and audit the creation
                    context.Tasks.Add(newTask);
                    context.Set<Audit>().Add(auditLog);
                    context.SaveChanges();

                    //Show a success message to the user
                    MessageBox.Show("Task created successfully!");

                    //Clear the input fields
                    ClearFields();

                    //Refresh the DataGridView to show the updated task list
                    LoadTasks();


                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        //Function to refresh the data grid view
        private void LoadTasks()
        {
            try
            {
                //Load and display the tasks for the selected project
                var tasks = context.Tasks
                    .Where(t => t.ProjectId == Global.SelectedProject.ProjectId).Select(i => new
                    {
                        Task_ID = i.TaskId,
                        Task_Name = i.TaskName,
                        Description = i.Description,
                        Status = i.Status.Status,
                        AssignDate = DateTime.Now,
                        Deadline = i.Deadline,
                    })
                    .ToList();

                dgvTasks.DataSource = tasks;
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        //Clear the text fields
        private void ClearFields()
        {
            txtTaskName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            ddlStatus.SelectedIndex = 0;
            dtpDeadline.Value = DateTime.Now;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Close the form or dialog without making any changes
            DialogResult = DialogResult.Cancel;
            Close();
            ProjectManager PM = new ProjectManager();
            PM.Show();
        }

        private void btnManageStatus_Click(object sender, EventArgs e)
        {
            try
            {
                //Retrieve the selected task and validate it
                if (dgvTasks.SelectedCells.Count > 0)
                {
                    int selectedTaskid = Convert.ToInt32(dgvTasks.SelectedCells[0].OwningRow.Cells[0].Value);
                    ProjectManagementBusinessObjects.Task? selectedTask = context.Tasks.FirstOrDefault(p => p.TaskId == selectedTaskid);

                    if (selectedTask != null)
                    {
                        //Open the task edit form
                        EditTasksForm ET = new EditTasksForm(context, selectedTask);
                        ET.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Please select a project to continue.");
                    }
                }
                else
                {
                    MessageBox.Show("Please select a task.");
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //Retrieve the task and validate it
                if (dgvTasks.SelectedCells.Count > 0)
                {
                    int selectedTaskid = Convert.ToInt32(dgvTasks.SelectedCells[0].OwningRow.Cells[0].Value);
                    int userid = Convert.ToInt32(context.Users.Where(x => x.Email == Global.SelectedUser.Email).FirstOrDefault()?.UserId);
                    ProjectManagementBusinessObjects.Task? selectedTask = context.Tasks.FirstOrDefault(p => p.TaskId == selectedTaskid);

                    if (selectedTask != null)
                    {
                        //Display popup message
                        DialogResult result = MessageBox.Show("Are you sure you want to delete the selected task?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            //Remove the comments of the task
                            var selectedComment = context.Comments.FirstOrDefault(p => p.TaskId == selectedTaskid);
                            if (selectedComment != null)
                            {
                                context.Comments.RemoveRange(selectedComment);
                            }

                            //Audit the changes
                            var auditLog = new Audit
                            {
                                ChangeType = "Delete",
                                TableName = "Tasks",
                                RecordId = selectedTaskid,
                                OldValue = GetTaskValues(selectedTask),
                                UserId = userid,
                            };

                            //Delete the task and save changes to the database and audit the deletion
                            context.Tasks.Remove(selectedTask);
                            context.Set<ProjectManagementBusinessObjects.Audit>().Add(auditLog);
                            context.SaveChanges();
                            LoadTasks();
                        }
                        else
                        {
                            MessageBox.Show("No Task has been deleted.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select a task to delete.");
                    }
                }
                else
                {
                    MessageBox.Show("Please select a task.");
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

        }

        private void btnAddComments_Click(object sender, EventArgs e)
        {
            try
            {
                //Get the selected task and validate it
                if (dgvTasks.SelectedCells.Count > 0)
                {
                    int selectedTaskid = Convert.ToInt32(dgvTasks.SelectedCells[0].OwningRow.Cells[0].Value);
                    ProjectManagementBusinessObjects.Task? selectedTask = context.Tasks.FirstOrDefault(p => p.TaskId == selectedTaskid);

                    if (selectedTask != null)
                    {
                        //Open the comments form
                        CommentManagementForm CM = new CommentManagementForm(selectedTask);
                        this.Close();
                        CM.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Please select a task.");
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void HandleException(Exception ex)
        {
            //Handle any exceptions that may occur during the authentication process and log them
            MessageBox.Show($"An error occurred: {ex.Message}");

            int userId = Convert.ToInt32(context.Users.Where(x => x.Email == Global.SelectedUser.Email).FirstOrDefault()?.UserId);
            if (userId != 0)
            {
                LoggingService logger = new LoggingService(context);
                logger.LogException(ex, userId);
            }
            else
            {
                MessageBox.Show($"No user found: {ex.Message}");
            }
        }


        //Helper method to get the values of the task
        private string GetTaskValues(ProjectManagementBusinessObjects.Task task)
        {
            return $"TaskId: {task.TaskId}, TaskName: {task.TaskName}, Description: {task.Description}, Status: {task.StatusId}";
        }
    }
}
