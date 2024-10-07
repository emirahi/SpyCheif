using AutoMapper;
using SpyCheif.Application.Dto.AssetDtos;
using SpyCheif.Application.Feature.Command.AssetCommand.Add;
using SpyCheif.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Application.Mapping
{
    public  class AssetMapping : Profile
    {
        public AssetMapping()
        {

            CreateMap<Asset, AssetDto>().ForMember(destination => destination.Type, member => member.MapFrom(map => map.Type.Type)).ReverseMap();
            CreateMap<Asset, AddAssetDto>().ReverseMap();
            CreateMap<Asset, UpdateAssetDto>().ReverseMap();

            CreateMap<AddAssetDto, AssetAddCommandRequest>().ReverseMap();

        }
    }
}
