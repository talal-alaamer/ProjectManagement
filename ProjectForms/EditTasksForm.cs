using ProjectManagement.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectForms
{
    public partial class EditTasksForm : Form
    {
        private ProjectManagementDBContext context;
        private ProjectManagement.Model.Task selectedTask;


        public EditTasksForm(ProjectManagementDBContext context, ProjectManagement.Model.Task Tasks)
        {
            this.selectedTask = Tasks;
            this.context = context;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void EditTasksForm_Load(object sender, EventArgs e)
        {
            //populating the form contents with the values of the selected task
            txtTaskName.Text = selectedTask.TaskName;
            txtDescription.Text = selectedTask.Description;
            ddlStatus.DataSource = context.TaskStatuses.ToList();
            ddlStatus.ValueMember = "TaskStatusId";
            ddlStatus.DisplayMember = "Status";
            dtpAssignDate.Value = selectedTask.AssignDate;
            dtpDeadline.Value = selectedTask.Deadline ?? DateTime.MinValue;
            ddlStatus.SelectedItem = selectedTask.Status;


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTaskName.Text) || string.IsNullOrWhiteSpace(txtDescription.Text) || ddlStatus.SelectedValue == null)
            {
                MessageBox.Show("Please Do not leave the project name and description empty.");
                return;
            }
            // saving the new varibles to the task object and auditing the changes and adding them to the audit table
            int userid = Convert.ToInt32(context.Users.Where(x => x.Email == Global.SelectedUser.Email).FirstOrDefault()?.UserId);
            var oldvalue = GetTaskValues(selectedTask);
            selectedTask.TaskName = txtTaskName.Text;
            selectedTask.Description = txtDescription.Text;
            selectedTask.StatusId = (int)ddlStatus.SelectedValue;
            selectedTask.AssignDate = dtpAssignDate.Value;
            selectedTask.Deadline = dtpDeadline.Value;
            var auditLog = new Audit
            {
                ChangeType = "Edit",
                TableName = "Tasks",
                RecordId = selectedTask.TaskId,
                CurrentValue = GetTaskValues(selectedTask),
                OldValue = oldvalue,
                UserId = userid,
            };
            context.Set<ProjectManagement.Model.Audit>().Add(auditLog);
            context.SaveChanges();

            MessageBox.Show("Success!");
            ManageTasksForm MN = new ManageTasksForm();
            this.Close();
            MN.Show();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // closing this form and oppening ManageTasks form
            ManageTasksForm MN = new ManageTasksForm();
            this.Close();
            MN.Show();
        }
        // Helper method to get the values of the task
        private string GetTaskValues(ProjectManagement.Model.Task task)
        {
            return $"TaskId: {task.TaskId}, TaskName: {task.TaskName}, Description: {task.Description}, Status: {task.StatusId}";
        }
    }
}
