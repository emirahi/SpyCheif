using MediatR;
using SpyCheif.Application.Constants;
using SpyCheif.Application.Repository.AssetTypeRepo;
using SpyCheif.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Application.Feature.Query.AssetTypeQuery.GetAll
{
    public class AssetTypeGetAllQueryHandler : IRequestHandler<AssetTypeGetAllQueryRequest, AssetTypeGetAllQueryResponse>
    {
        private readonly IReadAssetTypeRepository _readAssetTypeRepository;
        public AssetTypeGetAllQueryHandler(IReadAssetTypeRepository readAssetTypeRepository)
        {
            _readAssetTypeRepository = readAssetTypeRepository;
        }

        public async Task<AssetTypeGetAllQueryResponse> Handle(AssetTypeGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            List<AssetType> assetTypes = _readAssetTypeRepository.GetAll().ToList();
            if (assetTypes.Count > 0)
                return new AssetTypeGetAllQueryResponse() { AssetTypes = assetTypes, Status = true, Message = ResultMessages.GetAllSuccessAssetTypeMessage };
            return new AssetTypeGetAllQueryResponse() { AssetTypes = null, Status = false, Message = ResultMessages.GetAllErrorAssetTypeMessage };

        }
    }
}
