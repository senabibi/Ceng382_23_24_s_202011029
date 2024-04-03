using System;

public class ReservationHandler
{
    private Reservation[,] weeklySchedule;

    public ReservationHandler()
    {
        weeklySchedule = new Reservation[7, 24];
    }

    public void AddReservation(Reservation reservation)
    {
        int dayIndex = (int)reservation.Date.DayOfWeek;
        int hourIndex = reservation.Time.Hour;

        if (weeklySchedule[dayIndex, hourIndex] == null)
        {
            weeklySchedule[dayIndex, hourIndex] = reservation;
            Console.WriteLine("Reservation added successfully!");
        }
        else
        {
            Console.WriteLine("There is already a reservation at this time.");
        }
    }

    public void DeleteReservation(Reservation reservation)
    {
        int dayIndex = (int)reservation.Date.DayOfWeek;
        int hourIndex = reservation.Time.Hour;

        if (weeklySchedule[dayIndex, hourIndex] != null)
        {
            weeklySchedule[dayIndex, hourIndex] = null;
            Console.WriteLine("Reservation deleted successfully!");
        }
        else
        {
            Console.WriteLine("No reservation found at this time.");
        }
    }

    public void DisplayWeeklySchedule()
    {
        Console.WriteLine("This week's schedule:");
        string[] daysOfWeek = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };

        for (int day = 0; day < 7; day++)
        {
            Console.WriteLine($"Day: {daysOfWeek[day]}");
            for (int hour = 0; hour < 24; hour++)
            {
                Reservation reservation = weeklySchedule[day, hour];
                if (reservation != null)
                {
                    Console.WriteLine($"Time: {reservation.Time.ToShortTimeString()}, Room: {reservation.Room.RoomName}, Reserver: {reservation.ReserverName}");
                }
                else
                {
                    Console.WriteLine($"Time: {hour}:00, Room: Available");
                }
            }
            Console.WriteLine();
        }
    }
}
