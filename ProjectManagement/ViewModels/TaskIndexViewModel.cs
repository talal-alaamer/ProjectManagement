using ProjectManagementBusinessObjects;

namespace ProjectManagement.ViewModels
{
    public class TaskIndexViewModel
    {
        //Generating properties for the list of task and status lists
        public IEnumerable<ProjectManagementBusinessObjects.Task>? Tasks { get; set; }
        public IEnumerable<ProjectManagementBusinessObjects.TaskStatus>? Statuses { get; set; }
        //Properties to store the search string and status filter
        public string? SearchString { get; set; }
        public string? Status { get; set; }
    }
}
