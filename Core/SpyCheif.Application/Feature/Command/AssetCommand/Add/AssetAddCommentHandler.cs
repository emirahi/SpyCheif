using MediatR;
using SpyCheif.Application.Constants;
using SpyCheif.Application.Repository.AssetRepo;
using SpyCheif.Application.Repository.AssetTypeRepo;
using SpyCheif.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Application.Feature.Command.AssetCommand.Add
{
    public class AssetAddCommentHandler : IRequestHandler<AssetAddCommandRequest, AssetAddCommandResponse>
    {
        private IWriteAssetRepository _writeAssetRepository;
        private IReadAssetTypeRepository _readAssetTypeRepository;
        public AssetAddCommentHandler(
            IWriteAssetRepository writeAssetRepository,
            IReadAssetTypeRepository readAssetTypeRepository)
        {
            _writeAssetRepository = writeAssetRepository;
            _readAssetTypeRepository = readAssetTypeRepository;
        }

        public async Task<AssetAddCommandResponse> Handle(AssetAddCommandRequest request, CancellationToken cancellationToken)
        {
            AssetType? assetType = _readAssetTypeRepository.Get(request.AssetTypeId);
            if (assetType == null)
                return new AssetAddCommandResponse { Asset = null, Status = false, Message = ResultMessages.AssetTypeNotFound };

            Asset asset = await _writeAssetRepository.AddAsync(new() { AssetTypeId = request.AssetTypeId, Value = request.Value });
            int isSaved = _writeAssetRepository.saveChanges();

            if (asset != null && isSaved > 0)
                return new AssetAddCommandResponse()
                {
                    Asset = asset,
                    Status = true,
                    Message = ResultMessages.AddSuccessAssetMessage
                };

            return new AssetAddCommandResponse()
            {
                Status = false,
                Message = ResultMessages.AddErrorAssetMessage,
                Asset = null
            };
        }
    }
}
