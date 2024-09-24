using MongoDB.Bson;
using SpyCheif.Application.Feature.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Application.Feature.Query.TransferQuery.GetAll
{
    public class TransferGetAllQueryResponse:BaseResponse
    {
        public string? Datas { get; set; }
    }
}
