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

        public void LogException(Exception exception, int userId)
        {
            // Log the exception


            // Save the exception details to the "Log" table
            var log = new Log
            {
                Source = exception.Source,
                Exception = exception.ToString(),
                UserId = userId
            };

            context.Logs.Add(log);
            context.SaveChanges();
        }
    }
}
