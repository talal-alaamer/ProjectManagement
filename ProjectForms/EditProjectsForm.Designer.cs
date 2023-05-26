namespace ProjectForms
{
    partial class EditProjectsForm
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
            txtProjectName = new TextBox();
            pictureBox1 = new PictureBox();
            label4 = new Label();
            txtDescription = new RichTextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtProjectName
            // 
            txtProjectName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtProjectName.Location = new Point(12, 155);
            txtProjectName.Name = "txtProjectName";
            txtProjectName.Size = new Size(329, 29);
            txtProjectName.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(0, 0, 64);
            pictureBox1.Location = new Point(-1, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(359, 118);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(0, 0, 64);
            label4.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.Transparent;
            label4.Location = new Point(31, 28);
            label4.Name = "label4";
            label4.Size = new Size(301, 45);
            label4.TabIndex = 10;
            label4.Text = "Project Manegment";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(12, 239);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(329, 96);
            txtDescription.TabIndex = 11;
            txtDescription.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 131);
            label1.Name = "label1";
            label1.Size = new Size(134, 21);
            label1.TabIndex = 12;
            label1.Text = "Edit Project name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 215);
            label2.Name = "label2";
            label2.Size = new Size(172, 21);
            label2.TabIndex = 13;
            label2.Text = "Edit Project description:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ScrollBar;
            label3.ForeColor = Color.Black;
            label3.Location = new Point(242, 102);
            label3.Name = "label3";
            label3.Size = new Size(104, 15);
            label3.TabIndex = 14;
            label3.Text = "Edit Project details";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(0, 0, 64);
            btnSave.FlatStyle = FlatStyle.Popup;
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSave.ForeColor = Color.Transparent;
            btnSave.Location = new Point(78, 361);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(106, 33);
            btnSave.TabIndex = 15;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.DarkRed;
            btnCancel.FlatStyle = FlatStyle.Popup;
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(190, 361);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(106, 33);
            btnCancel.TabIndex = 16;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // EditProjectsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(358, 420);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtDescription);
            Controls.Add(label4);
            Controls.Add(pictureBox1);
            Controls.Add(txtProjectName);
            Name = "EditProjectsForm";
            Text = "ManageProjectsForm";
            Load += ManageProjectsForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtProjectName;
        private PictureBox pictureBox1;
        private Label label4;
        private RichTextBox txtDescription;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnSave;
        private Button btnCancel;
    }
}