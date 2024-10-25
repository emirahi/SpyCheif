using Hangfire;
using SpyCheif.Domain.Entity;

namespace SpyCheif.Application.BackgroundJob
{
    [AutomaticRetry(Attempts = 10)]
    public interface IAssetBackground
    {
        [JobDisplayName("Create Asset")]
        public void Add(List<Asset> assets);
    }
}
