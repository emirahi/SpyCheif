using MediatR;
using SpyCheif.Application.Constants;
using SpyCheif.Application.Repository.ProjectRepo;
using SpyCheif.Domain.Entity;

namespace SpyCheif.Application.Feature.Command.ProjectCommand.Delete
{
    public class ProjectDeleteCommandHandler : IRequestHandler<ProjectDeleteCommandRequest, ProjectDeleteCommandResponse>
    {
        private IReadProjectRepository _readProjectRepository;
        private IWriteProjectRepository _writeProjectRepository;
        public ProjectDeleteCommandHandler(
            IReadProjectRepository readProjectRepository,
            IWriteProjectRepository writeProjectRepository)
        {
            _readProjectRepository = readProjectRepository;
            _writeProjectRepository = writeProjectRepository;
        }

        public async Task<ProjectDeleteCommandResponse> Handle(ProjectDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            Project? project = _writeProjectRepository.Delete(request.Id);
            int saveChanges = _writeProjectRepository.saveChanges();
            if (saveChanges > 0)
            {
                return new ProjectDeleteCommandResponse() { Status = true, Message = ResultMessages.DeleteSuccessProjectMessage };
            }
            return new ProjectDeleteCommandResponse() { Status = false, Message = ResultMessages.DeleteErrorProjectMessage };
        }
    }
}
