using MediatR;
using SpyCheif.Application.Dto.FileStorage;
using SpyCheif.Application.Repository.FileStorageRepo;
using SpyCheif.Domain.Entity;

namespace SpyCheif.Application.Feature.Query.TransferQuery.GetFile
{
    public class TransferGetFileHandler : IRequestHandler<TransferGetFileRequest, TransferGetFileResponse>
    {
        private readonly IReadFileStorageRepository _readFileStorageRepository;
        public TransferGetFileHandler(IReadFileStorageRepository readFileStorageRepository)
        {
            _readFileStorageRepository = readFileStorageRepository;
        }

        public async Task<TransferGetFileResponse> Handle(TransferGetFileRequest request, CancellationToken cancellationToken)
        {
            FileStorage? storage = _readFileStorageRepository.Get(request.FileId);
            if (storage != null)
            {
                FileUploadResultDto file = new()
                {
                    Id = storage.Id,
                    FileName = storage.FileName,
                    RemotePath = storage.RemotePath,
                    UniqName = storage.UniqName,
                    IsActive = storage.IsActive,
                    CreatedDate = storage.CreatedDate,
                    UpdatedDate = storage.UpdatedDate
                };
                return new() {Status = true, file = file, Message = "" };
            }
            return new() { Status = false, Message = "" };
        }
    }
}
