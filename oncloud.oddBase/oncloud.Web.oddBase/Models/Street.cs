namespace oncloud.Web.oddBase.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Street")]
    public partial class Street
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Street()
        {
            Segment = new HashSet<Segment>();
            SpecificationofRM = new HashSet<SpecificationofRM>();
        }

        public int id { get; set; }

        public string Name { get; set; }

        [Required]
        public string BreadthS { get; set; }

        [Required]
        public string LengthS { get; set; }

        [Required]
        public string BreadthE { get; set; }

        [Required]
        public string LengthE { get; set; }

        public int City_id { get; set; }

        [Required]
        public string UniqueNumber { get; set; }

        public virtual City City { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Segment> Segment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SpecificationofRM> SpecificationofRM { get; set; }
    }
}
