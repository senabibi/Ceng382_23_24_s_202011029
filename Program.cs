using Newtonsoft.Json;

public class Program
{
    public static void Main(string[] args)
    {
        // Load room data from Data.json
        string json = File.ReadAllText("Data.json"); // Replace with your actual file path
        List<Room> rooms = JsonConvert.DeserializeObject<List<Room>>(json);

        // Use interfaces for dependency injection (optional)
        IReservationService reservationService = CreateReservationService();

        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add Reservation");
            Console.WriteLine("2. Delete Reservation");
            Console.WriteLine("3. Display Weekly Schedule");
            Console.WriteLine("4. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddReservation(reservationService, rooms);
                    break;
                case "2":
                    DeleteReservation(reservationService);
                    break;
                case "3":
                    reservationService.DisplayWeeklySchedule(DateTime.Today);
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    private static IReservationService CreateReservationService()
    {
        // Implement logic to create and configure a ReservationService instance
        // This allows for easier mocking or testing with different implementations
        IReservationRepository reservationRepository = new ReservationRepository();
        RoomHandler roomHandler = new RoomHandler(); // Implement RoomHandler logic
        return new ReservationService(reservationRepository, roomHandler);
    }

    private static void AddReservation(IReservationService reservationService, List<Room> rooms)
    {
        // ... (similar logic as before, but delegate to reservationService)
        Console.WriteLine("Enter date (YYYY-MM-DD): ");
        DateTime date = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Enter time (HH:MM): ");
        DateTime time = DateTime.Parse(Console.ReadLine() + ":00"); // Assuming time format is HH:MM

        Console.WriteLine("Enter your name: ");
        string name = Console.ReadLine();

        // Select room (using ReservationService)
        Room selectedRoom = reservationService.SelectRoom(rooms);

        Reservation reservation = new Reservation(date, time, name, selectedRoom);

        if (reservationService.AddReservation(reservation))
        {
            Console.WriteLine("Reservation added successfully!");
        }
        else
        {
            Console.WriteLine("Sorry, this time slot is already reserved.");
        }
    }

    private static void DeleteReservation(IReservationService reservationService)
    {
        // Implement DeleteReservation logic using reservationService
        Console.WriteLine("Delete Reservation functionality not yet implemented.");
    }
}
