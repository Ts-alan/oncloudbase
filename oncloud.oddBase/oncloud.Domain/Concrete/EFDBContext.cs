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
        public virtual IDbSet<City> City { get; set; }
        public virtual IDbSet<Increment> Increment { get; set; }
        public virtual DbSet<Segment> Segment { get; set; }
        public virtual DbSet<SpecificationofRM> SpecificationofRM { get; set; }
        public virtual DbSet<SpecificationofRS> SpecificationofRS { get; set; }
        public virtual DbSet<SpecificationOfRb> SpecificationOfRb { get; set; }

        public virtual DbSet<MultipleImageForRS> MultipleImageForRS { get; set; }
        public virtual IDbSet<Street> Street { get; set; }
        public virtual IDbSet<TheHorizontalRoadMarking> TheHorizontalRoadMarking { get; set; }
        public virtual IDbSet<IntelliSenseStreet> IntelliSenseStreet { get; set; }
        public virtual IDbSet<RoadSigns> RoadSigns { get; set; }
        public virtual IDbSet<RoadBarriers> RoadBarriers { get; set; }
        public virtual IDbSet<layoutDislocation> layoutDislocations { get; set; }
        public virtual IDbSet<layoutScheme> layoutSchemes { get; set; }

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

            modelBuilder.Entity<Street>()
                .HasMany(e => e.SpecificationofRS)
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
