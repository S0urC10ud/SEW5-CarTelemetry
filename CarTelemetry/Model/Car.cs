using EntityFrameworkCore.Triggers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarTelemetry.Model
{
    public abstract class Trackable
    {

        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        static Trackable()
        {
            Triggers<Trackable>.Inserting += entry => entry.Entity.CreatedAt = entry.Entity.ModifiedAt = DateTime.Now;
            Triggers<Trackable>.Updating += entry => entry.Entity.ModifiedAt = DateTime.Now;
        }
    }

    public class Car : Trackable
    {
        [Key]
        public int IdCar { get; set; }
        public string Name { get; set; }
        public CarType Typ { get; set; }


        public ICollection<TelemetryData> TelemetryData { get; set; } 
    }
}
