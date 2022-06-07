﻿
namespace Domain.Entities
{
    public class TodoItem
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
        public string? Secret { get; set; }
        public DateTime DateCreated { get; set; }


    }
}
