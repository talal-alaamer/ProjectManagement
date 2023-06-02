using ProjectManagement.Model;
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
        private ProjectManagementDBContext context;

        public LoggingService(ProjectManagementDBContext dbContext)
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
                Timestamp = BitConverter.GetBytes(DateTime.Now.Ticks),
                UserId = userId
            };

            context.Logs.Add(log);
            context.SaveChanges();
        }
    }
}
