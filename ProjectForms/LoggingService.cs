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

        public void LogUserAction(string action, int userId,string userAction, string TableName)
        {
            
            //var entity = context.YourTableName.Find(recordId);

            // Serialize the entity to capture its old value
            //var serializer = new JsonSerializer();
            //var oldValue = serializer.Serialize(entity);
            // Save the user action details to the "Audit" table
            var audit = new Audit
            {
                Timestamp = BitConverter.GetBytes(DateTime.Now.Ticks),
                ChangeType = userAction,
                TableName = TableName,
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
