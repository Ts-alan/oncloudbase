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

        [Required]
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Display(Name = "Символ")]
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }


        [Display(Name = "Маркеры")]
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
        [Required]
        public string Hallmark { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Display(Name = "Символ")]
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
        
        [DefaultValue(0)]
        [Display(Name = "Очерёдность")]
        public int ItemOrder { get; set; }
        public RoadSigns RoadSign { get; set; }
    }
}
