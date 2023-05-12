using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectManagement;
using ProjectManagement.Model;

namespace ProjectForms
{
    public partial class ManageTasksForm : Form
    {
        private Project selectedProject;
        private ProjectManagementDBContext context;
        public ManageTasksForm(Project selectedProject)
        {
            InitializeComponent();
            this.selectedProject = selectedProject;
            context = new ProjectManagementDBContext();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void ManageTasksForm_Load(object sender, EventArgs e)
        {
            LoadTasks();
            ddlStatus.Items.Add("In-Progress");
            ddlStatus.Items.Add("Complete");
        }

        private void btnCreateTask_Click(object sender, EventArgs e)
        {



            // Create a new task with the selected project member and other details
            var newTask = new ProjectManagement.Model.Task
            {
                TaskName = txtTaskName.Text,
                Description = txtDescription.Text,
                Status = ddlStatus.Text,
                AssignDate = DateTime.Now,
                Deadline = dtpDeadline.Value,
                ProjectId = selectedProject.ProjectId,

            };

            // Save the new task to the database
            context.Tasks.Add(newTask);
            context.SaveChanges();

            // Show a success message to the user
            MessageBox.Show("Task created successfully!");

            // Clear the input fields
            ClearFields();

            // Refresh the DataGridView to show the updated task list
            LoadTasks();
        }



        private void LoadTasks()
        {
            // Load and display the tasks for the selected project
            var tasks = context.Tasks
                .Where(t => t.ProjectId == selectedProject.ProjectId).Select(i => new
                {
                    Task_Name = i.TaskName,
                    Description = i.Description,
                    Status = i.Status,
                    AssignDate = DateTime.Now,
                    Deadline = i.Deadline,
                    ProjectId = selectedProject.ProjectId,


                })
                .ToList();

            dgvTasks.DataSource = tasks;
        }
        private void ClearFields()
        {
            txtTaskName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            ddlStatus.SelectedIndex = -1;
            dtpDeadline.Value = DateTime.Now;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Close the form or dialog without making any changes
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
