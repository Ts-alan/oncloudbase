using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using oncloud.Domain.Entities;
using oncloud.Domain.Abstract;

namespace oncloud.Domain.Concrete
{
    //public class EFDBContext : DbContext, IUnitOfWork
    //{
    //    public IDbSet<Street> Streets { get; set; }
    //    public IDbSet<City> Cities { get; set; }
    //}
    public class UnitOfWork : DbContext, IUnitOfWork
    {
        public IDbSet<Street> Streets { get; set; }
        public IDbSet<City> Cities { get; set; }

        public UnitOfWork(string nameOrConnectionString) : base(nameOrConnectionString) { }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Configurations.Add(new CountryMappings());
        //    modelBuilder.Configurations.Add(new CityMappings());
        //}
        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public override int SaveChanges()
        {
            throw new InvalidOperationException();
            // return base.SaveChanges();
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            Entry(entity).State = EntityState.Modified;
        }

        public int SubmitChanges()
        {
            return base.SaveChanges();
        }



    }
}
