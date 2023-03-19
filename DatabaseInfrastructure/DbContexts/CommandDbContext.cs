﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseInfrastructure.DbContexts
{
    internal class CommandDbContext : BaseDbContext
    {
        public CommandDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
