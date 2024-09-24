using Amazon.Runtime.Internal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Application.Feature.Command.ServiceDatabaseCommand.Delete
{
    public class ServiceDatabaseDeleteCommandRequest:IRequest<ServiceDatabaseDeleteCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
