using MediatR;
using SpyCheif.Application.Repository.FileStorageRepo;
using SpyCheif.Application.Utils.Storage;
using SpyCheif.Domain.Entity;

namespace SpyCheif.Application.Feature.Command.TransferCommand.FileDelete
{
    public class TransferFileDeleteHandler : IRequestHandler<TransferFileDeleteRequest, TransferFileDeleteResponse>
    {
        private readonly IFileStorage _fileStorage;
        private readonly IWriteFileStorageRepository _writeFileStorageRepository;
        public TransferFileDeleteHandler(
            IWriteFileStorageRepository writeFileStorageRepository,
            IFileStorage fileStorage)
        {
            _writeFileStorageRepository = writeFileStorageRepository;
            _fileStorage = fileStorage;
        }

        public async Task<TransferFileDeleteResponse> Handle(TransferFileDeleteRequest request, CancellationToken cancellationToken)
        {
            FileStorage? storage = _writeFileStorageRepository.Delete(request.FileId);
            if (storage != null)
            {
                if (File.Exists(storage.FileName))
                {
                    File.Delete(storage.LocalPath);
                }
                return new() { Status = true, Message = "Dosya Silindi" };
            }
            return new() { Status = false, Message = "Dosya Silinirken Hata Oluştu" };

        }
    }
}
