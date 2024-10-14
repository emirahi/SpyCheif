using AutoMapper;
using SpyCheif.Application.Dto.AssetTypeDtos;
using SpyCheif.Application.Feature.Command.AssetTypeCommand.Add;
using SpyCheif.Application.Feature.Command.AssetTypeCommand.Update;
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
            CreateMap<AssetType,AssetTypeDto>().ReverseMap();
            CreateMap<AssetType,AssetTypeAddCommandRequest>().ReverseMap();
        }
    }
}
