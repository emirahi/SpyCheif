using MediatR;
using MongoDB.Bson;
using SpyCheif.Application.BaseNosql;
using SpyCheif.Application.Constants;
using SpyCheif.Application.Repository.ServiceDatabaseRepo;
using SpyCheif.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SpyCheif.Application.Feature.Query.ServiceDatabaseQuery.Get
{
    public class ServiceDatabaseGetQueryHandler : IRequestHandler<ServiceDatabaseGetQueryRequest, ServiceDatabaseGetQueryResponse>
    {
        private readonly IReadServiceDatabaseRepository _readServiceDatabaseRepository;
        private readonly IBaseNoSqlReadRepository _baseNoSqlReadRepository;
        public ServiceDatabaseGetQueryHandler(
            IReadServiceDatabaseRepository readServiceDatabaseRepository)
        {
            _readServiceDatabaseRepository = readServiceDatabaseRepository;
        }

        public async Task<ServiceDatabaseGetQueryResponse> Handle(ServiceDatabaseGetQueryRequest request, CancellationToken cancellationToken)
        {
            ServiceDatabase? service = _readServiceDatabaseRepository.Get(request.ServiceAppId);
            if (service != null)
                return new ServiceDatabaseGetQueryResponse() { ServiceDatabase = service, Status = true, Message = ResultMessages.GetSuccessServiceDatabaseMessage };
            return new ServiceDatabaseGetQueryResponse() { ServiceDatabase = null, Status = false, Message = ResultMessages.GetErrorServiceDatabaseMessage };
        }

    }
}
