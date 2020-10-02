using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarTelemetry.Model
{
    public class TelemetryData
    {
        [Key]
        public int IdTelemetryData { get; set; }
        
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public float Speed{ get; set; }
        public float Capacity { get; set; }

        public Car car;
        public int CarId;
    }
}
