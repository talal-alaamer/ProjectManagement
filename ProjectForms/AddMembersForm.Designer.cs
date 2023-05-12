namespace ProjectForms
{
    partial class AddMembersForm
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
            ddlMembers = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            dgvMembers = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMembers).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(0, 0, 64);
            pictureBox1.Location = new Point(-2, -2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(341, 118);
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(0, 0, 64);
            label4.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.Transparent;
            label4.Location = new Point(22, 33);
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
            label3.Location = new Point(241, 101);
            label3.Name = "label3";
            label3.Size = new Size(82, 15);
            label3.TabIndex = 15;
            label3.Text = "Add Members";
            // 
            // ddlMembers
            // 
            ddlMembers.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ddlMembers.FormattingEnabled = true;
            ddlMembers.Location = new Point(12, 348);
            ddlMembers.Name = "ddlMembers";
            ddlMembers.Size = new Size(311, 29);
            ddlMembers.TabIndex = 16;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(0, 0, 64);
            btnSave.FlatStyle = FlatStyle.Popup;
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(36, 405);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(106, 33);
            btnSave.TabIndex = 17;
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
            btnCancel.Location = new Point(200, 405);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(106, 33);
            btnCancel.TabIndex = 18;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // dgvMembers
            // 
            dgvMembers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMembers.Location = new Point(12, 160);
            dgvMembers.Name = "dgvMembers";
            dgvMembers.RowTemplate.Height = 25;
            dgvMembers.Size = new Size(311, 150);
            dgvMembers.TabIndex = 19;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(11, 136);
            label1.Name = "label1";
            label1.Size = new Size(131, 21);
            label1.TabIndex = 20;
            label1.Text = "Project Members:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 324);
            label2.Name = "label2";
            label2.Size = new Size(305, 21);
            label2.TabIndex = 21;
            label2.Text = "Choose a user to add as a Project Member:";
            // 
            // AddMembersForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(339, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvMembers);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(ddlMembers);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(pictureBox1);
            Name = "AddMembersForm";
            Text = "AddMembersForm";
            Load += AddMembersForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMembers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label4;
        private Label label3;
        private ComboBox ddlMembers;
        private Button btnSave;
        private Button btnCancel;
        private DataGridView dgvMembers;
        private Label label1;
        private Label label2;
    }
}