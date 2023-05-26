namespace ProjectForms
{
    partial class ManageTasksForm
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
            txtTaskName = new TextBox();
            dtpDeadline = new DateTimePicker();
            dgvTasks = new DataGridView();
            pictureBox1 = new PictureBox();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            label2 = new Label();
            label5 = new Label();
            label6 = new Label();
            btnCreateTask = new Button();
            btnCancel = new Button();
            txtDescription = new RichTextBox();
            btnManageStatus = new Button();
            ddlStatus = new ComboBox();
            btnDelete = new Button();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dgvTasks).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // txtTaskName
            // 
            txtTaskName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtTaskName.Location = new Point(103, 39);
            txtTaskName.Name = "txtTaskName";
            txtTaskName.Size = new Size(210, 29);
            txtTaskName.TabIndex = 1;
            // 
            // dtpDeadline
            // 
            dtpDeadline.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dtpDeadline.Location = new Point(103, 241);
            dtpDeadline.Name = "dtpDeadline";
            dtpDeadline.Size = new Size(210, 29);
            dtpDeadline.TabIndex = 4;
            // 
            // dgvTasks
            // 
            dgvTasks.AllowUserToAddRows = false;
            dgvTasks.AllowUserToDeleteRows = false;
            dgvTasks.AllowUserToResizeColumns = false;
            dgvTasks.AllowUserToResizeRows = false;
            dgvTasks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTasks.Location = new Point(6, 28);
            dgvTasks.Name = "dgvTasks";
            dgvTasks.ReadOnly = true;
            dgvTasks.RowTemplate.Height = 25;
            dgvTasks.Size = new Size(562, 257);
            dgvTasks.TabIndex = 5;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(0, 0, 64);
            pictureBox1.Location = new Point(2, 1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(937, 118);
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(0, 0, 64);
            label4.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.Transparent;
            label4.Location = new Point(326, 35);
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
            label3.Location = new Point(838, 104);
            label3.Name = "label3";
            label3.Size = new Size(80, 15);
            label3.TabIndex = 16;
            label3.Text = "Manage Tasks";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(9, 42);
            label1.Name = "label1";
            label1.Size = new Size(88, 21);
            label1.TabIndex = 17;
            label1.Text = "Task Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(9, 94);
            label2.Name = "label2";
            label2.Size = new Size(92, 21);
            label2.TabIndex = 18;
            label2.Text = "Description:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(42, 199);
            label5.Name = "label5";
            label5.Size = new Size(55, 21);
            label5.TabIndex = 19;
            label5.Text = "Status:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(23, 247);
            label6.Name = "label6";
            label6.Size = new Size(74, 21);
            label6.TabIndex = 20;
            label6.Text = "Deadline:";
            // 
            // btnCreateTask
            // 
            btnCreateTask.BackColor = Color.FromArgb(0, 0, 64);
            btnCreateTask.BackgroundImageLayout = ImageLayout.None;
            btnCreateTask.FlatStyle = FlatStyle.Popup;
            btnCreateTask.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnCreateTask.ForeColor = Color.White;
            btnCreateTask.Location = new Point(103, 286);
            btnCreateTask.Name = "btnCreateTask";
            btnCreateTask.Size = new Size(102, 32);
            btnCreateTask.TabIndex = 21;
            btnCreateTask.Text = "Create";
            btnCreateTask.UseVisualStyleBackColor = false;
            btnCreateTask.Click += btnCreateTask_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.DarkRed;
            btnCancel.BackgroundImageLayout = ImageLayout.None;
            btnCancel.FlatStyle = FlatStyle.Popup;
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(211, 286);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(102, 32);
            btnCancel.TabIndex = 22;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(103, 91);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(210, 96);
            txtDescription.TabIndex = 24;
            txtDescription.Text = "";
            // 
            // btnManageStatus
            // 
            btnManageStatus.BackColor = Color.FromArgb(0, 0, 64);
            btnManageStatus.BackgroundImageLayout = ImageLayout.None;
            btnManageStatus.FlatStyle = FlatStyle.Popup;
            btnManageStatus.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnManageStatus.ForeColor = Color.White;
            btnManageStatus.Location = new Point(132, 291);
            btnManageStatus.Name = "btnManageStatus";
            btnManageStatus.Size = new Size(162, 32);
            btnManageStatus.TabIndex = 27;
            btnManageStatus.Text = "Edit Existing Task  ";
            btnManageStatus.UseVisualStyleBackColor = false;
            btnManageStatus.Click += btnManageStatus_Click;
            // 
            // ddlStatus
            // 
            ddlStatus.Font = new Font("Segoe UI Light", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ddlStatus.FormattingEnabled = true;
            ddlStatus.Location = new Point(103, 199);
            ddlStatus.Name = "ddlStatus";
            ddlStatus.Size = new Size(210, 29);
            ddlStatus.TabIndex = 28;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.DarkRed;
            btnDelete.BackgroundImageLayout = ImageLayout.None;
            btnDelete.FlatStyle = FlatStyle.Popup;
            btnDelete.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(300, 291);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(162, 32);
            btnDelete.TabIndex = 29;
            btnDelete.Text = "Delete Existing Task";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtDescription);
            groupBox1.Controls.Add(ddlStatus);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtTaskName);
            groupBox1.Controls.Add(btnCreateTask);
            groupBox1.Controls.Add(btnCancel);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(dtpDeadline);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.ForeColor = Color.Black;
            groupBox1.Location = new Point(8, 125);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(331, 335);
            groupBox1.TabIndex = 30;
            groupBox1.TabStop = false;
            groupBox1.Text = "Creat a new Task";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnDelete);
            groupBox2.Controls.Add(btnManageStatus);
            groupBox2.Controls.Add(dgvTasks);
            groupBox2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox2.Location = new Point(350, 125);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(581, 335);
            groupBox2.TabIndex = 31;
            groupBox2.TabStop = false;
            groupBox2.Text = "Select a Task from the table to delete or edit";
            // 
            // ManageTasksForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(937, 472);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(pictureBox1);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Name = "ManageTasksForm";
            Text = "ManageTasksForm";
            Load += ManageTasksForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTasks).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtTaskName;
        private DateTimePicker dtpDeadline;
        private DataGridView dgvTasks;
        private PictureBox pictureBox1;
        private Label label4;
        private Label label3;
        private Label label1;
        private Label label2;
        private Label label5;
        private Label label6;
        private Button btnCreateTask;
        private Button btnCancel;
        private RichTextBox txtDescription;
        private Button btnManageStatus;
        private ComboBox ddlStatus;
        private Button btnDelete;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
    }
}