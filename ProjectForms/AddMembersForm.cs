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
        ProjectManagementBusinessObjects.ProjectManagementDBContext context;

        public AddMembersForm()
        {
            InitializeComponent();
            context = new ProjectManagementBusinessObjects.ProjectManagementDBContext();


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
                int userid = Convert.ToInt32(context.Users.Where(x => x.Email == Global.SelectedUser.Email).FirstOrDefault()?.UserId);
                if (ddlMembers.SelectedItem == null)
                {
                    MessageBox.Show("Please select a user.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Get the selected user from the drop-down list
                User? selectedUser = ddlMembers.SelectedItem as User;

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
                var auditLog = new Audit
                {
                    ChangeType = "Create",
                    TableName = "ProjectMember",
                    RecordId = projectMember.ProjectMemberId,
                    CurrentValue = GetProjectMemberValues(projectMember),
                    OldValue = null,
                    UserId = userid,
                };
                context.Set<ProjectManagementBusinessObjects.Audit>().Add(auditLog);
                context.ProjectMembers.Add(projectMember);
                context.SaveChanges();

                // Refresh the DataGridView to display the updated list of project members
                LoadProjectMembers();
                MessageBox.Show("User added as a project member successfully.");
            }
            catch (Exception ex)
            {
                HandleException(ex);
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
            try
            {
                int memberId = Convert.ToInt32(dgvMembers.SelectedCells[0].OwningRow.Cells[0].Value);
                ProjectMember Member = context.ProjectMembers.Find(memberId);


                if (Member != null)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to remove this member?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        int userid = Convert.ToInt32(context.Users.Where(x => x.Email == Global.SelectedUser.Email).FirstOrDefault()?.UserId);
                        var auditLog = new Audit
                        {
                            ChangeType = "Delete",
                            TableName = "ProjectMember",
                            RecordId = memberId,
                            OldValue = GetProjectMemberValues(Member),
                            UserId = userid,
                        };
                        // Delete the project and save changes to the database and audit the deletion

                        context.Set<Audit>().Add(auditLog);
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
            catch (Exception ex)
            {
                HandleException(ex);
            }
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

        private string GetProjectMemberValues(ProjectMember projectMember)
        {
            return $"ProjectMemberId: {projectMember.ProjectMemberId}, UserId: {projectMember.UserId}, ProjectId: {projectMember.ProjectId}";
        }

    }
}
