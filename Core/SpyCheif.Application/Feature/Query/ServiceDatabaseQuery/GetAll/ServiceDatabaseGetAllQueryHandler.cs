using AutoMapper;
using MediatR;
using SpyCheif.Application.Constants;
using SpyCheif.Application.Dto.ServiceDatabaseDtos;
using SpyCheif.Application.Repository.ServiceDatabaseRepo;
using SpyCheif.Domain.Entity;

namespace SpyCheif.Application.Feature.Query.ServiceDatabaseQuery.GetAll
{
    public class ServiceDatabaseGetAllQueryHandler : IRequestHandler<ServiceDatabaseGetAllQueryRequest, ServiceDatabaseGetAllQueryResponse>
    {
        private readonly IReadServiceDatabaseRepository _readServiceDatabaseRepository;
        private readonly IMapper _mapper;
        public ServiceDatabaseGetAllQueryHandler(IReadServiceDatabaseRepository readServiceDatabaseRepository,IMapper mapper)
        {
            _readServiceDatabaseRepository = readServiceDatabaseRepository;
            _mapper = mapper;
        }

        public async Task<ServiceDatabaseGetAllQueryResponse> Handle(ServiceDatabaseGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            List<ServiceDatabase> service = _readServiceDatabaseRepository.GetAll().ToList();
            if (service.Count > 0)
            {
                List<ServiceDatabaseDto> serviceDatabaseDtos = _mapper.Map<List<ServiceDatabaseDto>>(service);
                return new ServiceDatabaseGetAllQueryResponse() { ServiceDatabases = serviceDatabaseDtos, Status = true, Message = ResultMessages.GetAllSuccessServiceDatabaseMessage };
            }
            return new ServiceDatabaseGetAllQueryResponse() { ServiceDatabases = null, Status = false, Message = ResultMessages.GetAllErrorServiceDatabaseMessage };

        }
    }
}
