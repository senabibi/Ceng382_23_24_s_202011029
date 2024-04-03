using System;
using System.IO;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
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
