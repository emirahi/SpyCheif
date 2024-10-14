using MediatR;

namespace SpyCheif.Application.Feature.Command.ProjectCommand.Update
{
    public class ProjectUpdateCommandRequest:IRequest<ProjectUpdateCommandResponse>
    {
        public Guid Id { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
    }
}
