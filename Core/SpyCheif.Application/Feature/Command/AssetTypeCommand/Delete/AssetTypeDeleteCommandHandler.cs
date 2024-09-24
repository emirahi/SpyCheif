using MediatR;
using SpyCheif.Application.Constants;
using SpyCheif.Application.Repository.AssetTypeRepo;
using SpyCheif.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Application.Feature.Command.AssetTypeCommand.Delete
{
    public class AssetTypeDeleteCommandHandler : IRequestHandler<AssetTypeDeleteCommandRequest, AssetTypeDeleteCommandResponse>
    {
        private readonly IWriteAssetTypeRepository _writeAssetTypeRepository;
        private readonly IReadAssetTypeRepository _readAssetTypeRepository;
        public AssetTypeDeleteCommandHandler(
            IWriteAssetTypeRepository writeAssetTypeRepository,
            IReadAssetTypeRepository readAssetTypeRepository)
        {
            _writeAssetTypeRepository = writeAssetTypeRepository;
            _readAssetTypeRepository = readAssetTypeRepository;
        }

        public async Task<AssetTypeDeleteCommandResponse> Handle(AssetTypeDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            AssetType? assetType = _readAssetTypeRepository.Get(request.Id);
            if (assetType == null)
                return new AssetTypeDeleteCommandResponse() { Status = false, Message = ResultMessages.AssetTypeNotFound };

            _writeAssetTypeRepository.Delete(request.Id);
            int savedCount = _writeAssetTypeRepository.saveChanges();
            if (savedCount > 0)
                return new AssetTypeDeleteCommandResponse() { Status = true, Message = ResultMessages.DeleteSuccessAssetMessage };
            return new AssetTypeDeleteCommandResponse() { Status = false, Message = ResultMessages.DeleteErrorAssetTypeMessage };

        }
    }
}
