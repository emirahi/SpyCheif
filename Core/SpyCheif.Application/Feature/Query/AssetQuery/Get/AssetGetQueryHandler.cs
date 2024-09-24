
using MediatR;
using SpyCheif.Application.Constants;
using SpyCheif.Application.Repository.AssetRepo;
using SpyCheif.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Application.Feature.Query.AssetQuery.Get
{
    public class AssetGetQueryHandler : IRequestHandler<AssetGetQueryRequest, AssetGetQueryResponse>
    {
        private readonly IReadAssetRepository _readAssetRepository;
        public AssetGetQueryHandler(IReadAssetRepository readAssetRepository)
        {
            _readAssetRepository = readAssetRepository;
        }

        public async Task<AssetGetQueryResponse> Handle(AssetGetQueryRequest request, CancellationToken cancellationToken)
        {
            Asset? asset = _readAssetRepository.Get(request.Id);
            if (asset != null)
                return new AssetGetQueryResponse() { Asset = asset, Status = true ,Message = ResultMessages.GetSuccessAssetMessage };

            return new AssetGetQueryResponse() { Asset = null, Status = false, Message = ResultMessages.GetErrorAssetMessage };

        }
    }
}
