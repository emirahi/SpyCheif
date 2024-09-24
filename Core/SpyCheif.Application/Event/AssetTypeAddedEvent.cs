using SpyCheif.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Application.Event
{
    public  class AssetTypeAddedEvent
    {
        public string Value { get; set; }
        public Guid AssetTypeId { get; set; }
    }
}
