namespace RecordOfTasks.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public string NameUser { get; set; }
        public string MessageText { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
