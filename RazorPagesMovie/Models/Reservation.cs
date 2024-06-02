public class Reservation
{
    public int Id { get; set; }
    public string ReserverName { get; set; } // Now nullable
    public int RoomId { get; set; }
    public Room Room { get; set; } // Still foreign key for Room
    public DateTime ReservationDate { get; set; }
}
