using Hangfire;
using SpyCheif.Application.Dto.AssetDtos;

namespace SpyCheif.Application.BackgroundJob
{
    [AutomaticRetry(Attempts = 10)]
    public interface IAssetBackground
    {
        [JobDisplayName("Create Asset")]
        public void Add(FileAssetDto fileAssetDto);
    }
}
