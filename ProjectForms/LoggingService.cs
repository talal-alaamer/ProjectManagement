using ProjectManagementBusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjectForms
{
    internal class LoggingService
    {
        private ProjectManagementBusinessObjects.ProjectManagementDBContext context;

        public LoggingService(ProjectManagementBusinessObjects.ProjectManagementDBContext dbContext)
        {
            context = dbContext;
        }

        //Function to log exceptions to the database
        public void LogException(Exception exception, int userId)
        {
            // Log the exception
            var log = new Log
            {
                Source = exception.Source,
                Exception = exception.ToString(),
                UserId = userId
            };

            //Save the exception details to the "Log" table
            context.Logs.Add(log);
            context.SaveChanges();
        }
    }
}
