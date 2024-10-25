using AutoMapper;
using SpyCheif.Application.Dto.AssetTypeDtos;
using SpyCheif.Application.Feature.Command.AssetTypeCommand.Add;
using SpyCheif.Domain.Entity;

namespace SpyCheif.Application.Mapping
{
    public class AssetTypeMapping : Profile
    {
        public AssetTypeMapping()
        {
            CreateMap<AssetType, AssetTypeDto>().ReverseMap();
            CreateMap<AssetType, AssetTypeAddCommandRequest>()
                .ForMember(destination => destination.TypeName, member => member.MapFrom(x => x.Type))
                .ReverseMap();
        }
    }
}
