using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarTelemetry.Model;

namespace CarTelemetry.Data
{
    public class CarTelemetryContext : DbContext
    {
        public CarTelemetryContext (DbContextOptions<CarTelemetryContext> options)
            : base(options)
        {
        }

        public DbSet<CarTelemetry.Model.Car> Car { get; set; }
    }
}
