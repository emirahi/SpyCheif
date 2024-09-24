using Amazon.Runtime.Internal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Application.Feature.Command.ServiceDatabaseCommand.Update
{
    public class ServiceDatabaseUpdateCommandRequest:IRequest<ServiceDatabaseUpdateCommandResponse>
    {
        public Guid Id { get; set; }
        public string AppName { get; set; }
        public string DatabaseName { get; set; }
        public string CollectionName { get; set; }
    }
}
