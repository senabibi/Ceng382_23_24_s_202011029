public class ReservationRepository : IReservationRepository
{
    private List<Reservation> reservations = new List<Reservation>();

    public void AddReservation(Reservation reservation)
    {
        reservations.Add(reservation);
    }

    public void DeleteReservation(Reservation reservation)
    {
        reservations.Remove(reservation);
    }

    public IEnumerable<Reservation> GetAllReservations()
    {
        return reservations;
    }
}
