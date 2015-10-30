using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oncloud.Domain.Entities
{
     public  class MultipleImageForRS
    {
        public int Id { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
        public int RoadSignsid { get; set; }
        public virtual RoadSigns RoadSigns { get; set; }
    }
}
