using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Application.Feature.Query.ServiceDatabaseQuery.Get
{
    public class ServiceDatabaseGetQueryRequest:IRequest<ServiceDatabaseGetQueryResponse>
    {
        public Guid ServiceAppId { get; set; }
    }
}
