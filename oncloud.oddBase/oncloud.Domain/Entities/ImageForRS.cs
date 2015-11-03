﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oncloud.Domain.Entities
{

     public  class ImageForRS
    {
   
        public int Id { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
        public int RoadSignId { get; set; }
        public virtual RoadSigns RoadSigns { get; set; }
        public virtual DescriptionForRS DescriptionForRS { get; set; }
    }
}
