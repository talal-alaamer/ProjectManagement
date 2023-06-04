using ProjectManagement.Areas.Identity.Data;
using ProjectManagementBusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectForms
{
    public static class Global
    {
        //Global class to store the current user and current project so that it can be accessed from anywhere
        public static Users SelectedUser;

        public static Project SelectedProject;
    }
}
