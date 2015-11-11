using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace oncloud.Domain.Entities
{
    [Table("SpecificationofRM")]
    public partial class SpecificationofRM
    {
        public int id { get; set; }
        public string length { get; set; }
        public string area { get; set; }
        public int Street_id { get; set; }
        public int TheHorizontalRoadMarking_id { get; set; }
        [NotMapped]
        public string TheHorizontalRoadMarkingIdModel { get; set; }
       
        public virtual TheHorizontalRoadMarking TheHorizontalRoadMarking { get; set; }
        public virtual Street Street { get; set; }

    }
}
