using SpyCheif.Application.Feature.Base;
using SpyCheif.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Application.Feature.Command.AssetCommand.Add
{
    public class AssetAddCommandResponse : BaseResponse
    {
        public Asset Asset { get; set; } 
    }
}
