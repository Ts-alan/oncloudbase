using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace oncloud.Domain.Entities
{
    public class RoadSigns
    {
        public int id { get; set; }
        [Required]
        public string NumberRoadSigns { get; set; }

        public virtual ICollection<RoadSignItem> RoadSignItems { get; set; }
        //public virtual ICollection<SpecificationofRS> SpecificationofRM { get; set; }
    }

    public class RoadSignItem
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [Display(Name = "Маркер")]
        public string Hallmark { get; set; }

        public string Description { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}
