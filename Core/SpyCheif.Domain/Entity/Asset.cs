using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Domain.Entity
{
    public class Asset : BaseEntity
    {
        public string Value { get; set; }
        public int Type { get; set; }
    }
}
