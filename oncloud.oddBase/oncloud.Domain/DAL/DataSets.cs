using oncloud.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oncloud.Domain.DAL
{
    public class DataSets
    {
        protected IUnitOfWork _uow;
        public DataSets(IUnitOfWork uow) { _uow = uow; }
        public void SetEntryModified<TEntity>(TEntity entity) where TEntity : class
        {
            _uow.Update(entity);
        }
        public int SaveChanges()
        {
            return _uow.SaveChanges();
        }
        public void Dispose()
        {
            if (_uow is IDisposable)
            {
                ((IDisposable)_uow).Dispose();
            }
        }
    }
}
