using SpyCheif.Application.Feature.Base;
using SpyCheif.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Application.Feature.Query.ServiceDatabaseQuery.GetAll
{
    public class ServiceDatabaseGetAllQueryResponse:BaseResponse
    {
        public List<ServiceDatabase> ServiceDatabases { get; set; }
    }
}
