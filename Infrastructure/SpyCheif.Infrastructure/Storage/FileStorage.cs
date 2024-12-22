using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SpyCheif.Application.Dto.FileStorage;
using SpyCheif.Application.Enum;
using SpyCheif.Application.Utils.Storage;
using System.Globalization;
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

        public List<Dictionary<string, string>> ReadToCsv(string path, string delimiter = ",")
        {
            var result = new List<Dictionary<string, string>>();

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = delimiter,
                HasHeaderRecord = true
            };

            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, config))
            {
                csv.Read();
                csv.ReadHeader();

                while (csv.Read())
                {
                    var record = new Dictionary<string, string>();
                    foreach (var header in csv.HeaderRecord)
                    {
                        record[header] = csv.GetField(header);
                    }
                    result.Add(record);
                }
            }

            return result;
        }

        public List<Dictionary<string, string>> ReadCsv(string path, int maxRows, string delimiter = ",")
        {
            var result = new List<Dictionary<string, string>>();

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = delimiter,
                HasHeaderRecord = true
            };

            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, config))
            {
                csv.Read();
                csv.ReadHeader();

                int currentRow = 0;
                while (csv.Read() && currentRow < maxRows)
                {
                    var record = new Dictionary<string, string>();
                    foreach (var header in csv.HeaderRecord)
                    {
                        record[header] = csv.GetField(header);
                    }
                    result.Add(record);
                    currentRow++;
                }
            }

            return result;
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

        public List<string> StreamFullRead(string path, int readline)
        {
            List<string> returned = new List<string>();
            using (StreamReader stream = new StreamReader(path))
            {
                for (int line = 0; line < readline; line++)
                {
                    string? temp = stream.ReadLine();
                    if (temp != null)
                        returned.Add(temp);
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

        public List<string> StreamFullReadToList(string path)
        {
            List<string> returned = new List<string>();
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    returned.Add(line);
                }
            }
            return returned;
        }

        public FileUploadDto Upload(IFormFile file, string remoteHost)
        {
            var currentDirectory = Path.GetFullPath("wwwroot");
            var uploadPath = Path.Combine(currentDirectory, "uploads");
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            string newName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(file.FileName)}";
            uploadPath = Path.Combine(uploadPath, newName);
            string extension = Path.GetExtension(uploadPath).Replace(".", "");

            FileUploadDto result = new FileUploadDto();
            result.FileName = file.FileName;
            result.UniqName = newName;
            result.LocalPath = uploadPath;
            result.RemotePath = $"{remoteHost}/uploads/{newName}";

            using (FileStream stream = new FileStream(uploadPath, FileMode.Create, FileAccess.Write))
            {
                using (StreamReader reader = new StreamReader(file.OpenReadStream(), Encoding.UTF8))
                {
                    var fullRead = reader.ReadToEnd();

                    switch (extension.ToLower())
                    {
                        case "json":
                            result.FileType = FileTypeEnum.JSON;
                            if (fullRead.StartsWith("{"))
                                stream.Write(Encoding.UTF8.GetBytes($"[{fullRead.Replace("},", "}").Replace("}", "},")}]"));
                            else
                                file.CopyTo(stream);
                            break;
                        case "csv":
                            result.FileType = FileTypeEnum.CSV;
                            file.CopyTo(stream);
                            break;
                        case "txt":
                            result.FileType = FileTypeEnum.TEXT;
                            file.CopyTo(stream);
                            break;
                        default:
                            return null;
                    }
                }
            }

            if (File.Exists(uploadPath))
                return result;
            return null;
        }

    }
}
