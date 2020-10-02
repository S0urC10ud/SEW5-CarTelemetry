using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarTelemetry.Data;
using CarTelemetry.Model;

namespace CarTelemetry.Pages
{
    public class CreateModel : PageModel
    {
        private readonly CarTelemetry.Data.CarTelemetryContext _context;

        public CreateModel(CarTelemetry.Data.CarTelemetryContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Car Car { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Car.Add(Car);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
