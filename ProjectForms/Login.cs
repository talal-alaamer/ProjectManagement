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
using ProjectManagementBusinessObjects;

namespace ProjectForms
{
    public partial class Login : Form
    {
        IdentityContext identityContext;
        ProjectManagementDBContext context;
        private ServiceProvider? serviceProvider;



        public Login()
        {
            InitializeComponent();
            identityContext = new IdentityContext();
            this.context = new ProjectManagementDBContext();

            // making the form open up in the center and not allowing the user to resize the forms
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the email and password from the form's text boxes
                string email = txtEmail.Text;
                string password = txtPassword.Text;

                //Validation for inputs
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

                //Verify the credentials
                var signInResults = await VerifyUserNamePassword(email, password);

                //Redirect to the home page if the credentials are valid
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
                MessageBox.Show($"An error occurred: {ex.Message}");
                
            }
        }

        //Toggle visibility of the password field
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        //Function to verify the credentials
        public async Task<bool> VerifyUserNamePassword(string userName, string password)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
            var userManager = serviceProvider.GetRequiredService<UserManager<Users>>();
            var founduser = await userManager.FindByEmailAsync(txtEmail.Text);
            if (founduser != null)
            {
                var passCheck = await userManager.CheckPasswordAsync(founduser, password) == true;
                if (passCheck)
                {
                    //Save into global class
                    Global.SelectedUser = founduser;
                }
                return passCheck;
            }
            return false;
        }

        //Function to configure the identity services
        private void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<IdentityContext>();

            //Register UserManager & RoleManager
            services.AddIdentity<Users, IdentityRole>()
               .AddEntityFrameworkStores<IdentityContext>()
               .AddDefaultTokenProviders();

            //UserManager & RoleManager require logging and HttpContext dependencies
            services.AddLogging();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}