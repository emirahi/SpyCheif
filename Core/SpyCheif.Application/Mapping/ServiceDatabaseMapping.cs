using AutoMapper;
using SpyCheif.Application.Dto.ServiceDatabaseDtos;
using SpyCheif.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
