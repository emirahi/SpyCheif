﻿using AutoMapper;
using MediatR;
using SpyCheif.Application.Constants;
using SpyCheif.Application.Dto.AssetDtos;
using SpyCheif.Application.Repository.AssetRepo;
using SpyCheif.Application.Repository.AssetTypeRepo;
using SpyCheif.Application.Repository.ProjectRepo;
using SpyCheif.Domain.Entity;

namespace SpyCheif.Application.Feature.Command.AssetCommand.Add
{
    public class AssetAddOfMultiCommentHandler : IRequestHandler<AssetAddCommandRequest, AssetAddOfMultiCommandResponse>
    {
        private IWriteAssetRepository _writeAssetRepository;
        private IReadAssetTypeRepository _readAssetTypeRepository;
        private IReadProjectRepository _readProjectRepository;
        private IMapper _mapper;
        public AssetAddOfMultiCommentHandler(
            IWriteAssetRepository writeAssetRepository,
            IReadAssetTypeRepository readAssetTypeRepository,
            IReadProjectRepository readProjectRepository,
            IMapper mapper)
        {
            _writeAssetRepository = writeAssetRepository;
            _readAssetTypeRepository = readAssetTypeRepository;
            _readProjectRepository = readProjectRepository;
            _mapper = mapper;
        }

        public async Task<AssetAddOfMultiCommandResponse> Handle(AssetAddCommandRequest request, CancellationToken cancellationToken)
        {
            AssetType? assetType = _readAssetTypeRepository.Get(request.AssetTypeId);
            if (assetType == null)
                return new AssetAddOfMultiCommandResponse { Asset = null, Status = false, Message = ResultMessages.AssetTypeNotFound };

            Project? project = _readProjectRepository.Get(request.ProjectId);
            if (project == null)
                return new AssetAddOfMultiCommandResponse() { Asset = null, Status = false, Message = ResultMessages.ProjectNotFound };

            Asset castAsset = _mapper.Map<Asset>(request);
            Asset asset = await _writeAssetRepository.AddAsync(castAsset);
            int isSaved = _writeAssetRepository.saveChanges();

            if (asset != null && isSaved > 0)
            {
                AssetDto assetDto = _mapper.Map<AssetDto>(asset);
                return new AssetAddOfMultiCommandResponse()
                {
                    Asset = assetDto,
                    Status = true,
                    Message = ResultMessages.AddSuccessAssetMessage
                };
            }

            return new AssetAddOfMultiCommandResponse()
            {
                Status = false,
                Message = ResultMessages.AddErrorAssetMessage,
                Asset = null
            };
        }
    }
}
