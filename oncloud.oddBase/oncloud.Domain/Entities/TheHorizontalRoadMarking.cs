using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oncloud.Domain.Entities
{
    [Table("TheHorizontalRoadMarking")]
    public class TheHorizontalRoadMarking
    {
        public int id { get; set; }
        [Required]
        public string NumberMarking { get; set; }
        [Column(TypeName = "ntext")]
        [Required]
        public string description { get; set; }
    }
}
