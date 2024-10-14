using MediatR;

namespace SpyCheif.Application.Feature.Command.ProjectCommand.Add
{
    public class ProjectAddCommandRequest:IRequest<ProjectAddCommandResponse>
    {
        public string ProjectName { get; set; }
        public string? Description { get; set; }

    }
}
