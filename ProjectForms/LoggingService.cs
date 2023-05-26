using ProjectManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectForms
{
    internal class LoggingService
    {
        private readonly ProjectManagementDBContext context;

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

        public void LogUserAction(string action, int userId)
        {
            // Log the user action
            // ...

            // Save the user action details to the "Audit" table
            var audit = new Audit
            {
                Timestamp = BitConverter.GetBytes(DateTime.Now.Ticks),
                ChangeType = "User Action",
                TableName = "YourTableName",
                RecordId = 0, // Set the appropriate record ID if applicable
                OldValue = null,
                CurrentValue = action,
                UserId = userId
            };

            context.Audits.Add(audit);
            context.SaveChanges();

        }
    }
}
