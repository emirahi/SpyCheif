using MediatR;
using SpyCheif.Application.Constants;
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
        public AssetTypeGetQueryHandler(IReadAssetTypeRepository readAssetTypeRepository)
        {
            _readAssetTypeRepository = readAssetTypeRepository;
        }

        public async Task<AssetTypeGetQueryResponse> Handle(AssetTypeGetQueryRequest request, CancellationToken cancellationToken)
        {
            AssetType? type = _readAssetTypeRepository.Get(request.Id);
            if (type != null)
                return new AssetTypeGetQueryResponse() { assetType = type, Status = true, Message = ResultMessages.GetSuccessAssetTypeMessage };
            return new AssetTypeGetQueryResponse() { assetType = null, Status = false, Message = ResultMessages.GetErrorAssetTypeMessage };

        }
    }
}
