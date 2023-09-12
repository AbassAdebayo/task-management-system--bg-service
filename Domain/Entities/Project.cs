using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Project : BaseEntity
    {
        public Project() { }

        public Project(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();
    }
}
