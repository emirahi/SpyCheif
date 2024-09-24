using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Application.Feature.Query.TransferQuery.Get
{
    public class TransferGetQueryRequest:IRequest<TransferGetQueryResponse>
    {
        public string AppName { get; set; }
        public string Id { get; set; }

    }
}
