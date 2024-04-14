public interface IReservationRepository
{
  void AddReservation(Reservation reservation, string reserverName);
  void DeleteReservation(Reservation reservation);
  List<Reservation> GetAllReservations();
}
