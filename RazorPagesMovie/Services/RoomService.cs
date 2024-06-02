using MyApp.Namespace;

public class RoomService
{
    private readonly AppDbContext _contex;

    public RoomService(AppDbContext context)
    {
      this._contex=context;
    }

    public void AddRoom(Room room)
    {
        _contex.Add(room);
        _contex.SaveChanges();
    }

   public List<Room>GetRooms()
   {
        return _contex.Rooms.ToList<Room>();
   }


}