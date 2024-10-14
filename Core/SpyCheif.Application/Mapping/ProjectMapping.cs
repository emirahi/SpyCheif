using AutoMapper;
using SpyCheif.Application.Dto.ProjectDtos;
using SpyCheif.Application.Feature.Command.ProjectCommand.Add;
using SpyCheif.Domain.Entity;

namespace SpyCheif.Application.Mapping
{
    public class ProjectMapping : Profile
    {
        public ProjectMapping()
        {
            CreateMap<AddProjectDto, Project>().ReverseMap();
            CreateMap<ProjectDto, Project>().ReverseMap();

            CreateMap<ProjectAddCommandRequest, Project>().ReverseMap();
        }
    }
}
