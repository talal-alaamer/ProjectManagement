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
        ProjectManagementDBContext Context;
        public EditCommentForm(Comment Comment, ProjectManagementDBContext context)
        {
            InitializeComponent();
            this.comment = Comment;
            this.Context = context;

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
                comment.CommentText = txtComment.Text;
                comment.CommentTimestamp = BitConverter.GetBytes(DateTime.Now.Ticks);
                Context.SaveChanges();
                MessageBox.Show("Success!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                int id = Context.Users.Where(x => x.Email == Global.SelectedUser.Email).FirstOrDefault().UserId;
                LoggingService log = new LoggingService(Context);
                log.LogException(ex, id);
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
    }
}
