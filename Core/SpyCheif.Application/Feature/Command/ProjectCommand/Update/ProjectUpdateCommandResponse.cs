using SpyCheif.Application.Dto.ProjectDtos;
using SpyCheif.Application.Feature.Base;

namespace SpyCheif.Application.Feature.Command.ProjectCommand.Update
{
    public class ProjectUpdateCommandResponse : BaseResponse
    {
        public ProjectDto Project { get; set; }
    }
}
