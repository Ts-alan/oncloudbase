using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using oncloud.Domain.Entities;

namespace oncloud.Domain.Concrete
{
    public class EFDBContext : DbContext
    {
        public DbSet<Street> Streets { get; set; }
    }
}
