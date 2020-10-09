using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarTelemetry.Data;
using CarTelemetry.Model;

namespace CarTelemetry.Pages.Telemetry
{
    public class CreateModel : PageModel
    {
        private readonly CarTelemetry.Data.CarTelemetryContext _context;
        public int CarId { get; set; }
        public CreateModel(CarTelemetry.Data.CarTelemetryContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int carId)
        {
            this.CarId = carId;
            TelemetryData = new TelemetryData
            {
                CarId = carId,
            };

            return Page();
        }

        [BindProperty]
        public TelemetryData TelemetryData { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            _context.TelemetryData.Add(TelemetryData);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Telemetry/Index",new { pageId = TelemetryData.CarId});
        }
    }
}
