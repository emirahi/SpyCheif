using MediatR;

namespace SpyCheif.Application.Feature.Command.ServiceDatabaseCommand.Add
{
    public class ServiceDatabaseAddCommandRequest : IRequest<ServiceDatabaseAddCommandResponse>
    {
        public string AppName { get; set; }
        public string DatabaseName { get; set; }
        public string CollentionName { get; set; }
    }
}
