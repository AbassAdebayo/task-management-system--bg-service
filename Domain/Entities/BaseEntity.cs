using Domain.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BaseEntity : ISoftDeletable, IAuditBase
    {
        public Guid Id { get; init; }

        public string? CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Modified { get; set; }

        public string? ModifiedBy { get; set; }
    }
}
