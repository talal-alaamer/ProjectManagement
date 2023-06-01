using ProjectManagementBusinessObjects;
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
        private ProjectManagementBusinessObjects.Task selectedTask;


        public EditTasksForm(ProjectManagementDBContext context, ProjectManagementBusinessObjects.Task Tasks)
        {
            this.selectedTask = Tasks;
            this.context = context;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void EditTasksForm_Load(object sender, EventArgs e)
        {
            txtTaskName.Text = selectedTask.TaskName;
            txtDescription.Text = selectedTask.Description;
            ddlStatus.DataSource = context.TaskStatuses.ToList();
            ddlStatus.ValueMember = "TaskStatusId";
            ddlStatus.DisplayMember = "Status";
            dtpAssignDate.Value = Convert.ToDateTime(selectedTask.AssignDate);
            dtpDeadline.Value = selectedTask.Deadline ?? DateTime.MinValue;
            ddlStatus.SelectedItem = selectedTask.Status;


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTaskName.Text) || string.IsNullOrWhiteSpace(txtDescription.Text) || ddlStatus.SelectedValue == null)
                {
                    MessageBox.Show("Please Do not leave the project name and description empty.");
                    return;
                }
                selectedTask.TaskName = txtTaskName.Text;
                selectedTask.Description = txtDescription.Text;
                selectedTask.StatusId = (int)ddlStatus.SelectedValue;
                selectedTask.AssignDate = dtpAssignDate.Value;
                selectedTask.Deadline = dtpDeadline.Value;
                context.SaveChanges();

                MessageBox.Show("Success!");
                ManageTasksForm MN = new ManageTasksForm();
                this.Close();
                MN.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                int id = context.Users.Where(x => x.Email == Global.SelectedUser.Email).FirstOrDefault().UserId;
                LoggingService log = new LoggingService(context);
                log.LogException(ex, id);
            }
           

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ManageTasksForm MN = new ManageTasksForm();
            this.Close();
            MN.Show();
        }
    }
}
