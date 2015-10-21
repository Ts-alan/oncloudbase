using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oncloud.Domain.Entities
{
    public class City
    {
        public int CityId { get; set; }
        public string Caption { get; set; }
    }
}
