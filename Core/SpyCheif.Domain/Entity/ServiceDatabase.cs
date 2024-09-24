using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Domain.Entity
{
    public class ServiceDatabase:BaseEntity
    {
        public string AppName { get; set; }
        public string DatabaseName { get; set; }
        public string CollentionName { get; set; }

    }
}
