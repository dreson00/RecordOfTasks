namespace RecordOfTasks.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string Description { get; set; }
        public string Creator { get; set; }
        public string Assignee { get; set; }
        public DateTime ReportedDate { get; set; }
        public DateTime DueDate { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
    }
}