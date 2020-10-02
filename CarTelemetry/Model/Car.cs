using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarTelemetry.Model
{
    public class Car
    {
        [Key]
        public int IdCar { get; set; }
        public string Name { get; set; }
        public CarType Typ { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public ICollection<TelemetryData> TelemetryData { get; set; } 
    }
}
