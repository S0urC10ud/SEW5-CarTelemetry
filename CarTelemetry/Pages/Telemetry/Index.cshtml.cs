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
    public class IndexModel : PageModel
    {
        private readonly CarTelemetry.Data.CarTelemetryContext _context;

        public int PageId { get; set; }

        public IndexModel(CarTelemetry.Data.CarTelemetryContext context)
        {
            _context = context;
        }

        public IList<TelemetryData> TelemetryData { get;set; }

        public async Task OnGetAsync(int pageId)
        {
            TelemetryData = await _context.TelemetryData.ToListAsync();
            this.PageId = pageId;
        }
    }
}
