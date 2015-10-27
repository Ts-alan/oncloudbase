using System;
using System.Collections.Generic;
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
        [Column(TypeName = "nvarchar")]
        [Required]
        [Display(Name="Описание")]
        public string Description { get; set; }

        [Display(Name = "Символ")]
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
        public virtual ICollection<SpecificationofRS> SpecificationofRM { get; set; }
    }
}
