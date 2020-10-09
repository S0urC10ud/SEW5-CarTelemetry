using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarTelemetry.Model
{
    public class TelemetryData
    {
        [Key]
        public int IdTelemetryData { get; set; }

        [Column(TypeName = "decimal(18, 10)")]
        [DisplayFormat(DataFormatString = "{0:0.0000000}", ApplyFormatInEditMode = true)]
        public decimal Latitude { get; set; }

        [Column(TypeName = "decimal(18, 10)")]
        [DisplayFormat(DataFormatString = "{0:0.0000000}", ApplyFormatInEditMode = true)]
        public decimal Longitude { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        [DisplayFormat(DataFormatString = "{0:0.00}", ApplyFormatInEditMode = true)]
        public decimal Speed { get; set; }

        [Column(TypeName = "decimal(18, 10)")]
        [DisplayFormat(DataFormatString = "{0:0.0000000}", ApplyFormatInEditMode = true)]
        public decimal Capacity { get; set; }

        public int CarId { get; set; }
    }
}
