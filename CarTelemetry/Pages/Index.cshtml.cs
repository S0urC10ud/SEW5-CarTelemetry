using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarTelemetry.Data;
using CarTelemetry.Model;

namespace CarTelemetry.Pages
{
    public class IndexModel : PageModel
    {
        private readonly CarTelemetry.Data.CarTelemetryContext _context;

        public IndexModel(CarTelemetry.Data.CarTelemetryContext context)
        {
            _context = context;
        }

        public IList<Car> Car { get;set; }

        public async Task OnGetAsync()
        {
            Car = await _context.Car.ToListAsync();
        }
    }
}
