using AutoMapper;
using MediatR;
using SpyCheif.Application.Dto.AssetDtos;
using SpyCheif.Application.Repository.AssetRepo;
using SpyCheif.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
        
        #warning performans iyileştirmesi gerekli.
        public async Task<AssetGetOfSearchQueryResponse> Handle(AssetGetOfSearchQueryRequest request, CancellationToken cancellationToken)
        {
            List<AssetDto> assetDtos = new List<AssetDto>();
            IEnumerable<Asset> assets = new List<Asset>();

            if (request.match != null)
            {
                assets = request.AssetTypeId.Equals(Guid.Empty)
                    ? _readAssetRepository.GetAll(asset => asset.AssetTypeId == request.AssetTypeId && Regex.IsMatch(asset.Value, request.match))
                    : _readAssetRepository.GetAll(asset => Regex.IsMatch(asset.Value, request.match));
            }
            else if (request.AssetTypeId != Guid.Empty)
            {
                assets = _readAssetRepository.GetAll(asset => asset.AssetTypeId == request.AssetTypeId);
            }

            assets = request.uniq ? assets.DistinctBy(asset => asset.Value).ToList() : assets.ToList();
            assetDtos = _mapper.Map<List<AssetDto>>(assets.ToList());

            if (assetDtos.Count > 0) 
                return new AssetGetOfSearchQueryResponse() { Assets = assetDtos, Status = true, Message = "" };
            return new AssetGetOfSearchQueryResponse() { Assets = null, Status = false, Message = "" };
        }
    }
}
