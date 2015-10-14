using oncloud.Domain.Abstract;
using oncloud.Domain.DAL;
using oncloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oncloud.Domain.Concrete
{
    public class EFStreetsRepository : GenericRepository<Street, EFDBContext>, IStreetsRepository
    {
        public EFStreetsRepository(EFDBContext context) : base(context) { }
        public IQueryable<Street> Streets
        {
            get { return context.Streets; }
        }
    }
}
