using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorPagesMovie.Pages
{
    public class ListRoomsModel : PageModel
    {
        private readonly AppDbContext _context;

        public ListRoomsModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Room> Rooms { get; set; }

        public async Task OnGetAsync()
        {
            Rooms = await _context.Rooms.AsNoTracking().ToListAsync();
        }
    }
}
