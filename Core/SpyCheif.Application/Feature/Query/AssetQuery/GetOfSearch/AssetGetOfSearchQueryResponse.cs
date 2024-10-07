using SpyCheif.Application.Dto.AssetDtos;
using SpyCheif.Application.Feature.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Application.Feature.Query.AssetQuery.GetOfSearch
{
    public class AssetGetOfSearchQueryResponse:BaseResponse
    {
        public List<AssetDto> Assets{ get; set; }
    }
}
