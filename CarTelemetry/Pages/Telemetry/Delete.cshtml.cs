using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarTelemetry.Data;
using CarTelemetry.Model;

namespace CarTelemetry.Pages.Telemetry
{
    public class DeleteModel : PageModel
    {
        private readonly CarTelemetry.Data.CarTelemetryContext _context;

        public DeleteModel(CarTelemetry.Data.CarTelemetryContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TelemetryData TelemetryData { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TelemetryData = await _context.TelemetryData.FirstOrDefaultAsync(m => m.IdTelemetryData == id);

            if (TelemetryData == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }



            TelemetryData = await _context.TelemetryData.FindAsync(id);
            int carId = TelemetryData.CarId;

            if (TelemetryData != null)
            {
                _context.TelemetryData.Remove(TelemetryData);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/Telemetry/Index", new { pageId = carId });
        }
    }
}
