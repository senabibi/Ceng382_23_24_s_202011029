using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Namespace
{
    public class ShowRoomModel : PageModel
    {



        //public ShowRoomModel ShowRoom { get; set; } = default!; 
        private readonly AppDbContext show_contex ; //readonly üzeri değiştirilemez
         RoomService roomService;
    public ShowRoomModel(AppDbContext context)
    {   this.roomService = new RoomService(context);

    }
        public List<Room> RoomList { get; set; } = default!;

        public void OnGet()
        {
            /*RoomList = (from item in show_contex.Rooms
                        select item).ToList();*/
                        RoomList=roomService.GetRooms();
        }


    }
}
