﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oncloud.Domain.Entities
{
    public class SpecificationOfRb
    {
        public int Id { get; set; }
        public string Length { get; set; }
        public virtual Street Street { get; set; }

        public int RoadBarriers_id { get; set; }

        public virtual RoadBarriers RoadBarriers { get; set; }
    }
}
