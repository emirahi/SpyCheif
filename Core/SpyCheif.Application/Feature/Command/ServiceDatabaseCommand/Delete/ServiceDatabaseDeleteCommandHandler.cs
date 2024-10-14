using MediatR;
using SpyCheif.Application.Constants;
using SpyCheif.Application.Repository.ServiceDatabaseRepo;
using SpyCheif.Domain.Entity;

namespace SpyCheif.Application.Feature.Command.ServiceDatabaseCommand.Delete
{
    public class ServiceDatabaseDeleteCommandHandler : IRequestHandler<ServiceDatabaseDeleteCommandRequest, ServiceDatabaseDeleteCommandResponse>
    {
        private readonly IWriteServiceDatabaseRepository _writeServiceDatabaseRepository;
        private readonly IReadServiceDatabaseRepository _readServiceDatabaseRepository;
        public ServiceDatabaseDeleteCommandHandler(
            IWriteServiceDatabaseRepository writeServiceDatabaseRepository,
            IReadServiceDatabaseRepository readServiceDatabaseRepository)
        {
            _writeServiceDatabaseRepository = writeServiceDatabaseRepository;
            _readServiceDatabaseRepository = readServiceDatabaseRepository;
        }

        public async Task<ServiceDatabaseDeleteCommandResponse> Handle(ServiceDatabaseDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            ServiceDatabase? service = _readServiceDatabaseRepository.Get(request.Id);
            if (service == null)
                return new ServiceDatabaseDeleteCommandResponse() { Status = false, Message = ResultMessages.ServiceDatabaseNotFound };

            _writeServiceDatabaseRepository.Delete(request.Id);
            int savedCount = _writeServiceDatabaseRepository.saveChanges();
            if (savedCount > 0)
                return new ServiceDatabaseDeleteCommandResponse() { Status = true, Message = ResultMessages.DeleteSuccessServiceDatabaseMessage };
            return new ServiceDatabaseDeleteCommandResponse() { Status = false, Message = ResultMessages.DeleteErrorServiceDatabaseMessage };
        }
    }
}
