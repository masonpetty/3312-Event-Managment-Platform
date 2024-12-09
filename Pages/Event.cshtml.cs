using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using EventManagementPlatform.Models;

namespace EventManagementPlatform.Pages
{
    public class EventsModel : PageModel
    {
        private readonly EventManagementContext _context;

        public EventsModel(EventManagementContext context)
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