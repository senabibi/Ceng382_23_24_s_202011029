using Newtonsoft.Json;

public class Program
{
    public static void Main(string[] args)
    {
        // Load room data from Data.json
        string json = File.ReadAllText("Data.json"); // Replace with your actual file path
        List<Room> rooms = JsonConvert.DeserializeObject<List<Room>>(json);

        ReservationHandler handler = new ReservationHandler();

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
                    AddReservation(handler, rooms);
                    break;
                case "2":
                    DeleteReservation(handler);
                    break;
                case "3":
                    handler.DisplayWeeklySchedule();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    private static void AddReservation(ReservationHandler handler, List<Room> rooms)
    {
        Console.WriteLine("Enter date (YYYY-MM-DD): ");
        DateTime date = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Enter time (HH:MM): ");
        DateTime time = DateTime.Parse(Console.ReadLine() + ":00"); // Assuming time format is HH:MM

        Console.WriteLine("Enter your name: ");
        string name = Console.ReadLine();

        // Select room
        int selectedRoomId;
        do
        {
            Console.WriteLine("Select room:");
            for (int i = 0; i < rooms.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {rooms[i].RoomName} (Capacity: {rooms[i].Capacity})");
            }

            string roomIdInput = Console.ReadLine();
            if (int.TryParse(roomIdInput, out selectedRoomId) && selectedRoomId > 0 && selectedRoomId <= rooms.Count)
            {
                break; // Valid room selection
            }
            else
            {
                Console.WriteLine("Invalid room selection. Please try again.");
            }
        } while (true);

        Room selectedRoom = rooms[selectedRoomId - 1]; // Adjust index for zero-based list

        Reservation reservation = new Reservation
        {
            Date = date,
            Time = time,
            ReserverName = name,
            Room = selectedRoom
        };

        if (handler.AddReservation(reservation))
        {
            Console.WriteLine("Reservation added successfully!");
        }
        else
        {
            Console.WriteLine("Sorry, this time slot is already reserved.");
        }
    }

    private static void DeleteReservation(ReservationHandler handler)
    {
        // Implement DeleteReservation logic
        Console.WriteLine("Delete Reservation functionality not yet implemented.");
    }
}
