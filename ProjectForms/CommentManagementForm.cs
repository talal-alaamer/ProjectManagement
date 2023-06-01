﻿using ProjectManagementBusinessObjects;
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
        private ProjectManagementBusinessObjects.Task selectedTask;

        public CommentManagementForm(ProjectManagementBusinessObjects.Task task)
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
            try
            {
                if (string.IsNullOrWhiteSpace(txtComment.Text))
                {
                    MessageBox.Show("Please enter a comment.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                byte[] currentDateBytes = BitConverter.GetBytes(DateTime.Now.Ticks);
                Comment newComment = new Comment
                {
                    CommentText = txtComment.Text,
                    CommentTimestamp = currentDateBytes,
                    UserId = Convert.ToInt32(context.Users.Where(x => x.Email == Global.SelectedUser.Email).FirstOrDefault()?.UserId),
                    TaskId = selectedTask.TaskId
                };

                context.Comments.Add(newComment);
                context.SaveChanges();

                LoadComments();
                txtComment.Clear();

            }
            catch(Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                int id = context.Users.Where(x => x.Email == Global.SelectedUser.Email).FirstOrDefault().UserId;
                LoggingService log = new LoggingService(context);
                log.LogException(ex, id);
            }
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            try
            {
                int commentId = Convert.ToInt32(dgvComments.SelectedCells[0].OwningRow.Cells[0].Value);
                Comment comment = context.Comments.Find(commentId);


                if (comment != null)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this comment?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
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
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                int id = context.Users.Where(x => x.Email == Global.SelectedUser.Email).FirstOrDefault().UserId;
                LoggingService log = new LoggingService(context);
                log.LogException(ex, id);
            }
           




        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                int id = context.Users.Where(x => x.Email == Global.SelectedUser.Email).FirstOrDefault().UserId;
                LoggingService log = new LoggingService(context);
                log.LogException(ex, id);
            }
           

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ManageTasksForm manageForm = new ManageTasksForm();
            this.Close();
            manageForm.Show();
        }


    }
}
