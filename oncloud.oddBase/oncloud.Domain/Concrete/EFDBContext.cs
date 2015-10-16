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
    public class EFDbContext : DbContext, IUnitOfWork
    {
        public IDbSet<Street> Streets { get; set; }
        public IDbSet<City> Cities { get; set; }

        public IDbSet<RoadMarking> RoadMarkings { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Configurations.Add(new CountryMappings());
        //    modelBuilder.Configurations.Add(new CityMappings());
        //}
        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            Entry(entity).State = EntityState.Modified;
        }
    }
}
