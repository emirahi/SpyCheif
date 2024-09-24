using MediatR;
using SpyCheif.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Application.Feature.Command.ServiceDatabaseCommand.Add
{
    public class ServiceDatabaseAddCommandRequest:IRequest<ServiceDatabaseAddCommandResponse>
    {
        public string AppName { get; set; }
        public string DatabaseName { get; set; }
        public string CollentionName { get; set; }
    }
}
