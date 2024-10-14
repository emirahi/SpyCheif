using MediatR;
using MongoDB.Bson;
using SpyCheif.Application.BaseNosql;
using SpyCheif.Application.Constants;
using SpyCheif.Application.Repository.ServiceDatabaseRepo;
using SpyCheif.Domain.Entity;

namespace SpyCheif.Application.Feature.Query.TransferQuery.GetAll
{
    public class TransferGetAllQueryHandler : IRequestHandler<TransferGetAllQueryRequest, TransferGetAllQueryResponse>
    {
        private readonly IReadServiceDatabaseRepository _readServiceDatabaseRepository;
        private readonly IBaseNoSqlReadRepository _baseNoSqlReadRepository;
        public TransferGetAllQueryHandler(
            IReadServiceDatabaseRepository readServiceDatabaseRepository,
            IBaseNoSqlReadRepository baseNoSqlReadRepository)
        {
            _readServiceDatabaseRepository = readServiceDatabaseRepository;
            _baseNoSqlReadRepository = baseNoSqlReadRepository;
        }

        public async Task<TransferGetAllQueryResponse> Handle(TransferGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            ServiceDatabase? service = _readServiceDatabaseRepository.Get(service => service.AppName == request.AppName);
            if (service == null)
                return new TransferGetAllQueryResponse() { Datas = null, Status = false, Message = ResultMessages.ServiceDatabaseNotFound };

            _baseNoSqlReadRepository.SetDatabase(service.DatabaseName);
            _baseNoSqlReadRepository.SetCollection(service.CollentionName);
            List<BsonDocument> bsons = _baseNoSqlReadRepository.GetAll();
            if (bsons.Count > 0)
            {
                string datas = bsons.ToJson().Replace("ObjectId(","").Replace("\"),","\",");
                return new TransferGetAllQueryResponse() { Datas = datas, Status = true, Message = ResultMessages.GetAllSuccessTransferMessage };
            }
            return new TransferGetAllQueryResponse() { Datas = null, Status = false, Message = ResultMessages.GetAllErrorTransferMessage };

        }
    }
}
