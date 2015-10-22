using System;
using System.Collections.Generic;
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
    }
}
