namespace ProjectForms
{
    partial class ProjectManager
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
            dgvProjects = new DataGridView();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            label4 = new Label();
            txtFilter = new TextBox();
            lblFilter = new Label();
            btnFilter = new Button();
            btnRest = new Button();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDeleteProject = new Button();
            btnAddMember = new Button();
            btnManageTasks = new Button();
            btnDashboard = new Button();
            groupBox1 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dgvProjects).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvProjects
            // 
            dgvProjects.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProjects.Location = new Point(12, 139);
            dgvProjects.Name = "dgvProjects";
            dgvProjects.RowTemplate.Height = 25;
            dgvProjects.Size = new Size(443, 295);
            dgvProjects.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(0, 0, 64);
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(665, 118);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ScrollBar;
            label3.ForeColor = Color.Black;
            label3.Location = new Point(553, 103);
            label3.Name = "label3";
            label3.Size = new Size(94, 15);
            label3.TabIndex = 7;
            label3.Text = "Project Manager";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(0, 0, 64);
            label4.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.Transparent;
            label4.Location = new Point(192, 37);
            label4.Name = "label4";
            label4.Size = new Size(301, 45);
            label4.TabIndex = 8;
            label4.Text = "Project Manegment";
            // 
            // txtFilter
            // 
            txtFilter.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtFilter.Location = new Point(154, 440);
            txtFilter.Name = "txtFilter";
            txtFilter.Size = new Size(139, 29);
            txtFilter.TabIndex = 9;
            // 
            // lblFilter
            // 
            lblFilter.AutoSize = true;
            lblFilter.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblFilter.Location = new Point(12, 444);
            lblFilter.Name = "lblFilter";
            lblFilter.Size = new Size(136, 21);
            lblFilter.TabIndex = 10;
            lblFilter.Text = "Filter by ProjectID:";
            // 
            // btnFilter
            // 
            btnFilter.BackColor = Color.White;
            btnFilter.FlatStyle = FlatStyle.Popup;
            btnFilter.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnFilter.Location = new Point(299, 440);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(75, 29);
            btnFilter.TabIndex = 11;
            btnFilter.Text = "Filter";
            btnFilter.UseVisualStyleBackColor = false;
            btnFilter.Click += btnFilter_Click;
            // 
            // btnRest
            // 
            btnRest.BackColor = Color.FromArgb(0, 0, 64);
            btnRest.FlatStyle = FlatStyle.Popup;
            btnRest.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnRest.ForeColor = Color.White;
            btnRest.Location = new Point(380, 440);
            btnRest.Name = "btnRest";
            btnRest.Size = new Size(75, 29);
            btnRest.TabIndex = 12;
            btnRest.Text = "Reset";
            btnRest.UseVisualStyleBackColor = false;
            btnRest.Click += btnRest_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.White;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnAdd.Location = new Point(6, 239);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(164, 50);
            btnAdd.TabIndex = 13;
            btnAdd.Text = "Add New Project";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.White;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnEdit.Location = new Point(6, 183);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(164, 50);
            btnEdit.TabIndex = 14;
            btnEdit.Text = "Edit a Projects";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnManage_Click;
            // 
            // btnDeleteProject
            // 
            btnDeleteProject.BackColor = Color.White;
            btnDeleteProject.FlatStyle = FlatStyle.Flat;
            btnDeleteProject.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnDeleteProject.Location = new Point(6, 127);
            btnDeleteProject.Name = "btnDeleteProject";
            btnDeleteProject.Size = new Size(164, 50);
            btnDeleteProject.TabIndex = 15;
            btnDeleteProject.Text = "Delete a Project";
            btnDeleteProject.UseVisualStyleBackColor = false;
            btnDeleteProject.Click += btnDeleteProject_Click;
            // 
            // btnAddMember
            // 
            btnAddMember.BackColor = Color.White;
            btnAddMember.FlatStyle = FlatStyle.Flat;
            btnAddMember.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddMember.Location = new Point(6, 71);
            btnAddMember.Name = "btnAddMember";
            btnAddMember.Size = new Size(164, 50);
            btnAddMember.TabIndex = 16;
            btnAddMember.Text = "Add Members to Project";
            btnAddMember.UseVisualStyleBackColor = false;
            btnAddMember.Click += btnAddMember_Click;
            // 
            // btnManageTasks
            // 
            btnManageTasks.BackColor = Color.White;
            btnManageTasks.FlatStyle = FlatStyle.Flat;
            btnManageTasks.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnManageTasks.Location = new Point(6, 15);
            btnManageTasks.Name = "btnManageTasks";
            btnManageTasks.Size = new Size(164, 50);
            btnManageTasks.TabIndex = 17;
            btnManageTasks.Text = "Manage Project Tasks";
            btnManageTasks.UseVisualStyleBackColor = false;
            btnManageTasks.Click += btnManageTasks_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.BackColor = Color.White;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnDashboard.Location = new Point(6, 295);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(164, 50);
            btnDashboard.TabIndex = 18;
            btnDashboard.Text = "Project dashboard";
            btnDashboard.UseVisualStyleBackColor = false;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnDashboard);
            groupBox1.Controls.Add(btnManageTasks);
            groupBox1.Controls.Add(btnDeleteProject);
            groupBox1.Controls.Add(btnAddMember);
            groupBox1.Controls.Add(btnAdd);
            groupBox1.Controls.Add(btnEdit);
            groupBox1.Location = new Point(477, 124);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(176, 351);
            groupBox1.TabIndex = 19;
            groupBox1.TabStop = false;
            // 
            // ProjectManager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(665, 483);
            Controls.Add(btnRest);
            Controls.Add(btnFilter);
            Controls.Add(lblFilter);
            Controls.Add(txtFilter);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(pictureBox1);
            Controls.Add(dgvProjects);
            Controls.Add(groupBox1);
            Name = "ProjectManager";
            Text = "ProjectManager";
            Load += ProjectManager_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProjects).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvProjects;
        private PictureBox pictureBox1;
        private Label label3;
        private Label label4;
        private TextBox txtFilter;
        private Label lblFilter;
        private Button btnFilter;
        private Button btnRest;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDeleteProject;
        private Button btnAddMember;
        private Button btnManageTasks;
        private Button btnDashboard;
        private GroupBox groupBox1;
    }
}