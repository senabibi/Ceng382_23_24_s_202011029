
public class RoomHandler
{
    public static IEnumerable<Room> GetRooms()
    {
        RoomHandler handler = new RoomHandler();
        List<Room> rooms = handler.ReadRoomsFromJson();
        return rooms;
    }

    public void SaveRooms(IEnumerable<Room> rooms)
    {
        
        WriteRoomsToJson(rooms);
    }


    private List<Room> ReadRoomsFromJson()
    {
        
        throw new NotImplementedException();
    }

    private void WriteRoomsToJson(IEnumerable<Room> rooms)
    {
        
        throw new NotImplementedException();
    }
}
