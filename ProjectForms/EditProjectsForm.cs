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
    public partial class EditProjectsForm : Form
    {
        private ProjectManagementDBContext context;
        private Project selectedProject;
        private User currentUser;

        public EditProjectsForm(Project project, ProjectManagementDBContext context, User currentUser)
        {
            InitializeComponent();
            this.selectedProject = project;
            this.context = context;
            this.currentUser = currentUser;
            this.StartPosition = FormStartPosition.CenterScreen;


        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtProjectName.Text) || string.IsNullOrWhiteSpace(txtDescription.Text))
    {
                MessageBox.Show("Please Do not leave the project name and description empty.");
                return;
            }
            // Update the project details and members in the database
            selectedProject.ProjectName = txtProjectName.Text;
            selectedProject.Description = txtDescription.Text;
            context.SaveChanges();

            this.DialogResult = DialogResult.OK;
            this.Close();
            ProjectManager pr = new ProjectManager(currentUser);
            pr.Show();



           
            
        }




        private void ManageProjectsForm_Load(object sender, EventArgs e)
        {
            // Display the project details and members in the text boxes and DataGridView
            txtProjectName.Text = selectedProject.ProjectName;
            txtDescription.Text = selectedProject.Description;
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            ProjectManager projectManagementForm = new ProjectManager(currentUser);
            projectManagementForm.ShowDialog();
        }
    }
}
