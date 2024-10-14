using AutoMapper;
using MediatR;
using SpyCheif.Application.Constants;
using SpyCheif.Application.Dto.AssetDtos;
using SpyCheif.Application.Repository.AssetRepo;
using SpyCheif.Application.Repository.AssetTypeRepo;
using SpyCheif.Domain.Entity;

namespace SpyCheif.Application.Feature.Command.AssetCommand.Update
{
    public class AssetUpdateCommandHandler : IRequestHandler<AssetUpdateCommandRequest, AssetUpdateCommandResponse>
    {
        private IWriteAssetRepository _writeAssetRepository;
        private IReadAssetRepository _readAssetRepository;
        private IReadAssetTypeRepository _readAssetTypeRepository;
        private IMapper _mapper;
        public AssetUpdateCommandHandler(
            IWriteAssetRepository writeAssetRepository,
            IReadAssetRepository readAssetRepository,
            IReadAssetTypeRepository readAssetTypeRepository,
            IMapper mapper)
        {
            _writeAssetRepository = writeAssetRepository;
            _readAssetRepository = readAssetRepository;
            _readAssetTypeRepository = readAssetTypeRepository;
            _mapper = mapper;
        }

        public async Task<AssetUpdateCommandResponse> Handle(AssetUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            AssetType? assetType = _readAssetTypeRepository.Get(request.AssetTypeId);
            if (assetType == null)
                return new AssetUpdateCommandResponse() { asset = null, Status = false, Message = ResultMessages.AssetTypeNotFound };

            Asset? readed = _readAssetRepository.Get(request.Id);
            if (readed != null)
            {
                readed.AssetTypeId = request.AssetTypeId;
                readed.Value = request.Value;
                int saveChanges = _writeAssetRepository.saveChanges();
                if (saveChanges > 0)
                {
                    AssetDto assetDto = _mapper.Map<AssetDto>(readed);
                    return new AssetUpdateCommandResponse() { asset = assetDto, Status = true, Message = ResultMessages.UpdateSuccessAssetMessage };
                }

                return new AssetUpdateCommandResponse() { asset = null, Status = false, Message = ResultMessages.UpdateSaveFailedAssetMessage };
            }
            return new AssetUpdateCommandResponse() { asset = null, Status = false, Message = ResultMessages.UpdateErrorAssetMessage};
        }


    }
}
