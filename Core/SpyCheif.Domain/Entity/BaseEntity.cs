using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Domain.Entity
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; } = true;

    }
}
