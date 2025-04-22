using System;

namespace ToDoApi.Domain
{
    public class TaskItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public DateTime DueDate { get; set; }
    }
}