using ProjectManagementBusinessObjects;

namespace ProjectManagement.ViewModels
{
    public class TaskIndexViewModel
    {
        public IEnumerable<ProjectManagementBusinessObjects.Task>? Tasks { get; set; }
        public IEnumerable<ProjectManagementBusinessObjects.TaskStatus>? Statuses { get; set; }
        public string? SearchString { get; set; }
        public string? Status { get; set; }
    }
}
