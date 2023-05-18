using ProjectManagement.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class frmCreateProject : Form
    {
        ProjectManagementDBContext context;
        private User currentUser;
        public frmCreateProject(User currentUser)
        {
            InitializeComponent();
            context = new ProjectManagementDBContext();
            this.currentUser = currentUser;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProjectName.Text) || string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Please enter a project name and description.");
                return;
            }
            try
            {
                Project project = new Project
                {
                    ProjectName = txtProjectName.Text.Trim(),
                    Description = txtDescription.Text.Trim(),
                    ProjectManagerId = currentUser.UserId
                };

                context.Projects.Add(project);
                context.SaveChanges();

                if (MessageBox.Show("Project created successfully!", "Success", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving the project: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmCreateProject_Load(object sender, EventArgs e)
        {
            txtProjectManagerId.Text = currentUser.UserId.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();


        }
    }
}
