public interface IReservationService
{
  void AddReservation(Reservation reservation, string reserverName);
  void DeleteReservation(Reservation reservation);
  List<Reservation> DisplayWeeklySchedule(DateTime startOfWeek);
}
