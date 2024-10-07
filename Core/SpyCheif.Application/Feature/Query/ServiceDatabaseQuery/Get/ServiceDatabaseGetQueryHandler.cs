using AutoMapper;
using MediatR;
using SpyCheif.Application.Constants;
using SpyCheif.Application.Dto.ServiceDatabaseDtos;
using SpyCheif.Application.Repository.ServiceDatabaseRepo;
using SpyCheif.Domain.Entity;

namespace SpyCheif.Application.Feature.Query.ServiceDatabaseQuery.Get
{
    public class ServiceDatabaseGetQueryHandler : IRequestHandler<ServiceDatabaseGetQueryRequest, ServiceDatabaseGetQueryResponse>
    {
        private readonly IReadServiceDatabaseRepository _readServiceDatabaseRepository;
        private readonly IMapper _mapper;
        public ServiceDatabaseGetQueryHandler(
            IReadServiceDatabaseRepository readServiceDatabaseRepository,
            IMapper mapper)
        {
            _readServiceDatabaseRepository = readServiceDatabaseRepository;
            _mapper = mapper;
        }

        public async Task<ServiceDatabaseGetQueryResponse> Handle(ServiceDatabaseGetQueryRequest request, CancellationToken cancellationToken)
        {
            ServiceDatabase? service = _readServiceDatabaseRepository.Get(request.ServiceAppId);
            if (service != null)
            {
                ServiceDatabaseDto? serviceDatabaseDto = _mapper.Map<ServiceDatabaseDto>(service);
                return new ServiceDatabaseGetQueryResponse() { ServiceDatabase = serviceDatabaseDto, Status = true, Message = ResultMessages.GetSuccessServiceDatabaseMessage };
            }
            return new ServiceDatabaseGetQueryResponse() { ServiceDatabase = null, Status = false, Message = ResultMessages.GetErrorServiceDatabaseMessage };
        }

    }
}
