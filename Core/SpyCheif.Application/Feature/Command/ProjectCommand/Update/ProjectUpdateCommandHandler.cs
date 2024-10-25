using AutoMapper;
using MediatR;
using SpyCheif.Application.Constants;
using SpyCheif.Application.Dto.ProjectDtos;
using SpyCheif.Application.Repository.ProjectRepo;
using SpyCheif.Domain.Entity;

namespace SpyCheif.Application.Feature.Command.ProjectCommand.Update
{
    public class ProjectUpdateCommandHandler : IRequestHandler<ProjectUpdateCommandRequest, ProjectUpdateCommandResponse>
    {
        private IReadProjectRepository _readProjectRepository;
        private IWriteProjectRepository _writeProjectRepository;
        private IMapper _mapper;
        public ProjectUpdateCommandHandler(
            IReadProjectRepository readProjectRepository,
            IWriteProjectRepository writeProjectRepository,
            IMapper mapper)
        {
            _readProjectRepository = readProjectRepository;
            _writeProjectRepository = writeProjectRepository;
            _mapper = mapper;
        }

        public async Task<ProjectUpdateCommandResponse> Handle(ProjectUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            Project? project = _readProjectRepository.Get(request.Id);
            if (project != null)
            {
                project.ProjectName = request.ProjectName;
                project.Description = request.Description;
                _writeProjectRepository.Update(project);
                int saveCahnges = _writeProjectRepository.saveChanges();
                if (saveCahnges > 0)
                {
                    ProjectDto projectDto = _mapper.Map<ProjectDto>(project);
                    return new() { Project = projectDto, Status = true, Message = ResultMessages.UpdateSuccessProjectMessage };
                }
                return new() { Project = null, Status = false, Message = ResultMessages.UpdateSaveFailedProjectMessage };
            }
            return new() { Project = null, Status = false, Message = ResultMessages.UpdateErrorProjectMessage };
        }
    }
}
