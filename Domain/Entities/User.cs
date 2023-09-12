using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public User() { }   
        public User(Guid id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        public string Name { get; set; }  
        public string Email { get; set; }
        public ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();
    }
}
