using Microsoft.AspNetCore.SignalR;
using ProjectManagementBusinessObjects;

namespace ProjectManagement
{
    public static class Global
    {
        //Store the current userid when logged in
        public static int userId { get; set; }

        private static readonly ProjectManagementDBContext? _context = new ProjectManagementDBContext();

        //Create a function to log exceptions to the database that is called in the catch blocks of every operation
        public static void LogException(Exception exception, int userId)
        {
            //Create a new log object and set its values
            var log = new Log
            {
                Source = exception.Source,
                Exception = exception.ToString(),
                UserId = userId
            };

            //Save the log to the database
            _context.Logs.Add(log);
            _context.SaveChanges();
        }
    }
}
