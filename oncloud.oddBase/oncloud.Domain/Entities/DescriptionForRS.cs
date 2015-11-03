using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oncloud.Domain.Entities
{
    public class DescriptionForRS
    {
        [Key, ForeignKey("ImageForRS")]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar")]
        [Display(Name = "Описание")]
        public string Description { get; set; }
        public int RoadSignId { get; set; }
        public virtual RoadSigns DescriptionRS { get; set; }
        public virtual ImageForRS ImageForRS { get; set; }
        public virtual TextForRS TextForRS { get; set; }

    }
}
