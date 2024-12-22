using SpyCheif.Application.BackgroundJob;
using SpyCheif.Application.Dto.AssetDtos;
using SpyCheif.Application.Enum;
using SpyCheif.Application.Repository.AssetRepo;
using SpyCheif.Application.Utils.Storage;
using SpyCheif.Domain.Entity;

namespace SpyCheif.Infrastructure.Background.Hangfire
{
    public class AssetBackground : IAssetBackground
    {
        private readonly IWriteAssetRepository _writeAssetRepository;
        private readonly IFileStorage _fileStorage;
        public AssetBackground(
            IWriteAssetRepository writeAssetRepository,
            IFileStorage fileStorage)
        {
            _writeAssetRepository = writeAssetRepository;
            _fileStorage = fileStorage;
        }

        public void Add(FileAssetDto fileAssetDto)
        {
            switch (fileAssetDto.FileType)
            {
                case FileTypeEnum.TEXT:
                    TextProcess(fileAssetDto);
                    break;
                case FileTypeEnum.CSV:
                    CsvProcess(fileAssetDto);
                    break;
                case FileTypeEnum.JSON:
                    JsonProcess(fileAssetDto);
                    break;
                default:
                    break;
            }
        }

        private void TextProcess(FileAssetDto fileAssetDto)
        {
            List<Asset> entites = new();
            List<string> datas = _fileStorage.StreamFullReadToList(fileAssetDto.Path);
            foreach (string data in datas)
            {
                if (data.Trim().Length > 0 && entites.Find(asset => asset.Value == data.Trim()) == null)
                {
                    entites.Add(new()
                    {
                        ProjectId = fileAssetDto.ProjectId,
                        AssetTypeId = fileAssetDto.AssetTypeId,
                        Value = data.Trim()
                    });
                }

            }
            _writeAssetRepository.AddList(entites);
            _writeAssetRepository.saveChanges();
        }
        
        private void CsvProcess(FileAssetDto fileAssetDto)
        {
            List<Asset> entites = new();
            List<Dictionary<string, string>> results = _fileStorage.ReadToCsv(fileAssetDto.Path);
            foreach (var result in results)
            {
                foreach (KeyValuePair<string,string> data in result)
                {
                    Console.WriteLine(data);
                    if (data.Key == fileAssetDto.Key)
                    {


                        if (data.Value.Trim().StartsWith("["))
                        {
                            string tempData = data.Value.Trim().Replace("]", "").Replace("[", "");
                            if (fileAssetDto.SingleListSeparator != null && fileAssetDto.SingleListSeparator.Length > 0)
                            {
                                string[] datas = tempData.Split(fileAssetDto.SingleListSeparator);
                                foreach (var item in datas)
                                {
                                    if (item.Trim().Length > 0 && entites.Find(asset => asset.Value == item.Trim()) == null)
                                        entites.Add(new()
                                        {
                                            AssetTypeId = fileAssetDto.AssetTypeId,
                                            ProjectId = fileAssetDto.ProjectId,
                                            Value = item.Trim()
                                        });
                                }
                            }
                        }
                        else
                        {
                            if (data.Value.Trim().Length > 0 && entites.Find(asset => asset.Value == data.Value.Trim()) == null)
                                entites.Add(new()
                                {
                                    AssetTypeId = fileAssetDto.AssetTypeId,
                                    ProjectId = fileAssetDto.ProjectId,
                                    Value = data.Value.Trim()
                                });
                        }

                    }
                }
            }
            _writeAssetRepository.AddList(entites);
            _writeAssetRepository.saveChanges();
        }

        private void JsonProcess(FileAssetDto fileAssetDto)
        {
            string? json = _fileStorage.StreamFullRead(fileAssetDto.Path);

            List<Asset> entites = new();
            List<string> datas = _fileStorage.ReadToJson(json, fileAssetDto.Key);
            foreach (var data in datas)
            {
                if (data.Trim().Length > 0)
                {
                    if (fileAssetDto.SingleListSeparator != null && fileAssetDto.SingleListSeparator.Length > 0)
                    {
                        string[] tempDatas = data.Trim().Split(fileAssetDto.SingleListSeparator);
                        
                        if (entites.Find(asset => asset.Value == tempDatas[0].Trim()) == null)
                        {
                            Asset asset = new Asset()
                            {
                                ProjectId = fileAssetDto.ProjectId,
                                AssetTypeId = fileAssetDto.AssetTypeId,
                                Value = tempDatas[0].Trim()
                            };
                            entites.Add(asset);
                        }
                    }
                }
            }
            _writeAssetRepository.AddList(entites);
            _writeAssetRepository.saveChanges();
        }

    }
}
