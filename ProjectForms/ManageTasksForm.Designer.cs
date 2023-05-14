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
            txtDescription = new TextBox();
            ddlStatus = new ComboBox();
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
            ((System.ComponentModel.ISupportInitialize)dgvTasks).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtTaskName
            // 
            txtTaskName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtTaskName.Location = new Point(111, 148);
            txtTaskName.Name = "txtTaskName";
            txtTaskName.Size = new Size(210, 29);
            txtTaskName.TabIndex = 1;
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtDescription.Location = new Point(111, 201);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(210, 29);
            txtDescription.TabIndex = 2;
            // 
            // ddlStatus
            // 
            ddlStatus.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ddlStatus.FormattingEnabled = true;
            ddlStatus.Location = new Point(111, 273);
            ddlStatus.Name = "ddlStatus";
            ddlStatus.Size = new Size(210, 29);
            ddlStatus.TabIndex = 3;
            // 
            // dtpDeadline
            // 
            dtpDeadline.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dtpDeadline.Location = new Point(111, 330);
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
            dgvTasks.Location = new Point(345, 148);
            dgvTasks.Name = "dgvTasks";
            dgvTasks.ReadOnly = true;
            dgvTasks.RowTemplate.Height = 25;
            dgvTasks.Size = new Size(392, 283);
            dgvTasks.TabIndex = 5;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(0, 0, 64);
            pictureBox1.Location = new Point(2, 1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(747, 118);
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(0, 0, 64);
            label4.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.Transparent;
            label4.Location = new Point(238, 36);
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
            label3.Location = new Point(637, 104);
            label3.Name = "label3";
            label3.Size = new Size(80, 15);
            label3.TabIndex = 16;
            label3.Text = "Manage Tasks";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 156);
            label1.Name = "label1";
            label1.Size = new Size(88, 21);
            label1.TabIndex = 17;
            label1.Text = "Task Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(11, 209);
            label2.Name = "label2";
            label2.Size = new Size(92, 21);
            label2.TabIndex = 18;
            label2.Text = "Description:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(45, 276);
            label5.Name = "label5";
            label5.Size = new Size(55, 21);
            label5.TabIndex = 19;
            label5.Text = "Status:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(26, 336);
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
            btnCreateTask.Location = new Point(111, 399);
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
            btnCancel.Location = new Point(219, 399);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(102, 32);
            btnCancel.TabIndex = 22;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // ManageTasksForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(749, 442);
            Controls.Add(btnCancel);
            Controls.Add(btnCreateTask);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(pictureBox1);
            Controls.Add(dgvTasks);
            Controls.Add(dtpDeadline);
            Controls.Add(ddlStatus);
            Controls.Add(txtDescription);
            Controls.Add(txtTaskName);
            Name = "ManageTasksForm";
            Text = "ManageTasksForm";
            Load += ManageTasksForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTasks).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtTaskName;
        private TextBox txtDescription;
        private ComboBox ddlStatus;
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
    }
}