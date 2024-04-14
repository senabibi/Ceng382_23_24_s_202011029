public class ReservationService : IReservationService
{
  private readonly IReservationRepository _reservationRepository;
  private readonly RoomHandler _roomHandler; // Assuming interaction with RoomHandler

  public ReservationService(IReservationRepository reservationRepository, RoomHandler roomHandler)
  {
    _reservationRepository = reservationRepository;
    _roomHandler = roomHandler;
  }

  public void AddReservation(Reservation reservation, string reserverName)
  {
    // Delegate to reservation repository and handle room availability checks (using _roomHandler)
    // ...
  }

  public void DeleteReservation(Reservation reservation)
  {
    // Delegate to reservation repository
    // ...
  }

  public List<Reservation> DisplayWeeklySchedule(DateTime startOfWeek)
  {
    // Implement logic to retrieve reservations for the week
    // ...
  }
}
