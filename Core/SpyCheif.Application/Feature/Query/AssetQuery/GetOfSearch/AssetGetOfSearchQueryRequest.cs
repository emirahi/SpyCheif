using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Application.Feature.Query.AssetQuery.GetOfSearch
{
    public class AssetGetOfSearchQueryRequest:IRequest<AssetGetOfSearchQueryResponse>
    {
        public Guid? AssetTypeId { get; set; }
        public string? match { get; set; }
        public bool uniq { get; set; } = false;
    }
}
