using ProjectManagement;
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
using System.Xml.Linq;

namespace ProjectForms
{
    public partial class EditCommentForm : Form
    {
        Comment comment;
        ProjectManagementBusinessObjects.ProjectManagementDBContext context;
        public EditCommentForm(Comment Comment, ProjectManagementBusinessObjects.ProjectManagementDBContext context)
        {
            InitializeComponent();
            this.comment = Comment;
            this.context = context;

            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        //Populate the input field
        private void EditCommentForm_Load(object sender, EventArgs e)
        {
            txtComment.Text = comment.CommentText;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //Validation for empty comments
                if (string.IsNullOrWhiteSpace(txtComment.Text))
                {
                    MessageBox.Show("Please Do not leave comment text field empty");
                    return;
                }

                //Store the old value
                var oldvalue = GetCommentValues(comment);
                int userid = Convert.ToInt32(context.Users.Where(x => x.Email == Global.SelectedUser.Email).FirstOrDefault()?.UserId);

                //Update the comment
                comment.CommentText = txtComment.Text;

                //Audit the changes
                var auditLog = new Audit
                {
                    ChangeType = "Edit",
                    TableName = "Comment",
                    RecordId = comment.CommentId,
                    CurrentValue = GetCommentValues(comment),
                    OldValue = oldvalue,
                    UserId = userid,
                };

                //Save the changes to the database
                context.Set<ProjectManagementBusinessObjects.Audit>().Add(auditLog);
                context.SaveChanges();

                //Display a success message and hide the form
                MessageBox.Show("Success!");
                this.Close();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        //Close the form
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private string GetCommentValues(Comment comment)
        {
            return $"CommentId: {comment.CommentId}, TaskId: {comment.TaskId}, Text: {comment.CommentText}";
        }
    }
}
