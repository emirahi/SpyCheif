using MediatR;
using SpyCheif.Application.Dto.FileStorage;
using SpyCheif.Application.Repository.FileStorageRepo;
using SpyCheif.Domain.Entity;

namespace SpyCheif.Application.Feature.Query.TransferQuery.GetFiles
{
    public class TransferGetFilesHandler : IRequestHandler<TransferGetFilesRequest, TransferGetFilesResponse>
    {
        private readonly IReadFileStorageRepository _readFileStorageRepository;
        public TransferGetFilesHandler(IReadFileStorageRepository readFileStorageRepository)
        {
            _readFileStorageRepository = readFileStorageRepository;
        }

        public async Task<TransferGetFilesResponse> Handle(TransferGetFilesRequest request, CancellationToken cancellationToken)
        {
            List<FileStorage> fileStorages = _readFileStorageRepository.GetAll().ToList();
            if (fileStorages.Count > 0)
            {
                List<FileUploadResultDto> fileUploadResultDto = fileStorages.Select(file => new FileUploadResultDto()
                {
                    Id = file.Id,
                    FileName = file.FileName,
                    RemotePath = file.RemotePath,
                    UniqName = file.UniqName,
                    CreatedDate = file.CreatedDate,
                    UpdatedDate = file.UpdatedDate,
                    IsActive = file.IsActive
                }).ToList();
                return new() { Status = true, files = fileUploadResultDto, Message = "" };
            }
            return new() { Status = false, Message = "" };
        }
    }
}
