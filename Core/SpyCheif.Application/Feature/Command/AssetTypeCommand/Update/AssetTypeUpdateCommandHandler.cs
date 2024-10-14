using AutoMapper;
using MediatR;
using SpyCheif.Application.Constants;
using SpyCheif.Application.Dto.AssetTypeDtos;
using SpyCheif.Application.Repository.AssetTypeRepo;
using SpyCheif.Domain.Entity;

namespace SpyCheif.Application.Feature.Command.AssetTypeCommand.Update
{
    public class AssetTypeUpdateCommandHandler : IRequestHandler<AssetTypeUpdateCommandRequest, AssetTypeUpdateCommandResponse>
    {
        private readonly IReadAssetTypeRepository _readAssetTypeRepository;
        private readonly IWriteAssetTypeRepository _writeAssetTypeRepository;
        private readonly IMapper _mapper;
        public AssetTypeUpdateCommandHandler(
            IReadAssetTypeRepository readAssetTypeRepository,
            IWriteAssetTypeRepository writeAssetTypeRepository,
            IMapper mapper)
        {
            _readAssetTypeRepository = readAssetTypeRepository;
            _writeAssetTypeRepository = writeAssetTypeRepository;
            _mapper = mapper;
        }
        public async Task<AssetTypeUpdateCommandResponse> Handle(AssetTypeUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            AssetType? type = _readAssetTypeRepository.Get(request.Id);
            if (type == null)
                return new AssetTypeUpdateCommandResponse() { AssetType = null, Status = false, Message = ResultMessages.AssetTypeNotFound };

            type.Type = request.TypeName;
            int savedCount = _writeAssetTypeRepository.saveChanges();
            if (savedCount > 0)
            {
                AssetTypeDto assetTypeDto = _mapper.Map<AssetTypeDto>(type);
                return new AssetTypeUpdateCommandResponse() { AssetType = assetTypeDto, Status = true, Message = ResultMessages.UpdateSuccessAssetTypeMessage };
            }
            return new AssetTypeUpdateCommandResponse() { AssetType = null, Status = false, Message = ResultMessages.UpdateErrorAssetTypeMessage };
        }
    }
}
