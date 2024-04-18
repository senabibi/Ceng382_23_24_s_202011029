public class ReservationHandler
{
    private readonly IReservationRepository reservationRepository;
    private readonly RoomHandler roomHandler;
    private readonly LogHandler logHandler;

    public ReservationHandler(IReservationRepository reservationRepository, RoomHandler roomHandler, LogHandler logHandler)
    {
        this.reservationRepository = reservationRepository;
        this.roomHandler = roomHandler;
        this.logHandler = logHandler;
    }

    public void AddReservation(Reservation reservation)
    {
        reservationRepository.AddReservation(reservation);
        LogRecord log = new LogRecord(DateTime.Now, reservation.ReserverName, reservation.Room.RoomName);
        logHandler.AddLog(log, new FileLogger());
    }

    public void DeleteReservation(Reservation reservation)
    {
        reservationRepository.DeleteReservation(reservation);
        LogRecord log = new LogRecord(DateTime.Now, reservation.ReserverName, reservation.Room.RoomName);
        logHandler.AddLog(log, new FileLogger());
    }

    public IEnumerable<Reservation> GetAllReservations()
    {
        return reservationRepository.GetAllReservations();
    }

}
