﻿using SpyCheif.Application.Dto.AssetDtos;
using SpyCheif.Application.Feature.Base;
using SpyCheif.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Application.Feature.Command.AssetCommand.Add
{
    public class AssetAddCommandResponse : BaseResponse
    {
        public AssetDto Asset { get; set; } 
    }
}
