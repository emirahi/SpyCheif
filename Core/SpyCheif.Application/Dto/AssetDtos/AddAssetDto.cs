using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Application.Dto.AssetDtos
{
    public class AddAssetDto : IDto
    {
        public string Value { get; set; }
        public int Type { get; set; }
    }
}
