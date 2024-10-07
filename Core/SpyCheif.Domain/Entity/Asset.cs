using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Domain.Entity
{
    public class Asset : BaseEntity
    {
        public Guid AssetTypeId { get; set; }
        public string Value { get; set; }
        public AssetType Type { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
