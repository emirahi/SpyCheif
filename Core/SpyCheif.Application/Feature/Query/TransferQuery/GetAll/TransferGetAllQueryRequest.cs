using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Application.Feature.Query.TransferQuery.GetAll
{
    public class TransferGetAllQueryRequest:IRequest<TransferGetAllQueryResponse>
    {
        public string AppName { get; set; }
    }
}
