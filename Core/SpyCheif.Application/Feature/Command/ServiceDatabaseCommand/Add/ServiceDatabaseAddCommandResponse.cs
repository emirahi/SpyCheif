using SpyCheif.Application.Feature.Base;
using SpyCheif.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Application.Feature.Command.ServiceDatabaseCommand.Add
{
    public class ServiceDatabaseAddCommandResponse:BaseResponse
    {
        public ServiceDatabase ServiceDatabase { get; set; }
    }
}
