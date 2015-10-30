using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Spatial;
using System.ComponentModel.DataAnnotations.Schema;

namespace oncloud.Domain.Entities
{
    [Table("Street")]
    public class Street
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
        public virtual layoutScheme layoutScheme { get; set; }

        public virtual ICollection<layoutDislocation> layoutDislocation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Segment> Segment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SpecificationofRM> SpecificationofRM { get; set; }

        public virtual ICollection<SpecificationofRS> SpecificationofRS { get; set; }

        public virtual ICollection<SpecificationOfRb> SpecificationOfRb { get; set; }
        //public int StreetId { get; set; }
        //public string Caption { get; set; }

        //public double? StartPointLongitude { get; set; }
        //public double? StartPointLatitude { get; set; }
        //public double? EndPointLongitude { get; set; }
        //public double? EndPointLatitude { get; set; }

        //[NotMapped]
        //public DbGeography StartPoint { 
        //    get 
        //    {
        //        return DbGeography.PointFromText(string.Format("POINT({0},{1})", StartPointLongitude, StartPointLatitude), DbGeography.DefaultCoordinateSystemId);
        //    }
        //    set 
        //    {
        //        StartPointLongitude = value.Longitude;
        //        StartPointLatitude = value.Latitude;
        //    }
        //}
    }
}
