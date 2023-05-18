namespace ProjectForms
{
    partial class ProjectMembers
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
            btnRest = new Button();
            btnFilter = new Button();
            lblFilter = new Label();
            txtFilter = new TextBox();
            dgvProjects = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProjects).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(0, 0, 64);
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(626, 118);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
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
            label4.TabIndex = 9;
            label4.Text = "Project Manegment";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ScrollBar;
            label3.ForeColor = Color.Black;
            label3.Location = new Point(495, 103);
            label3.Name = "label3";
            label3.Size = new Size(92, 15);
            label3.TabIndex = 10;
            label3.Text = "Project Member";
            // 
            // btnRest
            // 
            btnRest.Location = new Point(341, 458);
            btnRest.Name = "btnRest";
            btnRest.Size = new Size(75, 25);
            btnRest.TabIndex = 17;
            btnRest.Text = "Reset";
            btnRest.UseVisualStyleBackColor = true;
            // 
            // btnFilter
            // 
            btnFilter.Location = new Point(260, 458);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(75, 25);
            btnFilter.TabIndex = 16;
            btnFilter.Text = "Filter";
            btnFilter.UseVisualStyleBackColor = true;
            // 
            // lblFilter
            // 
            lblFilter.AutoSize = true;
            lblFilter.Location = new Point(19, 462);
            lblFilter.Name = "lblFilter";
            lblFilter.Size = new Size(103, 15);
            lblFilter.TabIndex = 15;
            lblFilter.Text = "Filter by ProjectID:";
            // 
            // txtFilter
            // 
            txtFilter.Location = new Point(128, 460);
            txtFilter.Name = "txtFilter";
            txtFilter.Size = new Size(126, 23);
            txtFilter.TabIndex = 14;
            // 
            // dgvProjects
            // 
            dgvProjects.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProjects.Location = new Point(19, 138);
            dgvProjects.Name = "dgvProjects";
            dgvProjects.RowTemplate.Height = 25;
            dgvProjects.Size = new Size(440, 302);
            dgvProjects.TabIndex = 13;
            // 
            // ProjectMember
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(619, 495);
            Controls.Add(btnRest);
            Controls.Add(btnFilter);
            Controls.Add(lblFilter);
            Controls.Add(txtFilter);
            Controls.Add(dgvProjects);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(pictureBox1);
            Name = "ProjectMember";
            Text = "ProjectMember";
            Load += ProjectMember_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProjects).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label4;
        private Label label3;
        private Button btnRest;
        private Button btnFilter;
        private Label lblFilter;
        private TextBox txtFilter;
        private DataGridView dgvProjects;
    }
}