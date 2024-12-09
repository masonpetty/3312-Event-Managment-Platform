using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using EventManagementPlatform.Models;

namespace EventManagementPlatform.Pages
{
    public class AttendeesModel : PageModel
    {
        private readonly EventManagementContext _context;

        public AttendeesModel(EventManagementContext context)
        {
            _context = context;
        }

        public IList<Attendee> Attendees { get; set; } = new List<Attendee>();


        public async Task OnGetAsync()
        {
            Attendees = await _context.Attendees
                .Include(a => a.EventAttendees)
                .ThenInclude(ea => ea.Event)
                .ToListAsync();
        }
    }
}