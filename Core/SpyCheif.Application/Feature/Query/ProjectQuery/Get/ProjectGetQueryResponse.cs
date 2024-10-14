using SpyCheif.Application.Dto.ProjectDtos;
using SpyCheif.Application.Feature.Base;

namespace SpyCheif.Application.Feature.Query.ProjectQuery.Get
{
    public class ProjectGetQueryResponse : BaseResponse
    {
        public ProjectDto Project { get; set; }
    }
}
