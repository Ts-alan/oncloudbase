using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oncloud.Domain.Entities
{
    public class RoadMarking
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public string Number { get; set; }
        public string Description { get; set; }
    }
}
