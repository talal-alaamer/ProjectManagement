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
            btnCreate = new Button();
            btnCancel = new Button();
            groupBox1 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
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
            label4.Location = new Point(25, 31);
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
            txtProjectName.Location = new Point(16, 50);
            txtProjectName.Name = "txtProjectName";
            txtProjectName.Size = new Size(288, 29);
            txtProjectName.TabIndex = 11;
            // 
            // txtProjectManagerId
            // 
            txtProjectManagerId.BackColor = SystemColors.AppWorkspace;
            txtProjectManagerId.BorderStyle = BorderStyle.FixedSingle;
            txtProjectManagerId.Enabled = false;
            txtProjectManagerId.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtProjectManagerId.Location = new Point(16, 229);
            txtProjectManagerId.Name = "txtProjectManagerId";
            txtProjectManagerId.ReadOnly = true;
            txtProjectManagerId.Size = new Size(288, 29);
            txtProjectManagerId.TabIndex = 13;
            txtProjectManagerId.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(16, 19);
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
            label2.Location = new Point(16, 82);
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
            label5.Location = new Point(16, 205);
            label5.Name = "label5";
            label5.Size = new Size(138, 21);
            label5.TabIndex = 16;
            label5.Text = "Project Manger ID:";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(16, 106);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(288, 96);
            txtDescription.TabIndex = 17;
            txtDescription.Text = "";
            // 
            // btnCreate
            // 
            btnCreate.BackColor = Color.FromArgb(0, 0, 64);
            btnCreate.FlatStyle = FlatStyle.Popup;
            btnCreate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnCreate.ForeColor = Color.Transparent;
            btnCreate.Location = new Point(49, 273);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(114, 35);
            btnCreate.TabIndex = 18;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = false;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.DarkRed;
            btnCancel.FlatStyle = FlatStyle.Popup;
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(169, 273);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(114, 35);
            btnCancel.TabIndex = 19;
            btnCancel.Text = "Close";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnCancel);
            groupBox1.Controls.Add(txtProjectName);
            groupBox1.Controls.Add(btnCreate);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtDescription);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtProjectManagerId);
            groupBox1.Location = new Point(9, 127);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(317, 321);
            groupBox1.TabIndex = 20;
            groupBox1.TabStop = false;
            groupBox1.Text = "Project Info";
            // 
            // CreateProjectForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(338, 460);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(pictureBox1);
            Controls.Add(groupBox1);
            ForeColor = Color.Transparent;
            Name = "CreateProjectForm";
            Text = "frmCreateProject";
            Load += frmCreateProject_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
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
        private Button btnCreate;
        private Button btnCancel;
        private GroupBox groupBox1;
    }
}