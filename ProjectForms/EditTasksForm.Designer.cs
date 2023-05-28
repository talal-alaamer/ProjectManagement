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
            groupBox1 = new GroupBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label2 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(0, 0, 64);
            pictureBox1.Location = new Point(-1, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(364, 118);
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(0, 0, 64);
            label4.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.Transparent;
            label4.Location = new Point(46, 35);
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
            label3.Location = new Point(262, 102);
            label3.Name = "label3";
            label3.Size = new Size(89, 15);
            label3.TabIndex = 15;
            label3.Text = "Edit Task details";
            // 
            // txtTaskName
            // 
            txtTaskName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtTaskName.Location = new Point(117, 142);
            txtTaskName.Name = "txtTaskName";
            txtTaskName.Size = new Size(218, 29);
            txtTaskName.TabIndex = 16;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(117, 177);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(218, 96);
            txtDescription.TabIndex = 25;
            txtDescription.Text = "";
            // 
            // ddlStatus
            // 
            ddlStatus.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ddlStatus.FormattingEnabled = true;
            ddlStatus.Location = new Point(117, 279);
            ddlStatus.Name = "ddlStatus";
            ddlStatus.Size = new Size(218, 29);
            ddlStatus.TabIndex = 27;
            // 
            // dtpDeadline
            // 
            dtpDeadline.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dtpDeadline.Location = new Point(117, 349);
            dtpDeadline.Name = "dtpDeadline";
            dtpDeadline.Size = new Size(218, 29);
            dtpDeadline.TabIndex = 28;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(0, 0, 64);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(105, 271);
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
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(217, 271);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(106, 33);
            btnCancel.TabIndex = 30;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // dtpAssignDate
            // 
            dtpAssignDate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dtpAssignDate.Location = new Point(117, 314);
            dtpAssignDate.Name = "dtpAssignDate";
            dtpAssignDate.Size = new Size(218, 29);
            dtpAssignDate.TabIndex = 31;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(btnCancel);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(btnSave);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 123);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(335, 321);
            groupBox1.TabIndex = 32;
            groupBox1.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(8, 197);
            label7.Name = "label7";
            label7.Size = new Size(91, 21);
            label7.TabIndex = 22;
            label7.Text = "AssignDate:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(25, 232);
            label6.Name = "label6";
            label6.Size = new Size(74, 21);
            label6.TabIndex = 21;
            label6.Text = "Deadline:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(43, 159);
            label5.Name = "label5";
            label5.Size = new Size(55, 21);
            label5.TabIndex = 20;
            label5.Text = "Status:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(6, 54);
            label2.Name = "label2";
            label2.Size = new Size(92, 21);
            label2.TabIndex = 19;
            label2.Text = "Description:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(11, 22);
            label1.Name = "label1";
            label1.Size = new Size(88, 21);
            label1.TabIndex = 18;
            label1.Text = "Task Name:";
            // 
            // EditTasksForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(363, 453);
            Controls.Add(dtpAssignDate);
            Controls.Add(dtpDeadline);
            Controls.Add(ddlStatus);
            Controls.Add(txtDescription);
            Controls.Add(txtTaskName);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(pictureBox1);
            Controls.Add(groupBox1);
            Name = "EditTasksForm";
            Text = "EditTasksForm";
            Load += EditTasksForm_Load;
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
        private TextBox txtTaskName;
        private RichTextBox txtDescription;
        private ComboBox ddlStatus;
        private DateTimePicker dtpDeadline;
        private Button btnSave;
        private Button btnCancel;
        private DateTimePicker dtpAssignDate;
        private GroupBox groupBox1;
        private Label label1;
        private Label label2;
        private Label label5;
        private Label label7;
        private Label label6;
    }
}