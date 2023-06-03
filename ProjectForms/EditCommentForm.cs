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

        private void EditCommentForm_Load(object sender, EventArgs e)
        {
            txtComment.Text = comment.CommentText;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtComment.Text))
                {
                    MessageBox.Show("Please Do not leave comment text field empty");
                    return;
                }

                var oldvalue = GetCommentValues(comment);
                int userid = Convert.ToInt32(context.Users.Where(x => x.Email == Global.SelectedUser.Email).FirstOrDefault()?.UserId);

                comment.CommentText = txtComment.Text;

                var auditLog = new Audit
                {
                    ChangeType = "Edit",
                    TableName = "Comment",
                    RecordId = comment.CommentId,
                    CurrentValue = GetCommentValues(comment),
                    OldValue = oldvalue,
                    UserId = userid,
                };

                context.Set<ProjectManagementBusinessObjects.Audit>().Add(auditLog);
                context.SaveChanges();

                MessageBox.Show("Success!");
                this.Close();
            }
            catch (Exception ex) 
            { 
              HandleException(ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
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
