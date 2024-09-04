namespace RecordOfTasks.Models
{
    public class ChecklistItem
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime DueDate { get; set; }
    }
}