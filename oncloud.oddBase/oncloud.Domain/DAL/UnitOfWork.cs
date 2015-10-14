using oncloud.Domain.Abstract;
using oncloud.Domain.Concrete;
using oncloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oncloud.Domain.DAL
{
    public class UnitOfWork_ : IDisposable
    {
        private DbContext context ;//= new DbContext();
        private IGenericRepository<Street> streetsRepository;
        private IGenericRepository<City> citiesRepository;

        public IGenericRepository<Street> StreetsRepository
        {
            get
            {
                if (this.streetsRepository == null)
                {
                    this.streetsRepository = new GenericRepository<Street>(context);
                }
                return streetsRepository;
            }
        }

        public IGenericRepository<City> CitiesRepository
        {
            get
            {

                if (this.citiesRepository == null)
                {
                    this.citiesRepository = new GenericRepository<City>(context);
                }
                return citiesRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
