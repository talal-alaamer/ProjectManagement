using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectManagement;
using ProjectManagement.Model;

namespace ProjectForms
{
    public partial class ProjectMembers : Form
    {
        ProjectManagementDBContext context;
        User currentUser;
        public ProjectMembers(User currentUser)
        {
            InitializeComponent();
            context = new ProjectManagementDBContext();
            this.currentUser = currentUser;

            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void ProjectMember_Load(object sender, EventArgs e)
        {

        }
    }
}
