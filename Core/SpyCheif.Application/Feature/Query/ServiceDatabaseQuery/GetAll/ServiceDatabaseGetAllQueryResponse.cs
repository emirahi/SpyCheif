using SpyCheif.Application.Dto.ServiceDatabaseDtos;
using SpyCheif.Application.Feature.Base;

namespace SpyCheif.Application.Feature.Query.ServiceDatabaseQuery.GetAll
{
    public class ServiceDatabaseGetAllQueryResponse:BaseResponse
    {
        public List<ServiceDatabaseDto> ServiceDatabases { get; set; }
    }
}
