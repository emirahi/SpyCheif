using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Application.Feature.Query.AssetQuery.Get
{
    public class AssetGetQueryRequest:IRequest<AssetGetQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
