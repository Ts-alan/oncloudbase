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
        [Display(Name = "№")]
        public string NumberRoadSigns { get; set; }
        public virtual ICollection<SpecificationofRS> SpecificationofRM { get; set; }
        public virtual ICollection<ImageForRS> ImageForRoadSigns { get; set; }
        public virtual ICollection<DescriptionForRS> DescriptionRS { get; set; }
        public virtual ICollection<TextForRS> TextForRS { get; set; }
        public virtual ICollection<ImageForRS> ImageForRS { get; set; }

    }
}
