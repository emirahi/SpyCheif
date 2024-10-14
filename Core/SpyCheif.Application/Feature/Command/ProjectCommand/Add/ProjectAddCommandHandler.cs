using AutoMapper;
using MediatR;
using SpyCheif.Application.Constants;
using SpyCheif.Application.Dto.ProjectDtos;
using SpyCheif.Application.Repository.ProjectRepo;
using SpyCheif.Domain.Entity;

namespace SpyCheif.Application.Feature.Command.ProjectCommand.Add
{
    public class ProjectAddCommandHandler : IRequestHandler<ProjectAddCommandRequest, ProjectAddCommandResponse>
    {
        public IWriteProjectRepository _writeProjectRepository { get; set; }
        public IMapper _mapper { get; set; }
        public ProjectAddCommandHandler(
            IWriteProjectRepository writeProjectRepository,
            IMapper mapper)
        {
            _writeProjectRepository = writeProjectRepository;
            _mapper = mapper;
        }

        public async Task<ProjectAddCommandResponse> Handle(ProjectAddCommandRequest request, CancellationToken cancellationToken)
        {
            Project castProject = _mapper.Map<Project>(request);
            Project project = _writeProjectRepository.Add(castProject);
            ProjectDto returnedProject = _mapper.Map<ProjectDto>(project);

            int saveChanges = _writeProjectRepository.saveChanges();
            if (saveChanges > 0)
            {
                return new ProjectAddCommandResponse() { Project = returnedProject, Status = true, Message = ResultMessages.AddSuccessProjectMessage };
            }
            return new ProjectAddCommandResponse() { Project = null, Status = false, Message = ResultMessages.AddErrorProjectMessage };

        }

    }
}
