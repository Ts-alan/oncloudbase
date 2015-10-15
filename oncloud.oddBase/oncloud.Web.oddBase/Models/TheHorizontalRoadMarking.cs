namespace oncloud.Web.oddBase.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TheHorizontalRoadMarking")]
    public partial class TheHorizontalRoadMarking
    {
        public int id { get; set; }

        [Required]
        public string NumberMarking { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string description { get; set; }
    }
}
