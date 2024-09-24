using MediatR;
using SpyCheif.Application.Constants;
using SpyCheif.Application.Repository.AssetTypeRepo;
using SpyCheif.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Application.Feature.Command.AssetTypeCommand.Update
{
    public class AssetTypeUpdateCommandHandler : IRequestHandler<AssetTypeUpdateCommandRequest, AssetTypeUpdateCommandResponse>
    {
        private readonly IReadAssetTypeRepository _readAssetTypeRepository;
        private readonly IWriteAssetTypeRepository _writeAssetTypeRepository;
        public AssetTypeUpdateCommandHandler(
            IReadAssetTypeRepository readAssetTypeRepository,
            IWriteAssetTypeRepository writeAssetTypeRepository)
        {
            _readAssetTypeRepository = readAssetTypeRepository;
            _writeAssetTypeRepository = writeAssetTypeRepository;
        }
        public async Task<AssetTypeUpdateCommandResponse> Handle(AssetTypeUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            AssetType? type = _readAssetTypeRepository.Get(request.Id);
            if (type == null)
                return new AssetTypeUpdateCommandResponse() { Status = false, Message = ResultMessages.AssetTypeNotFound };

            type.Type = request.TypeName;
            int savedCount = _writeAssetTypeRepository.saveChanges();
            if (savedCount > 0)
                return new AssetTypeUpdateCommandResponse() { Status = true, Message = ResultMessages.UpdateSuccessAssetTypeMessage };

            return new AssetTypeUpdateCommandResponse() { Status = false, Message = ResultMessages.UpdateErrorAssetTypeMessage };
        }
    }
}
