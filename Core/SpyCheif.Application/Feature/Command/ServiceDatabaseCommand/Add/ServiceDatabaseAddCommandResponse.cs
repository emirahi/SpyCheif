using SpyCheif.Application.Feature.Base;
using SpyCheif.Domain.Entity;

namespace SpyCheif.Application.Feature.Command.ServiceDatabaseCommand.Add
{
    public class ServiceDatabaseAddCommandResponse : BaseResponse
    {
        public ServiceDatabase ServiceDatabase { get; set; }
    }
}
