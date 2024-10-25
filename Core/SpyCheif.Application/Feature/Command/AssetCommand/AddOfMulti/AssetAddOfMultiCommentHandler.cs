using AutoMapper;
using Hangfire;
using MediatR;
using SpyCheif.Application.BackgroundJob;
using SpyCheif.Application.Constants;
using SpyCheif.Application.Repository.AssetRepo;
using SpyCheif.Application.Repository.AssetTypeRepo;
using SpyCheif.Application.Repository.ProjectRepo;
using SpyCheif.Domain.Entity;

namespace SpyCheif.Application.Feature.Command.AssetCommand.AddOfMulti
{
    public class AssetAddOfMultiCommentHandler : IRequestHandler<AssetAddOfMultiCommandRequest, AssetAddOfMultiCommandResponse>
    {
        private IWriteAssetRepository _writeAssetRepository;
        private IReadAssetTypeRepository _readAssetTypeRepository;
        private IReadProjectRepository _readProjectRepository;
        private IMapper _mapper;
        public AssetAddOfMultiCommentHandler(
            IWriteAssetRepository writeAssetRepository,
            IReadAssetTypeRepository readAssetTypeRepository,
            IReadProjectRepository readProjectRepository,
            IMapper mapper)
        {
            _writeAssetRepository = writeAssetRepository;
            _readAssetTypeRepository = readAssetTypeRepository;
            _readProjectRepository = readProjectRepository;
            _mapper = mapper;
        }

        public async Task<AssetAddOfMultiCommandResponse> Handle(AssetAddOfMultiCommandRequest request, CancellationToken cancellationToken)
        {
            AssetType? assetType = _readAssetTypeRepository.Get(request.AssetTypeId);
            if (assetType == null)
                return new AssetAddOfMultiCommandResponse { Status = false, Message = ResultMessages.AssetTypeNotFound };

            Project? project = _readProjectRepository.Get(request.ProjectId);
            if (project == null)
                return new AssetAddOfMultiCommandResponse() { Status = false, Message = ResultMessages.ProjectNotFound };

            List<Asset> assets = request.Value.Select(value => new Asset()
            {
                ProjectId = request.ProjectId,
                AssetTypeId = request.AssetTypeId,
                Value = value
            }).ToList();
            string data = new BackgroundJobClient().Enqueue<IAssetBackground>(assetBg => assetBg.Add(assets));
            return new() { Status = true, Message = ResultMessages.AddOfMultiSuccessAssetMessage };

        }
    }
}
