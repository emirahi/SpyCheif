using MediatR;
using SpyCheif.Application.Constants;
using SpyCheif.Application.Repository.ServiceDatabaseRepo;
using SpyCheif.Domain.Entity;

namespace SpyCheif.Application.Feature.Command.ServiceDatabaseCommand.Update
{
    public class ServiceDatabaseUpdateCommandHandler : IRequestHandler<ServiceDatabaseUpdateCommandRequest, ServiceDatabaseUpdateCommandResponse>
    {
        private readonly IWriteServiceDatabaseRepository _writeServiceDatabaseRepository;
        private readonly IReadServiceDatabaseRepository _readServiceDatabaseRepository;
        public ServiceDatabaseUpdateCommandHandler(
            IWriteServiceDatabaseRepository writeServiceDatabaseRepository,
            IReadServiceDatabaseRepository readServiceDatabaseRepository)
        {
            _writeServiceDatabaseRepository = writeServiceDatabaseRepository; 
            _readServiceDatabaseRepository = readServiceDatabaseRepository;
        }

        public async Task<ServiceDatabaseUpdateCommandResponse> Handle(ServiceDatabaseUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            ServiceDatabase? service = _readServiceDatabaseRepository.Get(request.Id);
            if (service == null)
                return new ServiceDatabaseUpdateCommandResponse() { Status = false, Message = ResultMessages.ServiceDatabaseNotFound };

            service.AppName = request.AppName;
            service.DatabaseName = request.DatabaseName;
            service.CollentionName = request.CollectionName;

            ServiceDatabase serviceDatabase = _writeServiceDatabaseRepository.Update(service);
            int savedCount = _writeServiceDatabaseRepository.saveChanges();

            if (savedCount > 0)
                return new ServiceDatabaseUpdateCommandResponse() {serviceDatabase = serviceDatabase, Status = true, Message = ResultMessages.UpdateSuccessServiceDatabaseMessage };
            return new ServiceDatabaseUpdateCommandResponse() { Status = false, Message = ResultMessages.UpdateErrorServiceDatabaseMessage };


        }
    }
}
