using AutoMapper;
using MediatR;
using SpyCheif.Application.Constants;
using SpyCheif.Application.Dto.AssetTypeDtos;
using SpyCheif.Application.Repository.AssetTypeRepo;
using SpyCheif.Domain.Entity;

namespace SpyCheif.Application.Feature.Command.AssetTypeCommand.Add
{
    public class AssetTypeAddCommandHandler : IRequestHandler<AssetTypeAddCommandRequest, AssetTypeAddCommandResponse>
    {
        private readonly IWriteAssetTypeRepository _assetTypeWriteRepository;
        private readonly IMapper _mapper;
        public AssetTypeAddCommandHandler(
            IWriteAssetTypeRepository assetTypeWriteRepository,
            IMapper mapper)
        {
            _assetTypeWriteRepository = assetTypeWriteRepository;
            _mapper = mapper;
        }

        public async Task<AssetTypeAddCommandResponse> Handle(AssetTypeAddCommandRequest request, CancellationToken cancellationToken)
        {
            AssetType assetType = _mapper.Map<AssetType>(request);
            AssetType type = await _assetTypeWriteRepository.AddAsync(assetType);
            int savedCount = _assetTypeWriteRepository.saveChanges();
            if (savedCount > 0)
            {
                AssetTypeDto assetTypeDto = _mapper.Map<AssetTypeDto>(type);
                return new AssetTypeAddCommandResponse() { AssetType = assetTypeDto, Status = true, Message = ResultMessages.AddSuccessAssetTypeMessage };
            }
            return new AssetTypeAddCommandResponse() { AssetType = null, Status = false, Message = ResultMessages.AddErrorAssetTypeMessage };

        }

    }
}
