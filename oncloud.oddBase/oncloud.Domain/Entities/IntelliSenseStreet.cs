using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace oncloud.Domain.Entities
{
    [Table("IntelliSenseStreet")]
    public partial class IntelliSenseStreet
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Street { get; set; }

        [StringLength(50)]
        public string Type { get; set; }
    }
}
