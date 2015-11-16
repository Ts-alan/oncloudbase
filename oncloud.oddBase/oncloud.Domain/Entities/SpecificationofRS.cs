using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oncloud.Domain.Entities
{
     public  class SpecificationofRS
    {
        public int id { get; set; }
        public int CountRS { get; set; }
        public int Street_id { get; set; }
        public virtual Street Street { get; set; }
        public int RoadSignsId { get; set; }
        [NotMapped]
        public string RoadSignsIdModel { get; set; }
         [NotMapped]
        public int SegmentIdModel { get; set; }
        public int SegmentId { get; set; }

        public virtual RoadSigns RoadSigns { get; set; }
        public virtual Segment Segment { get; set; }
    }
}
