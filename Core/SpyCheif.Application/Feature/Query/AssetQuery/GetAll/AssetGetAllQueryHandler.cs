using MediatR;
using SpyCheif.Application.Constants;
using SpyCheif.Application.Repository.AssetRepo;
using SpyCheif.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Application.Feature.Query.AssetQuery.GetAll
{
    public class AssetGetAllQueryHandler : IRequestHandler<AssetGetAllQueryRequest, AssetGetAllQueryResponse>
    {
        private readonly IReadAssetRepository _readAssetRepository;
        public AssetGetAllQueryHandler(IReadAssetRepository readAssetRepository)
        {
            _readAssetRepository = readAssetRepository;
        }
        public async Task<AssetGetAllQueryResponse> Handle(AssetGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            List<Asset> assets = _readAssetRepository.GetAll().ToList();
            if (assets.Count > 0)
                return new AssetGetAllQueryResponse() { Assets = assets, Status = true, Message = ResultMessages.GetAllSuccessAssetMessage };
            return new AssetGetAllQueryResponse() { Assets = null, Status = false, Message = ResultMessages.GetAllErrorAssetMessage };

        }

    }
}
