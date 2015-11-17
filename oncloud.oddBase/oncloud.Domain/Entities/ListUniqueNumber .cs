using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oncloud.Domain.Entities
{
    public class ListUniqueNumber
    {
        public int Id { get; set; }
        [MaxLength(10)]
        public string UniqueNumber { get; set; }
    }
}
