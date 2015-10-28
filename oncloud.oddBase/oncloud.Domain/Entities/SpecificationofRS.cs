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
        public int RoadSigns_id { get; set; }
        [NotMapped]
        public string RoadSignsIdModel { get; set; }
        public virtual RoadSigns RoadSigns { get; set; }

    }
}
