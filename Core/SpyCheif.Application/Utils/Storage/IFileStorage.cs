using Microsoft.AspNetCore.Http;
using SpyCheif.Application.Dto.FileStorage;

namespace SpyCheif.Application.Utils.Storage
{
    public interface IFileStorage
    {
        public FileUploadResultDto? Upload(IFormFile file, string remoteHost);
        public string? StreamFullRead(string path);
        public ICollection<string> GetJsonKeys(string jsons);
        public List<Dictionary<string, object>> ReadToJson(string json, int readline);
        public List<string> ReadToJson(string json, string key);


    }
}
