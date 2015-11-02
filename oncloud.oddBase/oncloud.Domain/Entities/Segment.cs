using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace oncloud.Domain.Entities
{
    [Table("Segment")]
    public partial class Segment
    {
        public int id { get; set; }
        public int Name { get; set; }
        [Required]
        public string BreadthS { get; set; }
        [Required]
        public string LengthS { get; set; }
        [Required]
        public string BreadthE { get; set; }
        [Required]
        public string LengthE { get; set; }
        public int StreetId { get; set; }
        public virtual ICollection<SpecificationofRS> SpecificationofRS { get; set; }
        public virtual ICollection<layoutDislocation> layoutDislocation { get; set; }

        public virtual ICollection<SpecificationOfRb> SpecificationofRB { get; set; }
        public virtual Street Street { get; set; }
    }
}
