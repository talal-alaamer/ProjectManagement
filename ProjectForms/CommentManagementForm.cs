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
    public partial class CommentManagementForm : Form
    {
        private ProjectManagementBusinessObjects.ProjectManagementDBContext context;
        private ProjectManagementBusinessObjects.Task selectedTask;

        public CommentManagementForm(ProjectManagementBusinessObjects.Task task)
        {
            InitializeComponent();
            context = new ProjectManagementBusinessObjects.ProjectManagementDBContext();
            selectedTask = task;

            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            LoadComments();
        }

        private void CommentManagementForm_Load(object sender, EventArgs e)
        {
            LoadComments();
        }

        //Function to load and populate the data grid view
        private void LoadComments()
        {
            var comments = context.Comments
                .Where(c => c.TaskId == selectedTask.TaskId).Select(i => new
                {
                    Comment_ID = i.CommentId,
                    Comment_Text = i.CommentText,
                    UserID = i.UserId,
                    Task_ID = i.TaskId,
                }).ToList();

            dgvComments.DataSource = comments;
        }

        private void btnAddComment_Click(object sender, EventArgs e)
        {
            try
            {

                //Retrieve the user id and validate it
                int userid = Convert.ToInt32(context.Users.Where(x => x.Email == Global.SelectedUser.Email).FirstOrDefault()?.UserId);
                if (string.IsNullOrWhiteSpace(txtComment.Text))
                {
                    MessageBox.Show("Please enter a comment.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //Create a new comment
                Comment newComment = new Comment
                {
                    CommentText = txtComment.Text,

                    UserId = Convert.ToInt32(context.Users.Where(x => x.Email == Global.SelectedUser.Email).FirstOrDefault()?.UserId),
                    TaskId = selectedTask.TaskId
                };

                //Audit the changes
                var auditLog = new Audit
                {
                    ChangeType = "Create",
                    TableName = "Comment",
                    RecordId = newComment.CommentId,
                    CurrentValue = GetCommentValues(newComment),
                    OldValue = null,
                    UserId = userid,
                };

                //Save the changes to the database
                context.Set<ProjectManagementBusinessObjects.Audit>().Add(auditLog);
                context.Comments.Add(newComment);
                context.SaveChanges();

                //Display a success message and reload the data grid view and clear the fields
                MessageBox.Show("Comment added successfully!", "Success", MessageBoxButtons.OK);

                LoadComments();
                txtComment.Clear();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //Validate the user's selection
                if (dgvComments.SelectedCells.Count > 0)
                {
                    //Retrieve the comment and validate it
                    int userid = Convert.ToInt32(context.Users.Where(x => x.Email == Global.SelectedUser.Email).FirstOrDefault()?.UserId);
                    int commentId = Convert.ToInt32(dgvComments.SelectedCells[0].OwningRow.Cells[0].Value);
                    Comment comment = context.Comments.Find(commentId);
                    if (comment != null)
                    {
                        //Show a confirm popup
                        DialogResult result = MessageBox.Show("Are you sure you want to delete this comment?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            //Audit the changes
                            var auditLog = new Audit
                            {
                                ChangeType = "Delete",
                                TableName = "Comment",
                                RecordId = commentId,
                                OldValue = GetCommentValues(comment),
                                UserId = userid,
                            };

                            //Delete the comment and save the changes
                            context.Set<ProjectManagementBusinessObjects.Audit>().Add(auditLog);
                            context.Comments.Remove(comment);
                            context.SaveChanges();
                            
                            //Refresh the data grid view and show a success message
                            LoadComments();
                            MessageBox.Show("Comment deleted successfully.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Unable to find the selected comment.");
                    }
                }
                else
                {
                    MessageBox.Show("Please select a comment.");
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                //Validate the user's selection
                if (dgvComments.SelectedCells.Count > 0)
                {
                    //Retrieve the comment and validate it
                    int commentId = Convert.ToInt32(dgvComments.SelectedCells[0].OwningRow.Cells[0].Value);
                    Comment comment = context.Comments.Find(commentId);

                    if (comment != null)
                    {
                        //Show the edit form
                        EditCommentForm editForm = new EditCommentForm(comment, context);
                        DialogResult result = editForm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Unable to find the selected comment.");
                    }
                }
                else
                {
                    MessageBox.Show("Please select a comment.");
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        //Function to go back to the previous form
        private void btnClose_Click(object sender, EventArgs e)
        {
            ManageTasksForm manageForm = new ManageTasksForm();
            this.Close();
            manageForm.Show();
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
