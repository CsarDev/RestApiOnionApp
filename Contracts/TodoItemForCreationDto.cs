namespace Domain.Contracts
{
    public class TodoItemForCreationDto
    {
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
        public DateTime DateCreated { get; set; }

    }
}