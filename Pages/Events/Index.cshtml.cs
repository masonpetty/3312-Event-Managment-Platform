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
    public class IndexModel : PageModel
    {
        private readonly EventManagementPlatform.Models.EventManagementContext _context;

        public IndexModel(EventManagementPlatform.Models.EventManagementContext context)
        {
            _context = context;
        }

        public IList<Event> Event { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Event = await _context.Events.ToListAsync();
        }
    }
}
