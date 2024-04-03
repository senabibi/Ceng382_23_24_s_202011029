public class ReservationHandler
{
    private const int DAYS_IN_WEEK = 7;
    private Reservation[,] reservations;

    public ReservationHandler()
    {
        reservations = new Reservation[DAYS_IN_WEEK, 24]; // Assuming a max of 24 reservations per day
    }

    public void AddReservation(Reservation reservation)
    {
        if (IsTimeSlotAvailable(reservation.Date.DayOfWeek, reservation.Time))
        {
            reservations[(int)reservation.Date.DayOfWeek, reservation.Time.Hour] = reservation;
        }
        else
        {
            Console.WriteLine("Sorry, this time slot is already reserved.");
        }
    }

    public void DeleteReservation(Reservation reservation)
    {
        if (reservations[(int)reservation.Date.DayOfWeek, reservation.Time.Hour] != null &&
            reservations[(int)reservation.Date.DayOfWeek, reservation.Time.Hour].ReserverName == reservation.ReserverName)
        {
            reservations[(int)reservation.Date.DayOfWeek, reservation.Time.Hour] = null;
        }
        else
        {
            Console.WriteLine("Reservation not found.");
        }
    }

    public void DisplayWeeklySchedule()
    {
        Console.WriteLine("Weekly Schedule:");

        for (int day = 0; day < DAYS_IN_WEEK; day++)
        {
            Console.WriteLine($"**{Enum.GetName(typeof(DayOfWeek), day)}**");
            for (int hour = 0; hour < 24; hour++)
            {
                if (reservations[day, hour] != null)
                {
                    Console.WriteLine($"- {reservations[day, hour].Time.ToString("hh:mm tt")}: {reservations[day, hour].ReserverName} - Room: {reservations[day, hour].Room.RoomName}");
                }
            }
            Console.WriteLine();
        }
    }

    private bool IsTimeSlotAvailable(DayOfWeek day, DateTime time)
    {
        return reservations[(int)day, time.Hour] == null;
    }
}
