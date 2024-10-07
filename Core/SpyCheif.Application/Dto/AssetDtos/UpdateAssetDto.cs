using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Application.Dto.AssetDtos
{
    public class UpdateAssetDto : IDto
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Type { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
