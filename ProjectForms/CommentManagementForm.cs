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
using System.Xml.Linq;

namespace ProjectForms
{
    public partial class CommentManagementForm : Form
    {
        private ProjectManagementDBContext context;
        private ProjectManagement.Model.Task selectedTask;

        public CommentManagementForm(ProjectManagement.Model.Task task)
        {
            InitializeComponent();
            context = new ProjectManagementDBContext();
            selectedTask = task;

            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            LoadComments();
        }

        private void CommentManagementForm_Load(object sender, EventArgs e)
        {
            LoadComments();
        }
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


            int userid = Convert.ToInt32(context.Users.Where(x => x.Email == Global.SelectedUser.Email).FirstOrDefault()?.UserId);
            if (string.IsNullOrWhiteSpace(txtComment.Text))
            {
                MessageBox.Show("Please enter a comment.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            Comment newComment = new Comment
            {
                CommentText = txtComment.Text,

                UserId = Convert.ToInt32(context.Users.Where(x => x.Email == Global.SelectedUser.Email).FirstOrDefault()?.UserId),
                TaskId = selectedTask.TaskId
            };

            var auditLog = new Audit
            {
                ChangeType = "Create",
                TableName = "Comment",
                RecordId = newComment.CommentId,
                CurrentValue = GetCommentValues(newComment),
                OldValue = null,
                UserId = userid,
            };

            context.Set<ProjectManagement.Model.Audit>().Add(auditLog);
            context.Comments.Add(newComment);
            context.SaveChanges();

            MessageBox.Show("Comment added successfully!", "Success", MessageBoxButtons.OK);

            LoadComments();
            txtComment.Clear();
        
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (dgvComments.SelectedCells.Count > 0)
            {
                int userid = Convert.ToInt32(context.Users.Where(x => x.Email == Global.SelectedUser.Email).FirstOrDefault()?.UserId);
                int commentId = Convert.ToInt32(dgvComments.SelectedCells[0].OwningRow.Cells[0].Value);
                Comment comment = context.Comments.Find(commentId);
                if (comment != null)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this comment?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        var auditLog = new Audit
                        {
                            ChangeType = "Delete",
                            TableName = "Comment",
                            RecordId = commentId,
                            OldValue = GetCommentValues(comment),
                            UserId = userid,
                        };
                       
                        context.Set<ProjectManagement.Model.Audit>().Add(auditLog);
                        context.Comments.Remove(comment);
                        context.SaveChanges();
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

        private void btnEdit_Click(object sender, EventArgs e)
        {

            if (dgvComments.SelectedCells.Count > 0)
            {
                int commentId = Convert.ToInt32(dgvComments.SelectedCells[0].OwningRow.Cells[0].Value);
                Comment comment = context.Comments.Find(commentId);

                if (comment != null)
                {
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            ManageTasksForm manageForm = new ManageTasksForm();
            this.Close();
            manageForm.Show();
        }

        private string GetCommentValues(Comment comment)
        {
            return $"CommentId: {comment.CommentId}, TaskId: {comment.TaskId}, Text: {comment.CommentText}";
        }

    }
}
