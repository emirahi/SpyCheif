using SpyCheif.Application.Dto.ProjectDtos;
using SpyCheif.Application.Feature.Base;

namespace SpyCheif.Application.Feature.Command.ProjectCommand.Add
{
    public class ProjectAddCommandResponse : BaseResponse
    {
        public ProjectDto Project { get; set; }
    }
}
