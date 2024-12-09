using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventManagementPlatform.Models;

namespace _3312_Event_Managment_Platform.Pages.Events
{
    public class DetailsModel : PageModel
    {
        private readonly EventManagementPlatform.Models.EventManagementContext _context;

        public DetailsModel(EventManagementPlatform.Models.EventManagementContext context)
        {
            _context = context;
        }

        public Event Event { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var event = await _context.Events.FirstOrDefaultAsync(m => m.EventId == id);

            if (event is not null)
            {
                Event = event;

                return Page();
            }

            return NotFound();
        }
    }
}
