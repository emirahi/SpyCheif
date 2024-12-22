using MediatR;
using Microsoft.AspNetCore.Http;
using SpyCheif.Application.Dto.FileStorage;
using SpyCheif.Application.Enum;
using SpyCheif.Application.Repository.FileStorageRepo;
using SpyCheif.Application.Utils.Storage;
using SpyCheif.Domain.Entity;

namespace SpyCheif.Application.Feature.Command.TransferCommand.FileUpload
{
    public class TransferFileUploadHandler : IRequestHandler<TransferFileUploadRequest, TransferFileUploadResponse>
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly IFileStorage _fileStorage;
        private readonly IWriteFileStorageRepository _writeFileStorageRepository;
        public TransferFileUploadHandler(
            IHttpContextAccessor httpContext, IFileStorage fileStorage,
            IWriteFileStorageRepository writeFileStorageRepository)
        {
            _httpContext = httpContext;
            _fileStorage = fileStorage;
            _writeFileStorageRepository = writeFileStorageRepository;
        }

        public async Task<TransferFileUploadResponse> Handle(TransferFileUploadRequest request, CancellationToken cancellationToken)
        {
            string host = _httpContext.HttpContext.Request.Host.Host;
            FileUploadDto? result = _fileStorage.Upload(request.file, host);
            if (result == null)
                return new() { Status = false, Message = "Dosya Yüklenemedi" };

            FileStorage storage = await _writeFileStorageRepository.AddAsync(new() { 
                UniqName = result.UniqName,
                FileName = result.FileName,
                FileType = result.FileType.ToString(),
                LocalPath = result.LocalPath,
                RemotePath = result.RemotePath,
            });
            int saveChanged = _writeFileStorageRepository.saveChanges();
            if (saveChanged < 1)
            {
                File.Delete(result.LocalPath);
                return new() { Status = false, Message = "Dosya Kayıt Edilemedi" };
            }

            if (result.FileType == FileTypeEnum.JSON)
            {
                string? readed = _fileStorage.StreamFullRead(result.LocalPath);
                if (readed == null)
                    return new() { Status = false, Message = "Dosya Okunamadı" };

                List<string> keys = _fileStorage.GetJsonKeys(readed).ToList();
                var values = _fileStorage.ReadToJson(readed, 10);
                return new() { FileId = storage.Id, keys = keys, values = values, Status = true, Message = "Json Dosyası Okundu." };
            }
            else if (result.FileType == FileTypeEnum.CSV)
            {
                var results = _fileStorage.ReadToCsv(result.LocalPath, ","); 
                return new() { FileId = storage.Id, Status = true, values = results, Message = "Text Dosyası Yüklendi ve Okundu." };
            }
            else if (result.FileType == FileTypeEnum.TEXT)
            {
                List<string> textList = _fileStorage.StreamFullRead(result.LocalPath, 10);
                return new() { FileId = storage.Id, Status = true, values = textList, Message = "Text Dosyası Yüklendi ve Okundu." };
            }
            return new() { Status = false, Message = "" };

        }
    }
}
