using MediatR;
using SpyCheif.Application.Constants;
using SpyCheif.Application.Repository.AssetRepo;
using SpyCheif.Domain.Entity;

namespace SpyCheif.Application.Feature.Command.AssetCommand.Delete
{
    public class AssetDeleteCommandHandler : IRequestHandler<AssetDeleteCommandRequest, AssetDeleteCommandResponse>
    {
        private readonly IWriteAssetRepository _writeAssetRepository;
        private readonly IReadAssetRepository _readAssetRepository;
        public AssetDeleteCommandHandler(
            IWriteAssetRepository writeAssetRepository,
            IReadAssetRepository readAssetRepository)
        {
            _writeAssetRepository = writeAssetRepository;
            _readAssetRepository = readAssetRepository;
        }

        public async Task<AssetDeleteCommandResponse> Handle(AssetDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            Asset? asset = _readAssetRepository.Get(request.Id);
            if (asset == null)
                return new AssetDeleteCommandResponse() { Status = false, Message = ResultMessages.AssetNotFount };

            _writeAssetRepository.Delete(request.Id);
            int savedCount = _writeAssetRepository.saveChanges();
            if (savedCount > 0)
                return new AssetDeleteCommandResponse() { Status = true, Message = ResultMessages.DeleteSuccessAssetMessage };
            return new AssetDeleteCommandResponse() { Status = false, Message = ResultMessages.DeleteErrorAssetMessage };
            
        }
    }
}
