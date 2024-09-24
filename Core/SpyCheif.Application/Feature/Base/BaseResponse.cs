using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Application.Feature.Base
{
    public abstract class BaseResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; }
    }
}
