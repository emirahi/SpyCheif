using Hangfire;
using MediatR;
using SpyCheif.Application.BackgroundJob;
using SpyCheif.Application.Constants;
using SpyCheif.Application.Dto.AssetDtos;
using SpyCheif.Application.Enum;
using SpyCheif.Application.Repository.AssetTypeRepo;
using SpyCheif.Application.Repository.FileStorageRepo;
using SpyCheif.Application.Repository.ProjectRepo;
using SpyCheif.Domain.Entity;

namespace SpyCheif.Application.Feature.Command.AssetCommand.AddOfMulti
{
    public class AssetAddOfMultiCommentHandler : IRequestHandler<AssetAddOfMultiCommandRequest, AssetAddOfMultiCommandResponse>
    {
        private readonly IReadFileStorageRepository _readFileStorageRepository;
        private readonly IReadAssetTypeRepository _readAssetTypeRepository;
        private readonly IReadProjectRepository _readProjectRepository;
        public AssetAddOfMultiCommentHandler(
            IReadAssetTypeRepository readAssetTypeRepository,
            IReadProjectRepository readProjectRepository,
            IReadFileStorageRepository readFileStorageRepository)
        {
            _readAssetTypeRepository = readAssetTypeRepository;
            _readProjectRepository = readProjectRepository;
            _readFileStorageRepository = readFileStorageRepository;
        }

        public async Task<AssetAddOfMultiCommandResponse> Handle(AssetAddOfMultiCommandRequest request, CancellationToken cancellationToken)
        {
            AssetType? assetType = _readAssetTypeRepository.Get(request.AssetTypeId);
            if (assetType == null)
                return new AssetAddOfMultiCommandResponse { Status = false, Message = ResultMessages.AssetTypeNotFound };

            Project? project = _readProjectRepository.Get(request.ProjectId);
            if (project == null)
                return new AssetAddOfMultiCommandResponse() { Status = false, Message = ResultMessages.ProjectNotFound };

            FileStorage? storage = _readFileStorageRepository.Get(request.FileId);
            if (storage == null)
                return new AssetAddOfMultiCommandResponse() { Status = false, Message = ResultMessages.NotFoundFileStorage };

            FileAssetDto fileAssetDto = new FileAssetDto()
            {
                AssetTypeId = request.AssetTypeId,
                ProjectId = request.ProjectId,
                FileId = storage.Id,
                Path = storage.LocalPath,
                Key = request.Key,
                SingleListSeparator = request.SingleListSeparator
            };

            if (storage.FileType == FileTypeEnum.TEXT.ToString())
                fileAssetDto.FileType = FileTypeEnum.TEXT;
            else if (storage.FileType == FileTypeEnum.CSV.ToString())
                fileAssetDto.FileType = FileTypeEnum.CSV;
            else if (storage.FileType == FileTypeEnum.JSON.ToString())
                fileAssetDto.FileType = FileTypeEnum.JSON;
            else
                fileAssetDto.FileType = FileTypeEnum.None;

            string backgroundId = new BackgroundJobClient().Enqueue<IAssetBackground>(assetBg => assetBg.Add(fileAssetDto));

            return new() { Status = true, BackgroundId = backgroundId, Message = ResultMessages.AddOfMultiSuccessAssetMessage };

        }
    }
}
