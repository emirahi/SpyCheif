using AutoMapper;
using MediatR;
using SpyCheif.Application.Constants;
using SpyCheif.Application.Dto.AssetDtos;
using SpyCheif.Application.Repository.AssetRepo;
using SpyCheif.Application.Repository.AssetTypeRepo;
using SpyCheif.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Application.Feature.Command.AssetCommand.Add
{
    public class AssetAddCommentHandler : IRequestHandler<AssetAddCommandRequest, AssetAddCommandResponse>
    {
        private IWriteAssetRepository _writeAssetRepository;
        private IReadAssetTypeRepository _readAssetTypeRepository;
        private IMapper _mapper;
        public AssetAddCommentHandler(
            IWriteAssetRepository writeAssetRepository,
            IReadAssetTypeRepository readAssetTypeRepository,
            IMapper mapper)
        {
            _writeAssetRepository = writeAssetRepository;
            _readAssetTypeRepository = readAssetTypeRepository;
            _mapper = mapper;
        }

        public async Task<AssetAddCommandResponse> Handle(AssetAddCommandRequest request, CancellationToken cancellationToken)
        {
            AssetType? assetType = _readAssetTypeRepository.Get(request.AssetTypeId);
            if (assetType == null)
                return new AssetAddCommandResponse { Asset = null, Status = false, Message = ResultMessages.AssetTypeNotFound };

            Asset asset = await _writeAssetRepository.AddAsync(new() { AssetTypeId = request.AssetTypeId, Value = request.Value });
            int isSaved = _writeAssetRepository.saveChanges();

            if (asset != null && isSaved > 0)
            {
                AssetDto assetDto = _mapper.Map<AssetDto>(asset);
                return new AssetAddCommandResponse()
                {
                    Asset = assetDto,
                    Status = true,
                    Message = ResultMessages.AddSuccessAssetMessage
                };
            }

            return new AssetAddCommandResponse()
            {
                Status = false,
                Message = ResultMessages.AddErrorAssetMessage,
                Asset = null
            };
        }
    }
}
