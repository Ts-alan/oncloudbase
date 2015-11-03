using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oncloud.Domain.Entities
{
    public class SpecificationOfRb
    {
        public int Id { get; set; }
        public int Length { get; set; }
       
        [NotMapped]
        public int SegmentIdModel { get; set; }
        public int SegmentId { get; set; }
        public int RoadBarriersId { get; set; }
        public int StreetId { get; set; }
        [NotMapped]
        public string RoadBarriersIdModel { get; set; }
        public virtual RoadBarriers RoadBarriers { get; set; }
        public virtual Segment Segment { get; set; }
        public virtual Street Street { get; set; }
    }
}
