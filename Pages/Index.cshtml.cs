using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using EventManagementPlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagementPlatform.Pages
{
    public class IndexModel : PageModel
    {
        private readonly EventManagementContext _context;

        public IndexModel(EventManagementContext context)
        {
            _context = context;
        }

        public IList<Event> Events { get; set; } = new List<Event>();

        public async Task OnGetAsync()
        {
            Events = await _context.Events
                .Include(e => e.EventAttendees)
                .ThenInclude(ea => ea.Attendee)
                .ToListAsync();
        }
    }
}