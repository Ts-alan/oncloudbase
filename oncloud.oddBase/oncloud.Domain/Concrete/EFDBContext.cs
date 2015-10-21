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
        public EFDbContext()
            : base("name=EntitiesOddAdbase")
        {
        }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Increment> Increment { get; set; }
        public virtual DbSet<Segment> Segment { get; set; }
        public virtual DbSet<SpecificationofRM> SpecificationofRM { get; set; }
        public virtual DbSet<Street> Street { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TheHorizontalRoadMarking> TheHorizontalRoadMarking { get; set; }
        public virtual DbSet<IntelliSenseStreet> IntelliSenseStreet { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasMany(e => e.Street)
                .WithRequired(e => e.City)
                .HasForeignKey(e => e.City_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Street>()
                .HasMany(e => e.Segment)
                .WithRequired(e => e.Street)
                .HasForeignKey(e => e.Street_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Street>()
                .HasMany(e => e.SpecificationofRM)
                .WithRequired(e => e.Street)
                .HasForeignKey(e => e.Street_id)
                .WillCascadeOnDelete(false);

            //    modelBuilder.Configurations.Add(new CountryMappings());
            //    modelBuilder.Configurations.Add(new CityMappings());
        }
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
