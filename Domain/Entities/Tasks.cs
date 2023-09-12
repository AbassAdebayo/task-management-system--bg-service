using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Tasks : BaseEntity
    {
        public Tasks() { }

        public Tasks(string tittle, Guid userId, string description, DateTime dueDate, Priority priority, Status status)
        {
            Tittle = tittle;
            UserId = userId;
            Description = description;
            DueDate = dueDate;
            Priority = priority;
            Status = status;
        }
        public Guid UserId { get; set; }
        public User? User { get; set; }
        public string? Tittle { get; set; }
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }

    }
}
