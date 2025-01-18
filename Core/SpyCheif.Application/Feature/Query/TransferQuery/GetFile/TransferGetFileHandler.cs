using MediatR;
using SpyCheif.Application.Dto.FileStorage;
using SpyCheif.Application.Enum;
using SpyCheif.Application.Repository.FileStorageRepo;
using SpyCheif.Application.Utils.Storage;
using SpyCheif.Domain.Entity;

namespace SpyCheif.Application.Feature.Query.TransferQuery.GetFile
{
    public class TransferGetFileHandler : IRequestHandler<TransferGetFileRequest, TransferGetFileResponse>
    {
        private readonly IReadFileStorageRepository _readFileStorageRepository;
        private readonly IFileStorage _fileStorage;
        public TransferGetFileHandler(IReadFileStorageRepository readFileStorageRepository, IFileStorage fileStorage)
        {
            _readFileStorageRepository = readFileStorageRepository;
            _fileStorage = fileStorage;
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
                    UpdatedDate = storage.UpdatedDate,

                };

                if (storage.FileType == FileTypeEnum.JSON.ToString())
                {
                    string? readed = _fileStorage.StreamFullRead(storage.LocalPath);
                    if (readed == null)
                        return new() { Status = false, Message = "Dosya Okunamadı" };

                    List<string> keys = _fileStorage.GetJsonKeys(readed).ToList();
                    var values = _fileStorage.ReadToJson(readed, 10);
                    return new() { file = file, keys = keys, values = values, Status = true, Message = "Json Dosyası Okundu." };
                }
                else if (storage.FileType == FileTypeEnum.CSV.ToString())
                {
                    var storages = _fileStorage.ReadCsv(storage.LocalPath, 10, ",");
                    return new() { file = file, Status = true, values = storages, Message = "Text Dosyası Okundu." };
                }
                else if (storage.FileType == FileTypeEnum.TEXT.ToString())
                {
                    List<string> textList = _fileStorage.StreamFullRead(storage.LocalPath, 10);
                    return new() { file = file, Status = true, values = textList, Message = "Text Dosyası Okundu." };
                }
            }
            return new() { Status = false, Message = "" };
        }
    }
}
