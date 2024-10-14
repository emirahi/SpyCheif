using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Domain.Entity
{
    public class Project : BaseEntity
    {
        public string ProjectName { get; set; }
        public string? Description { get; set; }
    }
}
