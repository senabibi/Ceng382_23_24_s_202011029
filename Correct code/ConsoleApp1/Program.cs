using System;
using System.IO;
using System.Text.Json;

class Program
{
    static void Main(string[] args)

public class Program
{
    public static void Main(string[] args)
    {
        string logFilePath = "LogData.json";

        var roomHandler = new RoomHandler();
        var fileLogger = new FileLogger(logFilePath);
        var logHandler = new LogHandler();

        logHandler.LogFilePath = logFilePath;

        IReservationRepository reservationRepository = new ReservationRepository();

        var reservationHandler = new ReservationHandler(
            reservationRepository, roomHandler, logHandler, logFilePath);

        var reservationService = new ReservationService(reservationHandler);

        TestReservationFunctionality(reservationService);

        reservationService.DisplayWeeklySchedule();
    }

    private static void TestReservationFunctionality(IReservationService reservationService)
    {
        var reservation = new Reservation(DateTime.Now, DateTime.Today, "John Doe", new Room("001", "A-101", 30));
        reservationService.AddReservation(reservation);

        reservationService.DeleteReservation(reservation);
    }
}
/* My solution from the previous week didn't adhere to the Single Responsibility Principle (SRP) adequately. 
According to SRP, each class should have a specific responsibility, but in my code, 
some classes were handling multiple tasks. This lack of separation of concerns made the codebase less maintainable.

Additionally, I struggled to implement Dependency Injection (DI) effectively in this project. Without proper DI,
the codebase suffered from tight coupling, making it challenging to replace components or mock dependencies for
testing purposes.
These principles are crucial in web development for creating modular and manageable codebases. 
By following SRP, we ensure that each class or module focuses on a single responsibility,
which enhances maintainability and makes it easier to understand and modify the code. Dependency Injection
promotes loose coupling, allowing for more flexibility in swapping components and facilitating easier testing.
Overall, adhering to these principles leads to more scalable, testable, and maintainable web applications.
    */
    {
        string jsonFilePath = "Data.json";
        string jsonString = File.ReadAllText(jsonFilePath);
        var roomData = JsonSerializer.Deserialize<RoomData>(jsonString);

        var reservationHandler = new ReservationHandler();

        Console.WriteLine("Available Rooms:");
        if (roomData?.Rooms != null)
        {
            foreach (var room in roomData.Rooms)
            {
                Console.WriteLine($"room ID: {room.RoomId}, Name: {room.RoomName}, Capacity: {room.Capacity}");
            }
        }

        Console.WriteLine("\nenter reservation details:");
        Console.Write("Room ID: ");
        string roomId = Console.ReadLine();
        Console.Write("Reservation Date (MM/dd/yyyy): ");
        DateTime reservationDate = DateTime.Parse(Console.ReadLine());
        Console.Write("Reservation Time (HH:mm): ");
        DateTime reservationTime = DateTime.Parse(Console.ReadLine());
        Console.Write("Reserver Name: ");
        string reserverName = Console.ReadLine();

        Room selectedRoom = Array.Find(roomData.Rooms, room => room.RoomId == roomId);
        if (selectedRoom == null)
        {
            Console.WriteLine("Invalid Room ID.");
            return;
        }

        Reservation reservation = new Reservation
        {
            Room = selectedRoom,
            Date = reservationDate.Date,
            Time = reservationTime,
            ReserverName = reserverName
        };

        reservationHandler.AddReservation(reservation);

        reservationHandler.DisplayWeeklySchedule();

        Console.WriteLine("\ndo you want to delete this reservation? (Y/N)");
        string choice = Console.ReadLine();
        if (choice.ToUpper() == "Y")
        {
            Console.WriteLine("\nEnter cancellation details:");
            Console.Write("Room ID: ");
            string cancelRoomId = Console.ReadLine();
            Console.Write("Cancellation Date (MM/dd/yyyy): ");
            DateTime cancelReservationDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Cancellation Time (HH:mm): ");
            DateTime cancelReservationTime = DateTime.Parse(Console.ReadLine());

            Room cancelSelectedRoom = Array.Find(roomData.Rooms, room => room.RoomId == cancelRoomId);
            if (cancelSelectedRoom == null)
            {
                Console.WriteLine("Invalid Room ID.");
                return;
            }

            Reservation cancellationReservation = new Reservation
            {
                Room = cancelSelectedRoom,
                Date = cancelReservationDate.Date,
                Time = cancelReservationTime
            };

            reservationHandler.DeleteReservation(cancellationReservation);

            reservationHandler.DisplayWeeklySchedule();
        }
    }
}
