namespace ProjectForms
{
    partial class EditCommentForm
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
            txtComment = new RichTextBox();
            pictureBox1 = new PictureBox();
            label4 = new Label();
            label3 = new Label();
            groupBox1 = new GroupBox();
            label1 = new Label();
            btnClose = new Button();
            btnSave = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // txtComment
            // 
            txtComment.Location = new Point(7, 63);
            txtComment.Name = "txtComment";
            txtComment.Size = new Size(301, 109);
            txtComment.TabIndex = 0;
            txtComment.Text = "";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(0, 0, 64);
            pictureBox1.Location = new Point(-4, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(343, 118);
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(0, 0, 64);
            label4.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.Transparent;
            label4.Location = new Point(12, 34);
            label4.Name = "label4";
            label4.Size = new Size(301, 45);
            label4.TabIndex = 11;
            label4.Text = "Project Manegment";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ScrollBar;
            label3.ForeColor = Color.Black;
            label3.Location = new Point(205, 105);
            label3.Name = "label3";
            label3.Size = new Size(121, 15);
            label3.TabIndex = 15;
            label3.Text = "Edit Comment details";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnClose);
            groupBox1.Controls.Add(btnSave);
            groupBox1.Controls.Add(txtComment);
            groupBox1.Location = new Point(12, 136);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(314, 243);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            groupBox1.Text = "Comment Info";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(7, 39);
            label1.Name = "label1";
            label1.Size = new Size(112, 21);
            label1.TabIndex = 14;
            label1.Text = "Comment Text:";
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.DarkRed;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(174, 191);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(95, 34);
            btnClose.TabIndex = 13;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(0, 0, 64);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(51, 191);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(95, 34);
            btnSave.TabIndex = 12;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // EditCommentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(338, 391);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(pictureBox1);
            Controls.Add(groupBox1);
            Name = "EditCommentForm";
            Text = "EditCommentForm";
            Load += EditCommentForm_Load;
            Click += btnClose_Click;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox txtComment;
        private PictureBox pictureBox1;
        private Label label4;
        private Label label3;
        private GroupBox groupBox1;
        private Button btnClose;
        private Button btnSave;
        private Label label1;
    }
}