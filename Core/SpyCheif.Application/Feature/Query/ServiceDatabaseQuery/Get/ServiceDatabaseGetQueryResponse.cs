using SpyCheif.Application.Dto.ServiceDatabaseDtos;
using SpyCheif.Application.Feature.Base;

namespace SpyCheif.Application.Feature.Query.ServiceDatabaseQuery.Get
{
    public class ServiceDatabaseGetQueryResponse:BaseResponse
    {
        public ServiceDatabaseDto? ServiceDatabase { get; set; }
    }
}
