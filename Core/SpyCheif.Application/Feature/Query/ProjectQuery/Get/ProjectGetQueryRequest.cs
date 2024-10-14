using MediatR;

namespace SpyCheif.Application.Feature.Query.ProjectQuery.Get
{
    public class ProjectGetQueryRequest:IRequest<ProjectGetQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
