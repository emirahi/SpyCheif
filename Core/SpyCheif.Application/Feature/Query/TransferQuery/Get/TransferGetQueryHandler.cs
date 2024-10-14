using MediatR;
using MongoDB.Bson;
using SpyCheif.Application.BaseNosql;
using SpyCheif.Application.Constants;
using SpyCheif.Application.Repository.ServiceDatabaseRepo;
using SpyCheif.Domain.Entity;

namespace SpyCheif.Application.Feature.Query.TransferQuery.Get
{
    public class TransferGetQueryHandler : IRequestHandler<TransferGetQueryRequest, TransferGetQueryResponse>
    {
        private readonly IReadServiceDatabaseRepository _readServiceDatabaseRepository;
        private readonly IBaseNoSqlReadRepository _baseNoSqlReadRepository;
        public TransferGetQueryHandler(
            IReadServiceDatabaseRepository readServiceDatabaseRepository,
            IBaseNoSqlReadRepository baseNoSqlReadRepository)
        {
            _readServiceDatabaseRepository = readServiceDatabaseRepository;
            _baseNoSqlReadRepository = baseNoSqlReadRepository;
        }

        public async Task<TransferGetQueryResponse> Handle(TransferGetQueryRequest request, CancellationToken cancellationToken)
        {
            ServiceDatabase? service = _readServiceDatabaseRepository.Get(service => service.AppName == request.AppName);
            if (service == null)
                return new TransferGetQueryResponse() { Data = null, Status = true, Message = ResultMessages.ServiceDatabaseNotFound };

            _baseNoSqlReadRepository.SetDatabase(service.DatabaseName);
            _baseNoSqlReadRepository.SetCollection(service.CollentionName);
            BsonDocument? bson =  _baseNoSqlReadRepository.Get(request.Id);
            if (bson != null)
            {
                string data = bson.ToJson().Replace("ObjectId(","").Replace("\"),", "\",");
                return new TransferGetQueryResponse() { Data = data, Status = true, Message = ResultMessages.GetSuccessTransferMessage };
            }
            return new TransferGetQueryResponse() { Data = null, Status = true, Message = ResultMessages.GetErrorTransferMessage };

        }

    }
}
