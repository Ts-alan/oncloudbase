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
        [Display(Name = "№")]
        public string NumberMarking { get; set; }
        [Column(TypeName = "ntext")]
        [Required]
        [Display(Name = "Описание")]
        public string description { get; set; }
        [Display(Name = "Символ")]
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }

        public virtual ICollection<SpecificationofRM> SpecificationofRM { get; set; }
    }
}
