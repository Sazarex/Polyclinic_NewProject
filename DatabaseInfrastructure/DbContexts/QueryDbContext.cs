using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseInfrastructure.DbContexts
{
    public sealed class QueryDbContext : BaseDbContext
    {
        public QueryDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
