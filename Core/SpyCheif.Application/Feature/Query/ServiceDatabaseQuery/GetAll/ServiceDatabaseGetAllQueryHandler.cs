using Amazon.Runtime.Internal;
using MediatR;
using SpyCheif.Application.Constants;
using SpyCheif.Application.Repository.ServiceDatabaseRepo;
using SpyCheif.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Application.Feature.Query.ServiceDatabaseQuery.GetAll
{
    public class ServiceDatabaseGetAllQueryHandler : IRequestHandler<ServiceDatabaseGetAllQueryRequest, ServiceDatabaseGetAllQueryResponse>
    {
        private readonly IReadServiceDatabaseRepository _readServiceDatabaseRepository;
        public ServiceDatabaseGetAllQueryHandler(IReadServiceDatabaseRepository readServiceDatabaseRepository)
        {
            _readServiceDatabaseRepository = readServiceDatabaseRepository;
        }

        public async Task<ServiceDatabaseGetAllQueryResponse> Handle(ServiceDatabaseGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            List<ServiceDatabase> service = _readServiceDatabaseRepository.GetAll().ToList();
            if (service.Count > 0)
                return new ServiceDatabaseGetAllQueryResponse() { ServiceDatabases = service, Status = true, Message = ResultMessages.GetAllSuccessServiceDatabaseMessage };
            return new ServiceDatabaseGetAllQueryResponse() { ServiceDatabases = null, Status = false, Message = ResultMessages.GetAllErrorServiceDatabaseMessage };

        }
    }
}
