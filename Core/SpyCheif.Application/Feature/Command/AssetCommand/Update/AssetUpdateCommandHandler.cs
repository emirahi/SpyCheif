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

namespace SpyCheif.Application.Feature.Command.AssetCommand.Update
{
    public class AssetUpdateCommandHandler : IRequestHandler<AssetUpdateCommandRequest, AssetUpdateCommandResponse>
    {
        private IWriteAssetRepository _writeAssetRepository;
        private IReadAssetRepository _readAssetRepository;
        private IReadAssetTypeRepository _readAssetTypeRepository;
        public AssetUpdateCommandHandler(
            IWriteAssetRepository writeAssetRepository,
            IReadAssetRepository readAssetRepository,
            IReadAssetTypeRepository readAssetTypeRepository)
        {
            _writeAssetRepository = writeAssetRepository;
            _readAssetRepository = readAssetRepository;
            _readAssetTypeRepository = readAssetTypeRepository;
        }

        public async Task<AssetUpdateCommandResponse> Handle(AssetUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            AssetType? assetType = _readAssetTypeRepository.Get(request.AssetTypeId);
            if (assetType == null)
                return new AssetUpdateCommandResponse() { Status = false, Message = ResultMessages.AssetTypeNotFound };

            Asset? readed = _readAssetRepository.Get(request.Id);
            if (readed != null)
            {
                readed.Value = request.Value;
                readed.AssetTypeId = assetType.Id;
                int saveChanges = _writeAssetRepository.saveChanges();
                if (saveChanges > 0)
                    return new AssetUpdateCommandResponse() { Status = true, Message = ResultMessages.UpdateSuccessAssetMessage };
                return new AssetUpdateCommandResponse() { Status = false, Message = ResultMessages.UpdateSaveFailedAssetMessage };
            }
            return new AssetUpdateCommandResponse() { Status = false, Message = ResultMessages.UpdateErrorAssetMessage};
        }


    }
}
