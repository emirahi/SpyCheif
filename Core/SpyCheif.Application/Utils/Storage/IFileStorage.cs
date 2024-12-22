using Microsoft.AspNetCore.Http;
using SpyCheif.Application.Dto.FileStorage;

namespace SpyCheif.Application.Utils.Storage
{
    public interface IFileStorage
    {
        public FileUploadDto? Upload(IFormFile file, string remoteHost);
        public string? StreamFullRead(string path);
        public List<string> StreamFullRead(string path, int readline);
        public List<string> StreamFullReadToList(string path);
        public ICollection<string> GetJsonKeys(string jsons);
        public List<Dictionary<string, object>> ReadToJson(string json, int readline);
        public List<string> ReadToJson(string json, string key);

        public List<Dictionary<string,string>> ReadToCsv(string path, string delimiter = ",");
        public List<Dictionary<string, string>> ReadCsv(string path, int maxRows, string delimiter = ",");

    }
}
