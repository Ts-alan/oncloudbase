using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oncloud.Domain.Entities
{
    public class RoadBarriers
    {
        public int id { get; set; }
        [Required]
        public string NumberBarriers { get; set; }
        [Column(TypeName = "nvarchar")]
        [Required]
        public string Description { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
        public virtual ICollection<SpecificationOfRb> SpecificationofRM { get; set; }
    }
}
