using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oncloud.Domain.Entities
{
     public  class layoutDislocation
    {
        public int Id { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
        public virtual Street Street { get; set; }
        public virtual Segment Segment { get; set; }
        public int SegmentId { get; set; }
        public int StreetId { get; set; }
        [NotMapped]
        public int SegmentName { get; set; }
    }
}
