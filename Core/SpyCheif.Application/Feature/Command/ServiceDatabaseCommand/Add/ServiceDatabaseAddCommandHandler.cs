using MediatR;
using SpyCheif.Application.Constants;
using SpyCheif.Application.Repository.ServiceDatabaseRepo;
using SpyCheif.Domain.Entity;

namespace SpyCheif.Application.Feature.Command.ServiceDatabaseCommand.Add
{
    public class ServiceDatabaseAddCommandHandler : IRequestHandler<ServiceDatabaseAddCommandRequest, ServiceDatabaseAddCommandResponse>
    {
        private readonly IWriteServiceDatabaseRepository _writeServiceDatabaseRepository;
        public ServiceDatabaseAddCommandHandler(IWriteServiceDatabaseRepository writeServiceDatabaseRepository)
        {
            _writeServiceDatabaseRepository = writeServiceDatabaseRepository;
        }

        public async Task<ServiceDatabaseAddCommandResponse> Handle(ServiceDatabaseAddCommandRequest request, CancellationToken cancellationToken)
        {
            ServiceDatabase service = _writeServiceDatabaseRepository.Add(new()
            { AppName = request.AppName, DatabaseName = request.DatabaseName, CollentionName = request.CollentionName });
            int savedCount = _writeServiceDatabaseRepository.saveChanges();
            if (savedCount > 0)
                return new ServiceDatabaseAddCommandResponse() { ServiceDatabase = service, Status = true, Message = ResultMessages.AddSuccessServiceDatabaseMessage };

            return new ServiceDatabaseAddCommandResponse() { ServiceDatabase = null, Status = false, Message = ResultMessages.AddErrorServiceDatabaseMessage };

        }

    }
}
