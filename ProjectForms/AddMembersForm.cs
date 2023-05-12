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

namespace ProjectForms
{
    public partial class AddMembersForm : Form
    {
        private ProjectManagementDBContext context;
        private Project selectedProject;
        public AddMembersForm(Project project)
        {
            InitializeComponent();
            context = new ProjectManagementDBContext();
            selectedProject = project;

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
            // Retrieve all users from the database
            var users = context.Users.ToList();

            // Bind the users to the ComboBox
            ddlMembers.DataSource = users;
            ddlMembers.DisplayMember = "UserName";
            ddlMembers.ValueMember = "UserId";
        }

        private void LoadProjectMembers()
        {
            // Retrieve the project members for the selected project from the database
            var projectMembers = context.ProjectMembers
                .Where(pm => pm.ProjectId == selectedProject.ProjectId)
                .Select(pm => new
                {
                    Member_ID = pm.ProjectMemberId,
                    Member_Name = pm.User.UserName // Display the user's full name as the member name
                })
                .ToList();

            // Bind the project members to the DataGridView
            dgvMembers.DataSource = projectMembers;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ddlMembers.SelectedItem == null)
            {
                MessageBox.Show("Please select a user.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the selected user from the drop-down list
            User selectedUser = (User)ddlMembers.SelectedItem;

            bool isMember = selectedProject.ProjectMembers.Any(pm => pm.UserId == selectedUser.UserId);
            if (isMember)
            {
                MessageBox.Show("Selected user is already a member of the project.");
                return;
            }

            // Create a new ProjectMember object and add it to the context
            ProjectMember projectMember = new ProjectMember
            {
                UserId = selectedUser.UserId,
                ProjectId = selectedProject.ProjectId
            };
            context.ProjectMembers.Add(projectMember);
            context.SaveChanges();

            // Refresh the DataGridView to display the updated list of project members
            LoadProjectMembers();
            MessageBox.Show("User added as a project member successfully.");



        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Close the form or dialog without making any changes
            DialogResult = DialogResult.Cancel;
            Close();
        }


    }
}
