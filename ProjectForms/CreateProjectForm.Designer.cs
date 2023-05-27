namespace ProjectForms
{
    partial class CreateProjectForm
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
            label4 = new Label();
            label3 = new Label();
            txtProjectName = new TextBox();
            txtProjectManagerId = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label5 = new Label();
            txtDescription = new RichTextBox();
            button1 = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(0, 0, 64);
            pictureBox1.Location = new Point(-1, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(338, 118);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(0, 0, 64);
            label4.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.Transparent;
            label4.Location = new Point(12, 31);
            label4.Name = "label4";
            label4.Size = new Size(301, 45);
            label4.TabIndex = 9;
            label4.Text = "Project Manegment";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ScrollBar;
            label3.ForeColor = Color.Black;
            label3.Location = new Point(232, 102);
            label3.Name = "label3";
            label3.Size = new Size(81, 15);
            label3.TabIndex = 10;
            label3.Text = "Create Project";
            // 
            // txtProjectName
            // 
            txtProjectName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtProjectName.Location = new Point(12, 156);
            txtProjectName.Name = "txtProjectName";
            txtProjectName.Size = new Size(314, 29);
            txtProjectName.TabIndex = 11;
            // 
            // txtProjectManagerId
            // 
            txtProjectManagerId.BackColor = SystemColors.AppWorkspace;
            txtProjectManagerId.BorderStyle = BorderStyle.FixedSingle;
            txtProjectManagerId.Enabled = false;
            txtProjectManagerId.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtProjectManagerId.Location = new Point(12, 337);
            txtProjectManagerId.Name = "txtProjectManagerId";
            txtProjectManagerId.ReadOnly = true;
            txtProjectManagerId.Size = new Size(314, 29);
            txtProjectManagerId.TabIndex = 13;
            txtProjectManagerId.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(12, 132);
            label1.Name = "label1";
            label1.Size = new Size(107, 21);
            label1.TabIndex = 14;
            label1.Text = "Project Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(12, 188);
            label2.Name = "label2";
            label2.Size = new Size(92, 21);
            label2.TabIndex = 15;
            label2.Text = "Description:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(12, 313);
            label5.Name = "label5";
            label5.Size = new Size(138, 21);
            label5.TabIndex = 16;
            label5.Text = "Project Manger ID:";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(12, 214);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(314, 96);
            txtDescription.TabIndex = 17;
            txtDescription.Text = "";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(0, 0, 64);
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = Color.Transparent;
            button1.Location = new Point(61, 400);
            button1.Name = "button1";
            button1.Size = new Size(114, 35);
            button1.TabIndex = 18;
            button1.Text = "Create";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.DarkRed;
            btnCancel.FlatStyle = FlatStyle.Popup;
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(181, 400);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(114, 35);
            btnCancel.TabIndex = 19;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // CreateProjectForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(338, 460);
            Controls.Add(btnCancel);
            Controls.Add(button1);
            Controls.Add(txtDescription);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtProjectManagerId);
            Controls.Add(txtProjectName);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(pictureBox1);
            ForeColor = Color.Transparent;
            Name = "CreateProjectForm";
            Text = "frmCreateProject";
            Load += frmCreateProject_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label4;
        private Label label3;
        private TextBox txtProjectName;
        private TextBox txtProjectManagerId;
        private Label label1;
        private Label label2;
        private Label label5;
        private RichTextBox txtDescription;
        private Button button1;
        private Button btnCancel;
    }
}