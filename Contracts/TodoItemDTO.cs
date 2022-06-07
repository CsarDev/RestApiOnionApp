
namespace Domain.Contracts
{
    public class TodoItemDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
        public string? Secret { get; set; }
        public DateTime DateCreated { get; set; }


    }
}
