public class ReservationRepository : IReservationRepository
{
  private readonly List<Reservation> _reservations;

  public ReservationRepository()
  {
    _reservations = new List<Reservation>();
  }

  public void AddReservation(Reservation reservation, string reserverName)
  {
    // Implement logic to add reservation with validation
    // ...
  }

  public void DeleteReservation(Reservation reservation)
  {
    // Implement logic to delete reservation
    // ...
  }

  public List<Reservation> GetAllReservations()
  {
    return _reservations.ToList(); // Return a copy to avoid modifying internal collection
  }
}
