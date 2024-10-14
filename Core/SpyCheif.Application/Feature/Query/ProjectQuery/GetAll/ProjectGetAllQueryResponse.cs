using SpyCheif.Application.Dto.ProjectDtos;
using SpyCheif.Application.Feature.Base;

namespace SpyCheif.Application.Feature.Query.ProjectQuery.GetAll
{
    public class ProjectGetAllQueryResponse : BaseResponse
    {
        public List<ProjectDto> Project { get; set; }
    }
}
