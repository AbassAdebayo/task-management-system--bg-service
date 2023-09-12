using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProjectTasks : BaseEntity
    {
        public Guid TaskId { get; set; }
        public Guid ProjectId { get; set; }
    }
}
