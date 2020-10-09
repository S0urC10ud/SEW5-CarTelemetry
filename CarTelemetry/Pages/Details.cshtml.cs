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
    public class DetailsModel : PageModel
    {
        private readonly CarTelemetry.Data.CarTelemetryContext _context;

        public DetailsModel(CarTelemetry.Data.CarTelemetryContext context)
        {
            _context = context;
        }

        public Car Car { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car = await _context.Car.Include(s=>s.TelemetryData).FirstOrDefaultAsync(m => m.CarId == id);

            if (Car == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
