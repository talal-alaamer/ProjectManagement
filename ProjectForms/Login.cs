using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjectForms;
using ProjectManagement;
using ProjectManagement.Areas.Identity.Data;
using ProjectManagement.Data;
using System.Linq;
using System.Configuration;

namespace Test
{
    public partial class Login : Form
    {
        IdentityContext identityContext;
        private ServiceProvider? serviceProvider;

        public Login()
        {
            InitializeComponent();
            identityContext = new IdentityContext();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
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

                var signInResults = await VerifyUserNamePassword(txtEmail.Text, txtPassword.Text);
                if (signInResults == true)
                {
                    ProjectManager PM = new ProjectManager();
                    PM.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Error. The username or password are not correct");
                }

            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the authentication process
                MessageBox.Show($"An error occurred while trying to authenticate: {ex.Message}");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }


        public async Task<bool> VerifyUserNamePassword(string userName, string password)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            IServiceProvider serviceProvider;
            serviceProvider = services.BuildServiceProvider();

            var userManager = serviceProvider.GetRequiredService<UserManager<Users>>();

            var founduser = await userManager.FindByEmailAsync(txtEmail.Text);

            if (founduser != null)
            {
                var passCheck = await userManager.CheckPasswordAsync(founduser, password) == true;

                if (passCheck)
                {
                    //save into global class
                    Global.SelectedUser = founduser;
                }
                return passCheck;
            }
            return false;
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<IdentityContext>();

            // Register UserManager & RoleManager
            services.AddIdentity<Users, IdentityRole>()
               .AddEntityFrameworkStores<IdentityContext>()
               .AddDefaultTokenProviders();

            // UserManager & RoleManager require logging and HttpContext dependencies
            services.AddLogging();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}