﻿using SpyCheif.Application.BaseRdms;
using SpyCheif.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Application.Repository.ProjectRepo
{
    public interface IReadProjectRepository : IBaseRdmsReadRepository<Project>
    {
    }
}