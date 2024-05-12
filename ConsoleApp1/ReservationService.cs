public class ReservationService : IReservationService
{
    private readonly IReservationRepository _reservationRepository;
    private readonly ILogger _logger;

    public ReservationService(IReservationRepository reservationRepository, ILogger logger)
    {
        _reservationRepository = reservationRepository;
        _logger = logger;
    }

    public void AddReservation(Reservation reservation)
    {
        _reservationRepository.AddReservation(reservation);
        _logger.Log(new LogRecord(DateTime.Now, reservation.ReserverName, reservation.Room.RoomName));
    }

    public void DeleteReservation(Reservation reservation)
    {
        _reservationRepository.DeleteReservation(reservation);
        _logger.Log(new LogRecord(DateTime.Now, reservation.ReserverName, reservation.Room.RoomName));
    }
}
