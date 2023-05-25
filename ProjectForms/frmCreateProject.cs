using ProjectForms;
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

        public frmCreateProject()
        {
            InitializeComponent();
            context = new ProjectManagementDBContext();


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
                    ProjectManagerId = Global.SelectedUser.UserId
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
            txtProjectManagerId.Text = Global.SelectedUser.UserId.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();


        }
    }
}
