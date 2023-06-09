﻿using ProjectForms;
using ProjectManagementBusinessObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProjectForms
{
    public partial class EditProjectsForm : Form
    {
        private ProjectManagementBusinessObjects.ProjectManagementDBContext context;



        public EditProjectsForm(ProjectManagementBusinessObjects.ProjectManagementDBContext context)
        {
            InitializeComponent();
            this.context = context;


            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;


        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //Validation for empty fields
                if (string.IsNullOrWhiteSpace(txtProjectName.Text) || string.IsNullOrWhiteSpace(txtDescription.Text))
                {
                    MessageBox.Show("Please Do not leave the project name and description empty.");
                    return;
                }

                // Update the project details and members in the database and add the changes to the audit table
                var oldvalue = GetProjectValues(Global.SelectedProject);
                int userid = Convert.ToInt32(context.Users.Where(x => x.Email == Global.SelectedUser.Email).FirstOrDefault()?.UserId);
                Global.SelectedProject.ProjectName = txtProjectName.Text;
                Global.SelectedProject.Description = txtDescription.Text;
                var auditLog = new Audit
                {
                    ChangeType = "Edit",
                    TableName = "Tasks",
                    RecordId = Global.SelectedProject.ProjectId,
                    CurrentValue = GetProjectValues(Global.SelectedProject),
                    OldValue = oldvalue,
                    UserId = userid,
                };

                //Save the changes to the database and hide the form
                context.Set<ProjectManagementBusinessObjects.Audit>().Add(auditLog);
                context.SaveChanges();
                this.DialogResult = DialogResult.OK;
                this.Close();
                ProjectManager PM = new ProjectManager();
                PM.Show();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

        }

        private void ManageProjectsForm_Load(object sender, EventArgs e)
        {
            // Display the project details and members in the text boxes and DataGridView
            txtProjectName.Text = Global.SelectedProject.ProjectName;
            txtDescription.Text = Global.SelectedProject.Description;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Close the form
            this.Close();
            ProjectManager PM = new ProjectManager();
            PM.Show();
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

        //method to get the details of a project
        private string GetProjectValues(Project project)
        {
            return $"ProjectId: {project.ProjectId}, ProjectName: {project.ProjectName}, Description: {project.Description}";
        }
    }
}
