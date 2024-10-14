
using AutoMapper;
using MediatR;
using SpyCheif.Application.Constants;
using SpyCheif.Application.Dto.AssetDtos;
using SpyCheif.Application.Repository.AssetRepo;
using SpyCheif.Domain.Entity;

namespace SpyCheif.Application.Feature.Query.AssetQuery.Get
{
    public class AssetGetQueryHandler : IRequestHandler<AssetGetQueryRequest, AssetGetQueryResponse>
    {
        private readonly IReadAssetRepository _readAssetRepository;
        private readonly IMapper _mapper;
        public AssetGetQueryHandler(IReadAssetRepository readAssetRepository, IMapper mapper)
        {
            _readAssetRepository = readAssetRepository;
            _mapper = mapper;
        }

        public async Task<AssetGetQueryResponse> Handle(AssetGetQueryRequest request, CancellationToken cancellationToken)
        {
            Asset? asset = _readAssetRepository.Get(asset => asset.Id == request.Id && asset.ProjectId == request.ProjectId);
            if (asset != null)
            {
                AssetDto? assetDto = _mapper.Map<AssetDto>(asset);
                return new AssetGetQueryResponse() { Asset = assetDto, Status = true ,Message = ResultMessages.GetSuccessAssetMessage };
            }
            return new AssetGetQueryResponse() { Asset = null, Status = false, Message = ResultMessages.GetErrorAssetMessage };

        }
    }
}
