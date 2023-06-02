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
    public partial class EditCommentForm : Form
    {
        Comment comment;
        ProjectManagementDBContext context;
        public EditCommentForm(Comment Comment, ProjectManagementDBContext context)
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
            if (string.IsNullOrWhiteSpace(txtComment.Text))
            {
                MessageBox.Show("Please Do not leave comment text field empty");
                return;
            }

            var oldvalue = GetCommentValues(comment);
            int userid = Convert.ToInt32(context.Users.Where(x => x.Email == Global.SelectedUser.Email).FirstOrDefault()?.UserId);

            comment.CommentText = txtComment.Text;
            comment.CommentTimestamp = BitConverter.GetBytes(DateTime.Now.Ticks);

            var auditLog = new Audit
            {
                ChangeType = "Edit",
                TableName = "Comment",
                RecordId = comment.CommentId,
                CurrentValue = GetCommentValues(comment),
                OldValue = oldvalue,
                UserId = userid,
            };

            context.Set<ProjectManagement.Model.Audit>().Add(auditLog);
            context.SaveChanges();

            MessageBox.Show("Success!");
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private string GetCommentValues(Comment comment)
        {
            return $"CommentId: {comment.CommentId}, TaskId: {comment.TaskId}, Text: {comment.CommentText}";
        }
    }
}
