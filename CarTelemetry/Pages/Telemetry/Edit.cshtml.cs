using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarTelemetry.Data;
using CarTelemetry.Model;

namespace CarTelemetry.Pages.Telemetry
{
    public class EditModel : PageModel
    {
        private readonly CarTelemetry.Data.CarTelemetryContext _context;

        public EditModel(CarTelemetry.Data.CarTelemetryContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TelemetryData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TelemetryDataExists(TelemetryData.IdTelemetryData))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/Telemetry/Index", new { pageId = TelemetryData.CarId });
        }

        private bool TelemetryDataExists(int id)
        {
            return _context.TelemetryData.Any(e => e.IdTelemetryData == id);
        }
    }
}
