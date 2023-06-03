using Microsoft.AspNetCore.SignalR;
using ProjectManagementBusinessObjects;

namespace ProjectManagement
{
    public static class Global
    {
        public static int userId { get; set; }

        private static readonly ProjectManagementDBContext? _context = new ProjectManagementDBContext();

        public static void LogException(Exception exception, int userId)
        {
            // Log the exception
            // Save the exception details to the "Log" table
            var log = new Log
            {
                Source = exception.Source,
                Exception = exception.ToString(),
                UserId = userId
            };

            _context.Logs.Add(log);
            _context.SaveChanges();
        }
    }
}
