using AutoMapper;
using MediatR;
using SpyCheif.Application.Constants;
using SpyCheif.Application.Dto.ProjectDtos;
using SpyCheif.Application.Repository.ProjectRepo;
using SpyCheif.Domain.Entity;

namespace SpyCheif.Application.Feature.Query.ProjectQuery.Get
{
    public class ProjectGetQueryHandler : IRequestHandler<ProjectGetQueryRequest, ProjectGetQueryResponse>
    {
        private IReadProjectRepository _readProjectRepository;
        private IMapper _mapper;
        public ProjectGetQueryHandler(
            IReadProjectRepository readProjectRepository,
            IMapper mapper)
        {
            _readProjectRepository = readProjectRepository;
            _mapper = mapper;
        }

        public async Task<ProjectGetQueryResponse> Handle(ProjectGetQueryRequest request, CancellationToken cancellationToken)
        {
            Project? project = _readProjectRepository.Get(request.Id);
            if (project != null)
            {
                ProjectDto projectDto = _mapper.Map<ProjectDto>(project);
                return new() { Project = projectDto, Status = true, Message = ResultMessages.GetSuccessProjectMessage };
            }
            return new() { Project = null, Status = false, Message = ResultMessages.GetErrorProjectMessage };

        }
    }
}
