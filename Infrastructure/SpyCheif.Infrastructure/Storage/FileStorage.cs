using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SpyCheif.Application.Dto.FileStorage;
using SpyCheif.Application.Utils.Storage;
using System.Text;

namespace SpyCheif.Infrastructure.Storage
{
    public class FileStorage : IFileStorage
    {
        public ICollection<string>? GetJsonKeys(string jsons)
        {
            List<Dictionary<string, object>> convert = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(jsons);
            if (convert.Count > 0)
                return convert[0].Keys;
            return new List<string>();
        }

        public List<Dictionary<string, object>> ReadToJson(string jsons, int readline)
        {
            List<Dictionary<string, object>> returned = new List<Dictionary<string, object>>();
            List<Dictionary<string, object>> convert = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(jsons);
            Console.WriteLine(convert[0].Keys);

            int lines = convert.Count;
            if (readline > 0 && readline <= lines)
                lines = readline;

            for (int line = 0; line < lines; line++)
            {
                var dictObject = convert[line];
                Console.WriteLine($" {dictObject}");
                Dictionary<string, object> temp = new Dictionary<string, object>();

                foreach (KeyValuePair<string, object> pair in dictObject)
                {
                    Console.Write(pair.Value);
                    Console.WriteLine(pair.Value.GetType());
                    bool flag = false;
                    string valueT = string.Empty;
                    if (pair.Value.GetType() == typeof(JArray))
                    {
                        foreach (var item in (JArray)pair.Value)
                        {
                            Console.WriteLine();
                            if (item.GetType() == typeof(JValue))
                            {
                                Console.WriteLine(item);
                                Console.WriteLine(item.GetType());
                                if (valueT.Length > 0)
                                    valueT += ", " + item;
                                else
                                    valueT = item.ToString();
                            }
                        }
                        flag = true;
                        Console.WriteLine(valueT);
                    }

                    if (flag)
                        temp.Add(pair.Key, valueT);
                    else
                        temp.Add(pair.Key, pair.Value);
                    Console.WriteLine("-------------------------------------------");
                }
                returned.Add(temp);
            }
            return returned;
        }

        public List<string> ReadToJson(string jsons, string key)
        {
            List<Dictionary<string, object>> convert = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(jsons);
            Console.WriteLine(convert[0].Keys);

            List<string> returned = new List<string>();
            for (int line = 0; line < convert.Count; line++)
            {
                var dictObject = convert[line];
                Console.WriteLine($" {dictObject}");

                foreach (KeyValuePair<string, object> pair in dictObject)
                {
                    if (pair.Key == key)
                    {
                        Console.Write(pair.Value);
                        Console.WriteLine(pair.Value.GetType());
                        bool flag = false;
                        if (pair.Value.GetType() == typeof(JArray))
                        {
                            foreach (var item in (JArray)pair.Value)
                            {
                                Console.WriteLine(item.GetType());
                                if (item.GetType() == typeof(JValue))
                                {
                                    Console.WriteLine($"List Value : {item}");
                                    returned.Add(item.ToString());
                                }
                            }
                            continue;
                        }
                        returned.Add(pair.Value.ToString());
                    }
                }
            }
            return returned;
        }

        public string StreamFullRead(string path)
        {
            if (!Path.Exists(path))
                return null;

            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }

        public FileUploadResultDto Upload(IFormFile file, string remoteHost)
        {
            var currentDirectory = Path.GetFullPath("wwwroot");
            var uploadPath = Path.Combine(currentDirectory, "uploads");
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            string newName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(file.FileName)}";
            uploadPath = Path.Combine(uploadPath, newName);
            using (FileStream stream = new FileStream(uploadPath, FileMode.Create, FileAccess.Write))
            {
                file.CopyTo(stream);
            }

            if (File.Exists(uploadPath))
                return new() { FileName = file.FileName, UniqName = newName, LocalPath = uploadPath, RemotePath = $"{remoteHost}/uploads/{newName}" };
            return null;
        }

    }
}
