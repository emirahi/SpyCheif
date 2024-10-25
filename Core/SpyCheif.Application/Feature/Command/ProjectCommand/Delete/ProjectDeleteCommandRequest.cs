using MediatR;

namespace SpyCheif.Application.Feature.Command.ProjectCommand.Delete
{
    public class ProjectDeleteCommandRequest : IRequest<ProjectDeleteCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
