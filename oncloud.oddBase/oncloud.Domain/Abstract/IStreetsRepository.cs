﻿using oncloud.Domain.DAL;
using oncloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oncloud.Domain.Abstract
{
    public interface IStreetsRepository : IGenericRepository<Street>
    {
        IQueryable<Street> Streets { get; }
    }
}
