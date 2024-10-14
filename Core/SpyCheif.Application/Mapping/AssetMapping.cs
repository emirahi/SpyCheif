using AutoMapper;
using SpyCheif.Application.Dto.AssetDtos;
using SpyCheif.Application.Feature.Command.AssetCommand.Add;
using SpyCheif.Application.Feature.Command.AssetCommand.Update;
using SpyCheif.Domain.Entity;

namespace SpyCheif.Application.Mapping
{
    public  class AssetMapping : Profile
    {
        public AssetMapping()
        {

            CreateMap<Asset, AssetDto>()
                .ForMember(destination => destination.Type, member => member.MapFrom(map => map.Type.Type))
                .ForMember(destination => destination.ProjectName,member => member.MapFrom(map => map.Project.ProjectName))
                .ReverseMap();

            CreateMap<Asset, AssetAddCommandRequest>().ReverseMap();
            CreateMap<Asset, AssetUpdateCommandRequest>().ReverseMap();

        }
    }
}
