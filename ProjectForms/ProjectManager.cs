using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectManagement.Model;
using ProjectForms;

namespace Test
{
    public partial class ProjectManager : Form
    {
        ProjectManagementDBContext context;
        User currentUser;
        public ProjectManager(User currentUser)
        {
            InitializeComponent();
            context = new ProjectManagementDBContext();
            this.currentUser = currentUser;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void ProjectManager_Load(object sender, EventArgs e)
        {

            RefreshDataGridView();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmCreateProject frmC = new frmCreateProject(currentUser);
            this.Hide();
            frmC.ShowDialog();
        }

        private void RefreshDataGridView()
        {
            dgvProjects.DataSource = context.Projects.Select(p => new
            {
                Project_ID = p.ProjectId,
                Project_Name = p.ProjectName,
                Description = p.Description,
                ManagerID = p.ProjectManagerId
            }).ToList();

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
            int selectedPid = Convert.ToInt32(dgvProjects.SelectedCells[0].OwningRow.Cells[0].Value);
            Project selectedProject = context.Projects.FirstOrDefault(i => i.ProjectId == selectedPid);

            if (selectedProject != null)
            {
                this.Hide();
                EditProjectsForm editProjectsForm = new EditProjectsForm(selectedProject, context, currentUser);
                editProjectsForm.Show();

            }
            else
            {
                MessageBox.Show("Selected project not found.");
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }

        private void btnDeleteProject_Click(object sender, EventArgs e)
        {
            if (dgvProjects.SelectedCells.Count > 0)
            {
                int selectedPid = Convert.ToInt32(dgvProjects.SelectedCells[0].OwningRow.Cells[0].Value);
                Project selectedProject = context.Projects.FirstOrDefault(p => p.ProjectId == selectedPid);

                if (selectedProject != null)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete the selected project?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        // Delete the project and save changes to the database
                        context.Projects.Remove(selectedProject);
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
                    MessageBox.Show("Please select a project to delete.");
                }
            }
        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            if (dgvProjects.SelectedCells.Count > 0)
            {
                int selectedPid = Convert.ToInt32(dgvProjects.SelectedCells[0].OwningRow.Cells[0].Value);
                Project selectedProject = context.Projects.FirstOrDefault(p => p.ProjectId == selectedPid);
                if (selectedProject != null)
                {
                    AddMembersForm addform = new AddMembersForm(selectedProject);

                    addform.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Please select a project to delete.");
            }
        }
    }
}