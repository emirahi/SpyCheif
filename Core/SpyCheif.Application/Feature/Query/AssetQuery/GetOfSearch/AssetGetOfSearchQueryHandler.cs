using AutoMapper;
using MediatR;
using SpyCheif.Application.Constants;
using SpyCheif.Application.Dto.AssetDtos;
using SpyCheif.Application.Repository.AssetRepo;
using SpyCheif.Domain.Entity;
using System.Text.RegularExpressions;

namespace SpyCheif.Application.Feature.Query.AssetQuery.GetOfSearch
{
    public class AssetGetOfSearchQueryHandler : IRequestHandler<AssetGetOfSearchQueryRequest, AssetGetOfSearchQueryResponse>
    {
        private readonly IReadAssetRepository _readAssetRepository;
        private readonly IMapper _mapper;
        
        public AssetGetOfSearchQueryHandler(IReadAssetRepository readAssetRepository,IMapper mapper)
        {
            _readAssetRepository = readAssetRepository;
            _mapper = mapper;
        }
        
        public async Task<AssetGetOfSearchQueryResponse> Handle(AssetGetOfSearchQueryRequest request, CancellationToken cancellationToken)
        {
            
            IEnumerable<Asset> assets = _readAssetRepository.GetAll(asset => asset.ProjectId == request.ProjectId);
            if (assets.Count() <= 0)
                return new AssetGetOfSearchQueryResponse() { Assets = null, Status = false, Message = ResultMessages.ProjectNotFound };
            
            if (request.match != null)
            {
                assets = request.AssetTypeId.Equals(Guid.Empty)
                    ? assets.Where(asset => asset.AssetTypeId == request.AssetTypeId && Regex.IsMatch(asset.Value, request.match))
                    : assets.Where(asset => Regex.IsMatch(asset.Value, request.match));
            }
            else if (request.AssetTypeId != Guid.Empty)
            {
                assets = assets.Where(asset => asset.AssetTypeId == request.AssetTypeId);
            }

            assets = request.uniq ? assets.DistinctBy(asset => asset.Value).ToList() : assets.ToList();
            List<AssetDto> assetDtos = _mapper.Map<List<AssetDto>>(assets);

            if (assetDtos.Count > 0) 
                return new AssetGetOfSearchQueryResponse() { Assets = assetDtos, Status = true, Message = ResultMessages.GetOfSearchSuccessAssetMessage };
            return new AssetGetOfSearchQueryResponse() { Assets = null, Status = false, Message = ResultMessages.GetOfSearchErrorAssetMessage };
        }
    }
}
