using SpyCheif.Application.Dto.AssetTypeDtos;
using SpyCheif.Application.Feature.Base;
using SpyCheif.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Application.Feature.Query.AssetTypeQuery.Get
{
    public class AssetTypeGetQueryResponse:BaseResponse
    {
        public AssetTypeDto assetType { get; set; }
    }
}
