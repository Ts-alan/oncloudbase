using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oncloud.Domain.Abstract
{
    public interface IUnitOfWork
    {
        int SubmitChanges();
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        void Update<TEntity>(TEntity entity) where TEntity : class;
    }

}
