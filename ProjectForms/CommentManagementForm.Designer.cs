namespace ProjectForms
{
    partial class CommentManagementForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            dgvComments = new DataGridView();
            label1 = new Label();
            groupBox1 = new GroupBox();
            txtComment = new RichTextBox();
            btnDelete = new Button();
            btnClose = new Button();
            btnEdit = new Button();
            btnAddComment = new Button();
            label4 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvComments).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(0, 0, 64);
            pictureBox1.Location = new Point(-2, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(488, 118);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // dgvComments
            // 
            dgvComments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvComments.Location = new Point(10, 168);
            dgvComments.Name = "dgvComments";
            dgvComments.RowTemplate.Height = 25;
            dgvComments.Size = new Size(438, 168);
            dgvComments.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(10, 36);
            label1.Name = "label1";
            label1.Size = new Size(112, 21);
            label1.TabIndex = 10;
            label1.Text = "Comment Text:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtComment);
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnClose);
            groupBox1.Controls.Add(btnEdit);
            groupBox1.Controls.Add(btnAddComment);
            groupBox1.Controls.Add(dgvComments);
            groupBox1.Location = new Point(11, 129);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(463, 389);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "Comment Info";
            // 
            // txtComment
            // 
            txtComment.Location = new Point(10, 69);
            txtComment.Name = "txtComment";
            txtComment.Size = new Size(438, 93);
            txtComment.TabIndex = 15;
            txtComment.Text = "";
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.DarkRed;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(153, 342);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(148, 34);
            btnDelete.TabIndex = 14;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnClose.ForeColor = Color.Black;
            btnClose.Location = new Point(307, 342);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(142, 34);
            btnClose.TabIndex = 13;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.White;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnEdit.ForeColor = Color.Black;
            btnEdit.Location = new Point(10, 342);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(137, 34);
            btnEdit.TabIndex = 12;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAddComment
            // 
            btnAddComment.BackColor = Color.FromArgb(0, 0, 64);
            btnAddComment.FlatStyle = FlatStyle.Flat;
            btnAddComment.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddComment.ForeColor = Color.White;
            btnAddComment.Location = new Point(306, 29);
            btnAddComment.Name = "btnAddComment";
            btnAddComment.Size = new Size(142, 34);
            btnAddComment.TabIndex = 11;
            btnAddComment.Text = "Add";
            btnAddComment.UseVisualStyleBackColor = false;
            btnAddComment.Click += btnAddComment_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(0, 0, 64);
            label4.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.Transparent;
            label4.Location = new Point(105, 36);
            label4.Name = "label4";
            label4.Size = new Size(301, 45);
            label4.TabIndex = 12;
            label4.Text = "Project Manegment";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ScrollBar;
            label3.ForeColor = Color.Black;
            label3.Location = new Point(363, 103);
            label3.Name = "label3";
            label3.Size = new Size(112, 15);
            label3.TabIndex = 13;
            label3.Text = "Manage Comments";
            // 
            // CommentManagementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(486, 525);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(pictureBox1);
            Controls.Add(groupBox1);
            Name = "CommentManagementForm";
            Text = "CommentManagementForm";
            Load += CommentManagementForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvComments).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private DataGridView dgvComments;
        private Label label1;
        private GroupBox groupBox1;
        private Button btnClose;
        private Button btnEdit;
        private Button btnAddComment;
        private Button btnDelete;
        private Label label4;
        private Label label3;
        private RichTextBox txtComment;
    }
}