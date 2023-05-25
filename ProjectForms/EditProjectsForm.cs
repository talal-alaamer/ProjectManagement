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
    public partial class EditProjectsForm : Form
    {
        private ProjectManagementDBContext context;



        public EditProjectsForm(ProjectManagementDBContext context)
        {
            InitializeComponent();
            this.context = context;


            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;


        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProjectName.Text) || string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Please Do not leave the project name and description empty.");
                return;
            }
            // Update the project details and members in the database\

            Global.SelectedProject.ProjectName = txtProjectName.Text;
            Global.SelectedProject.Description = txtDescription.Text;
            context.SaveChanges();

            this.DialogResult = DialogResult.OK;
            this.Close();

        }




        private void ManageProjectsForm_Load(object sender, EventArgs e)
        {
            // Display the project details and members in the text boxes and DataGridView
            txtProjectName.Text = Global.SelectedProject.ProjectName;
            txtDescription.Text = Global.SelectedProject.Description;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
