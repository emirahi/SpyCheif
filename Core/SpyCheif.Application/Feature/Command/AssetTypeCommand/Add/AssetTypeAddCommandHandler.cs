using MediatR;
using SpyCheif.Application.Constants;
using SpyCheif.Application.Repository.AssetTypeRepo;
using SpyCheif.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Application.Feature.Command.AssetTypeCommand.Add
{
    public class AssetTypeAddCommandHandler : IRequestHandler<AssetTypeAddCommandRequest, AssetTypeAddCommandResponse>
    {
        private readonly IWriteAssetTypeRepository _assetTypeWriteRepository;
        public AssetTypeAddCommandHandler(IWriteAssetTypeRepository assetTypeWriteRepository)
        {
            _assetTypeWriteRepository = assetTypeWriteRepository;
        }

        public async Task<AssetTypeAddCommandResponse> Handle(AssetTypeAddCommandRequest request, CancellationToken cancellationToken)
        {
            AssetType type = await _assetTypeWriteRepository.AddAsync(new() { Type = request.TypeName });
            int savedCount = _assetTypeWriteRepository.saveChanges();
            if (savedCount > 0)
                return new AssetTypeAddCommandResponse() { AssetType = type, Status = true, Message = ResultMessages.AddSuccessAssetTypeMessage };
            return new AssetTypeAddCommandResponse() { AssetType = null, Status = false, Message = ResultMessages.AddErrorAssetTypeMessage };

        }

    }
}
