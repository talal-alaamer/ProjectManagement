namespace ProjectForms
{
    partial class EditTasksForm
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
            txtTaskName = new TextBox();
            txtDescription = new RichTextBox();
            ddlStatus = new ComboBox();
            dtpDeadline = new DateTimePicker();
            btnSave = new Button();
            btnCancel = new Button();
            dtpAssignDate = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(0, 0, 64);
            pictureBox1.Location = new Point(-1, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(359, 118);
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(0, 0, 64);
            label4.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.Transparent;
            label4.Location = new Point(34, 35);
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
            label3.Location = new Point(258, 102);
            label3.Name = "label3";
            label3.Size = new Size(89, 15);
            label3.TabIndex = 15;
            label3.Text = "Edit Task details";
            // 
            // txtTaskName
            // 
            txtTaskName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtTaskName.Location = new Point(78, 160);
            txtTaskName.Name = "txtTaskName";
            txtTaskName.Size = new Size(210, 29);
            txtTaskName.TabIndex = 16;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(78, 204);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(210, 96);
            txtDescription.TabIndex = 25;
            txtDescription.Text = "";
            // 
            // ddlStatus
            // 
            ddlStatus.FormattingEnabled = true;
            ddlStatus.Location = new Point(78, 306);
            ddlStatus.Name = "ddlStatus";
            ddlStatus.Size = new Size(210, 23);
            ddlStatus.TabIndex = 27;
            ddlStatus.SelectedIndexChanged += ddlStatus_SelectedIndexChanged;
            // 
            // dtpDeadline
            // 
            dtpDeadline.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dtpDeadline.Location = new Point(78, 380);
            dtpDeadline.Name = "dtpDeadline";
            dtpDeadline.Size = new Size(210, 29);
            dtpDeadline.TabIndex = 28;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(0, 0, 64);
            btnSave.FlatStyle = FlatStyle.Popup;
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSave.ForeColor = Color.Transparent;
            btnSave.Location = new Point(70, 466);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(106, 33);
            btnSave.TabIndex = 29;
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
            btnCancel.Location = new Point(182, 466);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(106, 33);
            btnCancel.TabIndex = 30;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // dtpAssignDate
            // 
            dtpAssignDate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dtpAssignDate.Location = new Point(78, 345);
            dtpAssignDate.Name = "dtpAssignDate";
            dtpAssignDate.Size = new Size(210, 29);
            dtpAssignDate.TabIndex = 31;
            // 
            // EditTasksForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(359, 501);
            Controls.Add(dtpAssignDate);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(dtpDeadline);
            Controls.Add(ddlStatus);
            Controls.Add(txtDescription);
            Controls.Add(txtTaskName);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(pictureBox1);
            Name = "EditTasksForm";
            Text = "EditTasksForm";
            Load += EditTasksForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label4;
        private Label label3;
        private TextBox txtTaskName;
        private RichTextBox txtDescription;
        private ComboBox ddlStatus;
        private DateTimePicker dtpDeadline;
        private Button btnSave;
        private Button btnCancel;
        private DateTimePicker dtpAssignDate;
    }
}