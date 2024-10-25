using AutoMapper;
using SpyCheif.Application.Dto.ServiceDatabaseDtos;
using SpyCheif.Domain.Entity;

namespace SpyCheif.Application.Mapping
{
    public class ServiceDatabaseMapping : Profile
    {
        public ServiceDatabaseMapping()
        {
            CreateMap<ServiceDatabase, ServiceDatabaseDto>();
        }
    }
}
