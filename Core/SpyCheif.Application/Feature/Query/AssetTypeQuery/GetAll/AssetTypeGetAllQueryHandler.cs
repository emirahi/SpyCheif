using AutoMapper;
using MediatR;
using SpyCheif.Application.Constants;
using SpyCheif.Application.Dto.AssetTypeDtos;
using SpyCheif.Application.Repository.AssetTypeRepo;
using SpyCheif.Domain.Entity;

namespace SpyCheif.Application.Feature.Query.AssetTypeQuery.GetAll
{
    public class AssetTypeGetAllQueryHandler : IRequestHandler<AssetTypeGetAllQueryRequest, AssetTypeGetAllQueryResponse>
    {
        private readonly IReadAssetTypeRepository _readAssetTypeRepository;
        private readonly IMapper _mapper;
        public AssetTypeGetAllQueryHandler(IReadAssetTypeRepository readAssetTypeRepository, IMapper mapper)
        {
            _readAssetTypeRepository = readAssetTypeRepository;
            _mapper = mapper;
        }

        public async Task<AssetTypeGetAllQueryResponse> Handle(AssetTypeGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            List<AssetType> assetTypes = _readAssetTypeRepository.GetAll().ToList();
            if (assetTypes.Count > 0)
            {
                List<AssetTypeDto> assetTypeDtos = _mapper.Map<List<AssetTypeDto>>(assetTypes);
                return new AssetTypeGetAllQueryResponse() { AssetTypes = assetTypeDtos, Status = true, Message = ResultMessages.GetAllSuccessAssetTypeMessage };
            }
            return new AssetTypeGetAllQueryResponse() { AssetTypes = null, Status = false, Message = ResultMessages.GetAllErrorAssetTypeMessage };

        }
    }
}
