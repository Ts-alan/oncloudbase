namespace oncloud.Web.oddBase.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EntitiesOddAdbase : DbContext
    {
        public EntitiesOddAdbase()
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
        }
    }
}
