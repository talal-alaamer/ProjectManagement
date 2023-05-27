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
            dgvComments = new DataGridView();
            btnAddComment = new Button();
            btnDelete = new Button();
            btnEdit = new Button();
            txtComment = new RichTextBox();
            pictureBox1 = new PictureBox();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            groupBox1 = new GroupBox();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvComments).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvComments
            // 
            dgvComments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvComments.Location = new Point(6, 160);
            dgvComments.Name = "dgvComments";
            dgvComments.RowTemplate.Height = 25;
            dgvComments.Size = new Size(368, 150);
            dgvComments.TabIndex = 0;
            // 
            // btnAddComment
            // 
            btnAddComment.BackColor = Color.FromArgb(0, 0, 64);
            btnAddComment.FlatStyle = FlatStyle.Flat;
            btnAddComment.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddComment.ForeColor = Color.White;
            btnAddComment.Location = new Point(10, 469);
            btnAddComment.Name = "btnAddComment";
            btnAddComment.Size = new Size(118, 36);
            btnAddComment.TabIndex = 1;
            btnAddComment.Text = "Add and close";
            btnAddComment.UseVisualStyleBackColor = false;
            btnAddComment.Click += btnAddComment_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.DarkRed;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(276, 469);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(118, 36);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.White;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnEdit.Location = new Point(143, 469);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(118, 36);
            btnEdit.TabIndex = 4;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // txtComment
            // 
            txtComment.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtComment.Location = new Point(6, 42);
            txtComment.Name = "txtComment";
            txtComment.Size = new Size(368, 112);
            txtComment.TabIndex = 5;
            txtComment.Text = "";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(0, 0, 64);
            pictureBox1.Location = new Point(0, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(404, 118);
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(0, 0, 64);
            label4.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.Transparent;
            label4.Location = new Point(53, 35);
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
            label3.Location = new Point(289, 107);
            label3.Name = "label3";
            label3.Size = new Size(105, 15);
            label3.TabIndex = 16;
            label3.Text = "Manage comment";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(14, 146);
            label1.Name = "label1";
            label1.Size = new Size(112, 21);
            label1.TabIndex = 21;
            label1.Text = "Comment Text:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgvComments);
            groupBox1.Controls.Add(txtComment);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.Location = new Point(10, 128);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(384, 320);
            groupBox1.TabIndex = 22;
            groupBox1.TabStop = false;
            groupBox1.Text = "Comment Info";
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.DarkRed;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(276, 511);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(118, 36);
            btnClose.TabIndex = 23;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // CommentManagementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(404, 557);
            Controls.Add(btnClose);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(pictureBox1);
            Controls.Add(btnEdit);
            Controls.Add(btnDelete);
            Controls.Add(btnAddComment);
            Controls.Add(groupBox1);
            Name = "CommentManagementForm";
            Text = "CommentManagementForm";
            Load += CommentManagementForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvComments).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvComments;
        private Button btnAddComment;
        private Button btnDelete;
        private Button btnEdit;
        private RichTextBox txtComment;
        private PictureBox pictureBox1;
        private Label label4;
        private Label label3;
        private Label label1;
        private GroupBox groupBox1;
        private Button btnClose;
    }
}