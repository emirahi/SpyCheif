﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Application.Feature.Query.AssetQuery.GetAll
{
    public class AssetGetAllQueryRequest:IRequest<AssetGetAllQueryResponse>
    {
        public bool uniq { get; set; } = false;
    }
}
