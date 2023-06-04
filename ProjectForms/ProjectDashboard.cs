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
using ProjectManagementBusinessObjects;

namespace ProjectForms
{
    public partial class ProjectDashboard : Form
    {

        ProjectManagementBusinessObjects.ProjectManagementDBContext context;
        List<ProjectManagementBusinessObjects.Task> projectTasks;

        public ProjectDashboard(ProjectManagementBusinessObjects.ProjectManagementDBContext context)
        {
            InitializeComponent();
            this.projectTasks = new List<ProjectManagementBusinessObjects.Task>();
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

        //Function to retrieve the project and its tasks
        private void LoadProjectTasks()
        {
            try
            {
                //Retrieve all tasks related to the selected project from the database
                var allTasks = context.Tasks
                    .Include(t => t.Status)
                    .Where(t => t.ProjectId == Global.SelectedProject.ProjectId)
                    .ToList();

                //Filter the tasks based on the project's task status
                projectTasks = allTasks
                    .Where(t => t.Status != null)
                    .ToList();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        //Function to display the dashboard stats
        private void DisplayStatistics()
        {
            try
            {
                //Calculate and display the statistics based on the project tasks

                //Number of tasks completed
                int tasksCompleted = projectTasks.Count(t => t.Status.Status == "Completed");
                lblCompletedTasks.Text = tasksCompleted.ToString();

                //Number of tasks in progress (excluding completed and overdue tasks)
                int tasksInProgress = projectTasks.Count(t => t.Status.Status == "Ongoing");
                lblPendingTasks.Text = tasksInProgress.ToString();

                //Number of tasks overdue
                DateTime today = DateTime.Today;
                int overdueTasks = projectTasks.Count(t => t.Deadline < today && t.Status.Status != "Completed");
                lblOverdueTasks.Text = overdueTasks.ToString();

                //Number of tasks not started
                int tasksNotStarted = projectTasks.Count(t => t.Status.Status == "Not started");
                lblNotStarted.Text = tasksNotStarted.ToString();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            ProjectManager PM = new ProjectManager();
            PM.Show();
        }
    }
}
