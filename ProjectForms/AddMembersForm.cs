using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectManagementBusinessObjects;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using ProjectManagement.Areas.Identity;
using ProjectManagement.Data;

namespace ProjectForms
{
    public partial class AddMembersForm : Form
    {
        private ProjectManagementDBContext context;

        public AddMembersForm()
        {
            InitializeComponent();
            context = new ProjectManagementDBContext();


            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

        }

        private void AddMembersForm_Load(object sender, EventArgs e)
        {
            LoadUsers();
            LoadProjectMembers();

        }
        private void LoadUsers()
        {

            var users = context.Users.ToList();
            ddlMembers.DataSource = users;
            ddlMembers.DisplayMember = "Email";
            ddlMembers.ValueMember = "UserId";

        }

        private void LoadProjectMembers()
        {
            // Retrieve the project members for the selected project from the database
            var projectMembers = context.ProjectMembers
                .Where(pm => pm.ProjectId == Global.SelectedProject.ProjectId)
                .Select(pm => new
                {
                    Member_ID = pm.ProjectMemberId,
                    Member_Email = pm.User.Email,
                    Project_ID = pm.ProjectId
                })
                .ToList();

            // Bind the project members to the DataGridView
            dgvMembers.DataSource = projectMembers;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlMembers.SelectedItem == null)
                {
                    MessageBox.Show("Please select a user.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Get the selected user from the drop-down list
                User selectedUser = ddlMembers.SelectedItem as User;

                bool isMember = context.ProjectMembers.Any(pm => pm.ProjectId == Global.SelectedProject.ProjectId && pm.UserId == selectedUser.UserId);
                if (isMember)
                {
                    MessageBox.Show("Selected user is already a member of the project.");
                    return;
                }

                // Create a new ProjectMember object and add it to the context
                ProjectMember projectMember = new ProjectMember
                {
                    UserId = selectedUser.UserId,
                    ProjectId = Global.SelectedProject.ProjectId
                };
                context.ProjectMembers.Add(projectMember);
                context.SaveChanges();

                // Refresh the DataGridView to display the updated list of project members
                LoadProjectMembers();
                MessageBox.Show("User added as a project member successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");

                int id = context.Users.Where(x=> x.Email == Global.SelectedUser.Email).FirstOrDefault().UserId;
                LoggingService log = new LoggingService(context);
                log.LogException(ex, id);
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {

           
            // Close the form or dialog without making any changes
            DialogResult = DialogResult.Cancel;
            Close();
            ProjectManager PM = new ProjectManager();
            PM.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int memberId = Convert.ToInt32(dgvMembers.SelectedCells[0].OwningRow.Cells[0].Value);
            ProjectMember Member = context.ProjectMembers.Find(memberId);


            if (Member != null)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this comment?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    context.ProjectMembers.Remove(Member);
                    context.SaveChanges();
                    LoadProjectMembers();
                    MessageBox.Show("Project Member deleted successfully.");
                }
            }
            else
            {
                MessageBox.Show("Unable to find the selected Project Member.");
            }
        }
    }
}