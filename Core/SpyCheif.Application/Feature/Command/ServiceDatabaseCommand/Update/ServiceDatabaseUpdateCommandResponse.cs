using SpyCheif.Application.Feature.Base;
using SpyCheif.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Application.Feature.Command.ServiceDatabaseCommand.Update
{
    public class ServiceDatabaseUpdateCommandResponse:BaseResponse
    {
        public ServiceDatabase serviceDatabase { get; set; }
    }
}
