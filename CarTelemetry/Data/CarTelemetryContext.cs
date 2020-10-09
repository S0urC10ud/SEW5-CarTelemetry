using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarTelemetry.Model;
using EntityFrameworkCore.Triggers;

namespace CarTelemetry.Data
{
    public class CarTelemetryContext : DbContextWithTriggers
    {
        public CarTelemetryContext (DbContextOptions<CarTelemetryContext> options)
            : base(options)
        {
        }

        public DbSet<CarTelemetry.Model.Car> Car { get; set; }

        public DbSet<CarTelemetry.Model.TelemetryData> TelemetryData { get; set; }
    }
}
