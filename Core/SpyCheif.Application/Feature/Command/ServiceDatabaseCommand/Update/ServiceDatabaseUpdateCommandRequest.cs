using MediatR;

namespace SpyCheif.Application.Feature.Command.ServiceDatabaseCommand.Update
{
    public class ServiceDatabaseUpdateCommandRequest:IRequest<ServiceDatabaseUpdateCommandResponse>
    {
        public Guid Id { get; set; }
        public string AppName { get; set; }
        public string DatabaseName { get; set; }
        public string CollectionName { get; set; }
    }
}
