using SpyCheif.Application.Feature.Base;
using SpyCheif.Domain.Entity;

namespace SpyCheif.Application.Feature.Command.ServiceDatabaseCommand.Update
{
    public class ServiceDatabaseUpdateCommandResponse:BaseResponse
    {
        public ServiceDatabase serviceDatabase { get; set; }
    }
}
