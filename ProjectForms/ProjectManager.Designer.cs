namespace Test
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
            ((System.ComponentModel.ISupportInitialize)dgvProjects).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dgvProjects
            // 
            dgvProjects.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProjects.Location = new Point(19, 138);
            dgvProjects.Name = "dgvProjects";
            dgvProjects.RowTemplate.Height = 25;
            dgvProjects.Size = new Size(440, 302);
            dgvProjects.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(0, 0, 64);
            pictureBox1.Location = new Point(-1, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(626, 118);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ScrollBar;
            label3.ForeColor = Color.Black;
            label3.Location = new Point(495, 103);
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
            label4.Location = new Point(158, 35);
            label4.Name = "label4";
            label4.Size = new Size(301, 45);
            label4.TabIndex = 8;
            label4.Text = "Project Manegment";
            // 
            // txtFilter
            // 
            txtFilter.Location = new Point(128, 460);
            txtFilter.Name = "txtFilter";
            txtFilter.Size = new Size(126, 23);
            txtFilter.TabIndex = 9;
            // 
            // lblFilter
            // 
            lblFilter.AutoSize = true;
            lblFilter.Location = new Point(19, 462);
            lblFilter.Name = "lblFilter";
            lblFilter.Size = new Size(103, 15);
            lblFilter.TabIndex = 10;
            lblFilter.Text = "Filter by ProjectID:";
            // 
            // btnFilter
            // 
            btnFilter.Location = new Point(260, 458);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(75, 25);
            btnFilter.TabIndex = 11;
            btnFilter.Text = "Filter";
            btnFilter.UseVisualStyleBackColor = true;
            btnFilter.Click += btnFilter_Click;
            // 
            // btnRest
            // 
            btnRest.Location = new Point(341, 458);
            btnRest.Name = "btnRest";
            btnRest.Size = new Size(75, 25);
            btnRest.TabIndex = 12;
            btnRest.Text = "Reset";
            btnRest.UseVisualStyleBackColor = true;
            btnRest.Click += btnRest_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(485, 370);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(119, 25);
            btnAdd.TabIndex = 13;
            btnAdd.Text = "Add New Project";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += button3_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(485, 329);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(119, 23);
            btnEdit.TabIndex = 14;
            btnEdit.Text = "Edit Projects";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnManage_Click;
            // 
            // btnDeleteProject
            // 
            btnDeleteProject.Location = new Point(485, 417);
            btnDeleteProject.Name = "btnDeleteProject";
            btnDeleteProject.Size = new Size(119, 23);
            btnDeleteProject.TabIndex = 15;
            btnDeleteProject.Text = "Delete Project";
            btnDeleteProject.UseVisualStyleBackColor = true;
            btnDeleteProject.Click += btnDeleteProject_Click;
            // 
            // btnAddMember
            // 
            btnAddMember.Location = new Point(485, 285);
            btnAddMember.Name = "btnAddMember";
            btnAddMember.Size = new Size(119, 23);
            btnAddMember.TabIndex = 16;
            btnAddMember.Text = "Add Member";
            btnAddMember.UseVisualStyleBackColor = true;
            btnAddMember.Click += btnAddMember_Click;
            // 
            // ProjectManager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(619, 495);
            Controls.Add(btnAddMember);
            Controls.Add(btnDeleteProject);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(btnRest);
            Controls.Add(btnFilter);
            Controls.Add(lblFilter);
            Controls.Add(txtFilter);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(pictureBox1);
            Controls.Add(dgvProjects);
            Name = "ProjectManager";
            Text = "ProjectManager";
            Load += ProjectManager_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProjects).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
    }
}