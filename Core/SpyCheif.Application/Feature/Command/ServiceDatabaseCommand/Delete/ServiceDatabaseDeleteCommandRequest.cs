using MediatR;

namespace SpyCheif.Application.Feature.Command.ServiceDatabaseCommand.Delete
{
    public class ServiceDatabaseDeleteCommandRequest:IRequest<ServiceDatabaseDeleteCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
