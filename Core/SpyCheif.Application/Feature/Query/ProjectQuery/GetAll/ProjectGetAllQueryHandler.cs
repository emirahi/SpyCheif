using AutoMapper;
using MediatR;
using SpyCheif.Application.Constants;
using SpyCheif.Application.Dto.ProjectDtos;
using SpyCheif.Application.Repository.ProjectRepo;
using SpyCheif.Domain.Entity;

namespace SpyCheif.Application.Feature.Query.ProjectQuery.GetAll
{
    public class ProjectGetAllQueryHandler : IRequestHandler<ProjectGetAllQueryRequest, ProjectGetAllQueryResponse>
    {
        private IReadProjectRepository _readProjectRepository;
        private IMapper _mapper;
        public ProjectGetAllQueryHandler(
            IReadProjectRepository readProjectRepository,
            IMapper mapper)
        {
            _readProjectRepository = readProjectRepository;
            _mapper = mapper;
        }

        public async Task<ProjectGetAllQueryResponse> Handle(ProjectGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            List<Project> projects = _readProjectRepository.GetAll().ToList();
            if (projects.Count > 0)
            {
                List<ProjectDto> projectDtos = _mapper.Map<List<ProjectDto>>(projects);
                return new() { Project = projectDtos, Status = true, Message = ResultMessages.GetAllSuccessProjectMessage };
            }
            return new() { Project = null, Status = false, Message = ResultMessages.GetAllErrorProjectMessage };

        }
    }
}
