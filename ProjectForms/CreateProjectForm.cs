using ProjectForms;
using ProjectManagementBusinessObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectForms
{
    public partial class CreateProjectForm : Form
    {
        ProjectManagementBusinessObjects.ProjectManagementDBContext context;

        public CreateProjectForm()
        {
            InitializeComponent();
            context = new ProjectManagementBusinessObjects.ProjectManagementDBContext();


            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                //Retrieve the user id and v
                int userid = Convert.ToInt32(context.Users.Where(x => x.Email == Global.SelectedUser.Email).FirstOrDefault()?.UserId);
                if (string.IsNullOrWhiteSpace(txtProjectName.Text) || string.IsNullOrWhiteSpace(txtDescription.Text))
                {
                    MessageBox.Show("Please enter a project name and description.");
                    return;
                }

                //Create a new project
                Project project = new Project
                {
                    ProjectName = txtProjectName.Text.Trim(),
                    Description = txtDescription.Text.Trim(),
                    ProjectManagerId = context.Users.Where(x => x.Email == Global.SelectedUser.Email).FirstOrDefault().UserId
                };

                //Audit the changes
                var auditLog = new Audit
                {
                    ChangeType = "Create",
                    TableName = "Project",
                    RecordId = project.ProjectId,
                    CurrentValue = GetProjectValues(project),
                    OldValue = null,
                    UserId = userid,
                };

                //Save the changes to the database
                context.Set<ProjectManagementBusinessObjects.Audit>().Add(auditLog);
                context.Projects.Add(project);
                context.SaveChanges();

                //Display a success message and hide the form
                if (MessageBox.Show("Project created successfully!", "Success", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    this.Close();
                    ProjectManager PM = new ProjectManager();
                    PM.Show();
                }


            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        //Add the manager email to the textbox
        private void frmCreateProject_Load(object sender, EventArgs e)
        {
            txtProjectManagerId.Text = context.Users.Where(x => x.Email == Global.SelectedUser.Email).FirstOrDefault()?.UserId.ToString();
        }

        //Hide the form and go back
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            ProjectManager PM = new ProjectManager();
            PM.Show();

        }

        private void HandleException(Exception ex)
        {
            // Handle any exceptions that may occur during the authentication process and log them
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

        //method to get the details of a project
        private string GetProjectValues(Project project)
        {
            return $"ProjectId: {project.ProjectId}, ProjectName: {project.ProjectName}, Description: {project.Description}";
        }
    }
}
