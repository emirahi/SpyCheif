using AutoMapper;
using MediatR;
using SpyCheif.Application.Constants;
using SpyCheif.Application.Dto.AssetDtos;
using SpyCheif.Application.Repository.AssetRepo;
using SpyCheif.Domain.Entity;

namespace SpyCheif.Application.Feature.Query.AssetQuery.GetAll
{
    public class AssetGetAllQueryHandler : IRequestHandler<AssetGetAllQueryRequest, AssetGetAllQueryResponse>
    {
        private readonly IReadAssetRepository _readAssetRepository;
        private readonly IMapper _mapper;
        public AssetGetAllQueryHandler(IReadAssetRepository readAssetRepository, IMapper mapper)
        {
            _readAssetRepository = readAssetRepository;
            _mapper = mapper;
        }
        public async Task<AssetGetAllQueryResponse> Handle(AssetGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            List<Asset> assets = _readAssetRepository.GetAll(request.ProjectId, request.Uniq, null).ToList();

            if (assets.Count > 0)
            {
                List<AssetDto> assetDtos = _mapper.Map<List<AssetDto>>(assets);
                return new AssetGetAllQueryResponse() { Assets = assetDtos, Status = true, Message = ResultMessages.GetAllSuccessAssetMessage };
            }
            return new AssetGetAllQueryResponse() { Assets = null, Status = false, Message = ResultMessages.GetAllErrorAssetMessage };

        }

    }
}
