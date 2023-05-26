using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using ProjectManagement;
using ProjectManagement.Model;

namespace ProjectForms
{
    public partial class ProjectDashboard : Form
    {

        ProjectManagementDBContext context;
        List<ProjectManagement.Model.Task> projectTasks;

        public ProjectDashboard(ProjectManagementDBContext context)
        {
            InitializeComponent();
            this.projectTasks = new List<ProjectManagement.Model.Task>();
            this.context = context;

            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void ProjectDashboard_Load(object sender, EventArgs e)
        {
            LoadProjectTasks();
            DisplayStatistics();

            txtProjectID.Text = Global.SelectedProject.ProjectId.ToString();
            txtProjectName.Text = Global.SelectedProject.ProjectName.ToString();


        }

        private void LoadProjectTasks()
        {
            try
            {
                // Retrieve the tasks related to the selected project from the database
                projectTasks = context.Tasks
                    .Where(t => t.ProjectId == Global.SelectedProject.ProjectId)
                    .ToList();
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the authentication process and log them
                MessageBox.Show($"An error occurred: {ex.Message}");
                int userid = Convert.ToInt32(context.Users.Where(x => x.Email == Global.SelectedUser.Email).FirstOrDefault()?.UserId);
                if (userid != 0)
                {
                    LoggingService logger = new LoggingService(context);
                    logger.LogException(ex, userid);
                }
                else
                {
                    MessageBox.Show($"No user found: {ex.Message}");
                }



            }
        }


        private void DisplayStatistics()
        {
            try
            {
                // Calculate and display the statistics based on the project tasks

                // Number of tasks pending vs completed
                //int tasksCompleted = projectTasks.Count(t => t.Status == "Completed");
                //int tasksPending = projectTasks.Count(t => t.Status == "In-Progress");

                //lblCompletedTasks.Text = tasksCompleted.ToString();
                //lblPendingTasks.Text = tasksPending.ToString();

                // Number of overdue tasks
                DateTime today = DateTime.Today;
                //int overdueTasks = projectTasks.Count(t => t.Deadline < today && t.Status != "Completed");

                //lblOverdueTasks.Text = overdueTasks.ToString();


            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the authentication process and log them
                MessageBox.Show($"An error occurred: {ex.Message}");
                int userid = Convert.ToInt32(context.Users.Where(x => x.Email == Global.SelectedUser.Email).FirstOrDefault()?.UserId);
                if (userid != 0)
                {
                    LoggingService logger = new LoggingService(context);
                    logger.LogException(ex, userid);
                }
                else
                {
                    MessageBox.Show($"No user found: {ex.Message}");
                }



            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            ProjectManager PM = new ProjectManager();
            PM.Show();
        }
    }
}
