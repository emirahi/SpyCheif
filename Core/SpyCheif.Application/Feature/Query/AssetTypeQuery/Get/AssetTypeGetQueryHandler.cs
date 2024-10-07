using AutoMapper;
using MediatR;
using SpyCheif.Application.Constants;
using SpyCheif.Application.Dto.AssetTypeDtos;
using SpyCheif.Application.Repository.AssetTypeRepo;
using SpyCheif.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Application.Feature.Query.AssetTypeQuery.Get
{
    public class AssetTypeGetQueryHandler : IRequestHandler<AssetTypeGetQueryRequest, AssetTypeGetQueryResponse>
    {
        private readonly IReadAssetTypeRepository _readAssetTypeRepository;
        private readonly IMapper _mapper;
        public AssetTypeGetQueryHandler(IReadAssetTypeRepository readAssetTypeRepository, IMapper mapper)
        {
            _readAssetTypeRepository = readAssetTypeRepository;
            _mapper = mapper;
        }

        public async Task<AssetTypeGetQueryResponse> Handle(AssetTypeGetQueryRequest request, CancellationToken cancellationToken)
        {
            AssetType? type = _readAssetTypeRepository.Get(request.Id);
            if (type != null)
            {
                AssetTypeDto assetTypeDto = _mapper.Map<AssetTypeDto>(type);
                return new AssetTypeGetQueryResponse() { assetType = assetTypeDto, Status = true, Message = ResultMessages.GetSuccessAssetTypeMessage };
            }
            return new AssetTypeGetQueryResponse() { assetType = null, Status = false, Message = ResultMessages.GetErrorAssetTypeMessage };

        }
    }
}
