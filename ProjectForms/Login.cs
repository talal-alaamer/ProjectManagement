using ProjectForms;
using ProjectManagement;
using ProjectManagement.Model;
using System.Linq;

namespace Test
{
    public partial class Login : Form
    {
        ProjectManagementDBContext context;
        public Login()
        {
            InitializeComponent();
            context = new ProjectManagementDBContext();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //hello
            //ali commit
        }

        private void button1_Click(object sender, EventArgs e)
        {
           /* try
            {
                // Get the email and password from the form's text boxes
                string email = txtEmail.Text;
                string password = txtPassword.Text;

                if (string.IsNullOrEmpty(email))
                {
                    MessageBox.Show("Please enter your email");
                    return;
                }

                if (string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Please enter your password");
                    return;
                }
        */
                // Get the user from the database using their email and password
                Global.SelectedUser = context.Users
                    .SingleOrDefault(u => u.UserId == 4);

                /*if (user != null)
                {
                    // Authentication successful
                    // Check user's authorization
                    if (user.RoleId == 1) // Admin
                    {
                        /*/// Redirect user to admin dashboard
                        ProjectManager PM = new ProjectManager();
                        this.Hide();
                        PM.Show();

                    /*}
                    else if (user.RoleId == 2) // User
                    {
                        // Redirect user to user dashboard
                        ProjectMembers M = new ProjectMembers(user);
                        this.Hide();
                        M.Show();
                    }
                    else
                    {
                        // Unauthorized access
                        MessageBox.Show("You don't have permission to access this page");
                    }
                }
                else
                {
                    // Authentication failed
                    MessageBox.Show("Invalid email or password");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the authentication process
                MessageBox.Show($"An error occurred while trying to authenticate: {ex.Message}");
            }*/
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }
    }
}