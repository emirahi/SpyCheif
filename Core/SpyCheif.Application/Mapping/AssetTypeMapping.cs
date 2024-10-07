using AutoMapper;
using SpyCheif.Application.Dto.AssetTypeDtos;
using SpyCheif.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Application.Mapping
{
    public class AssetTypeMapping : Profile
    {
        public AssetTypeMapping()
        {
            CreateMap<AssetType,AssetTypeDto>();
        }
    }
}
