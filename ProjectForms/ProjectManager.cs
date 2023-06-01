using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;
using ProjectManagementBusinessObjects;
using ProjectForms;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace ProjectForms
{
    public partial class ProjectManager : Form
    {
        ProjectManagementDBContext context;

        public ProjectManager()
        {
            InitializeComponent();
            context = new ProjectManagementDBContext();

            // making the form open up in the center and not allowing the user to resize the forms
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void ProjectManager_Load(object sender, EventArgs e)
        {
            RefreshDataGridView();

        }

        private void RefreshDataGridView()
        {
            int userid = Convert.ToInt32(context.Users.Where(x => x.Email == Global.SelectedUser.Email).FirstOrDefault()?.UserId);
            var projects = context.Projects
    .Where(p => p.ProjectManagerId == userid || p.ProjectMembers.Any(pm => pm.UserId == userid))
    .Select(p => new
    {
        Project_ID = p.ProjectId,
        Project_Name = p.ProjectName,
        Description = p.Description,
        ManagerID = p.ProjectManagerId
    })
    .ToList();

            dgvProjects.DataSource = projects;
            if (txtFilter.Text != "")
            {
                dgvProjects.DataSource = context.Projects.Select(p => new
                {
                    Project_ID = p.ProjectId,
                    Project_Name = p.ProjectName,
                    Description = p.Description,
                    ManagerID = p.ProjectManagerId
                }).Where(x => x.Project_ID == Convert.ToInt32(txtFilter.Text)).ToList();
            }
        }


        private void btnRest_Click(object sender, EventArgs e)
        {
            txtFilter.Text = "";
            RefreshDataGridView();
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            var selecteduserID = context.Users.Where(x => x.Email == Global.SelectedUser.Email).FirstOrDefault()?.UserId.ToString();


            int selectedRow = dgvProjects.SelectedCells[0].RowIndex;
            DataGridViewCell fourthColumnCell = dgvProjects.Rows[selectedRow].Cells[3]; // 4th column index is 3

            // Access the value in the 4th column
            string managerID = fourthColumnCell.Value?.ToString();
            try
            {
                if (dgvProjects.SelectedCells.Count > 0)
                {
                    if (selecteduserID == managerID)
                    {
                        int selectedPid = Convert.ToInt32(dgvProjects.SelectedCells[0].OwningRow.Cells[0].Value);
                        Global.SelectedProject = context.Projects.FirstOrDefault(i => i.ProjectId == selectedPid);

                        if (Global.SelectedProject != null)
                        {
                            EditProjectsForm editProjectsForm = new EditProjectsForm(context);
                            this.Hide();
                            editProjectsForm.Show();
                        }
                        else
                        {
                            MessageBox.Show("Selected project not found.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("You are not authorized to edit the project.");
                    }
                }
                else
                {
                    MessageBox.Show("Please select a project.");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the authentication process and log them
                HandleException(ex);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }

        private void btnDeleteProject_Click(object sender, EventArgs e)
        {
            var selecteduserID = context.Users.Where(x => x.Email == Global.SelectedUser.Email).FirstOrDefault()?.UserId.ToString();


            int selectedRow = dgvProjects.SelectedCells[0].RowIndex;
            DataGridViewCell fourthColumnCell = dgvProjects.Rows[selectedRow].Cells[3]; // 4th column index is 3

            // Access the value in the 4th column
            string managerID = fourthColumnCell.Value?.ToString();

            try
            {

                if (dgvProjects.SelectedCells.Count > 0)
                {
                    if (selecteduserID == managerID)
                    {
                        int selectedPid = Convert.ToInt32(dgvProjects.SelectedCells[0].OwningRow.Cells[0].Value);
                        Global.SelectedProject = context.Projects.Include(p => p.Tasks).FirstOrDefault(i => i.ProjectId == selectedPid);

                        if (Global.SelectedProject != null)
                        {
                            DialogResult result = MessageBox.Show("Are you sure you want to delete the selected project?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                // Delete all associated tasks
                                context.Tasks.RemoveRange(Global.SelectedProject.Tasks);

                                // Delete the project
                                context.Projects.Remove(Global.SelectedProject);

                                // Save changes to the database
                                context.SaveChanges();

                                RefreshDataGridView();
                            }
                            else
                            {
                                MessageBox.Show("No Project has been deleted.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please select a project.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("You are not authorized to delete the project.");
                    }
                }
                else
                {
                    MessageBox.Show("Please select a project.");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the authentication process and log them
                HandleException(ex);
            }

        }









        private void btnAddMember_Click(object sender, EventArgs e)
        {

            var selecteduserID = context.Users.Where(x => x.Email == Global.SelectedUser.Email).FirstOrDefault()?.UserId.ToString();


            int selectedRow = dgvProjects.SelectedCells[0].RowIndex;
            DataGridViewCell fourthColumnCell = dgvProjects.Rows[selectedRow].Cells[3]; // 4th column index is 3

            // Access the value in the 4th column
            string managerID = fourthColumnCell.Value?.ToString();
            try
            {

                if (dgvProjects.SelectedCells.Count > 0)
                {

                    if (selecteduserID == managerID)
                    {
                        int selectedPid = Convert.ToInt32(dgvProjects.SelectedCells[0].OwningRow.Cells[0].Value);
                        Global.SelectedProject = context.Projects.FirstOrDefault(p => p.ProjectId == selectedPid);
                        if (Global.SelectedProject != null)
                        {
                            AddMembersForm addform = new AddMembersForm();
                            this.Hide();
                            addform.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("You are not authorized to add members to the project.");
                    }
                }
                else
                {
                    MessageBox.Show("Please select a project to delete.");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the authentication process and log them
                HandleException(ex);
            }
        }

        private void btnManageTasks_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProjects.SelectedCells.Count > 0)
                {
                    int selectedPid = Convert.ToInt32(dgvProjects.SelectedCells[0].OwningRow.Cells[0].Value);
                    Global.SelectedProject = context.Projects.FirstOrDefault(p => p.ProjectId == selectedPid);
                    if (Global.SelectedProject != null)
                    {
                        ManageTasksForm MngTask = new ManageTasksForm();
                        this.Hide();
                        MngTask.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Please select a project to delete.");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the authentication process and log them
                HandleException(ex);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProjects.SelectedCells.Count > 0)
                {
                    int selectedPid = Convert.ToInt32(dgvProjects.SelectedCells[0].OwningRow.Cells[0].Value);
                    Global.SelectedProject = context.Projects.FirstOrDefault(p => p.ProjectId == selectedPid);
                    if (Global.SelectedProject != null)
                    {
                        CreateProjectForm Addform = new CreateProjectForm();
                        this.Hide();
                        Addform.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Please select a project to delete.");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the authentication process and log them
                HandleException(ex);
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProjects.SelectedCells.Count > 0)
                {
                    int selectedPid = Convert.ToInt32(dgvProjects.SelectedCells[0].OwningRow.Cells[0].Value);
                    Global.SelectedProject = context.Projects.FirstOrDefault(p => p.ProjectId == selectedPid);
                    if (Global.SelectedProject != null)
                    {
                        ProjectDashboard Pd = new ProjectDashboard(context);
                        this.Hide();
                        Pd.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Please select a project to delete.");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the authentication process and log them
                HandleException(ex);
            }
        }

        private void dgvProjects_EditModeChanged(object sender, EventArgs e)
        {
            RefreshDataGridView();
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
    }
}
