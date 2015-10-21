using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace oncloud.Domain.Entities
{
    class RoadSigns
    {
        public int id { get; set; }
        [Required]
        public string NumberMarking { get; set; }
        [Column(TypeName = "nvarchar")]
        [Required]
        public string description { get; set; }
    }
}
