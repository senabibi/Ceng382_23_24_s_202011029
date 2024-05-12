using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using RoomModels.Models;  // Adjust this to the namespace of your Room and RoomData classes

class Program
{
    public static void Main(string[] args)
    {
        string logFilePath = "LogData.json";
        var logger = new FileLogger(logFilePath);
        var reservationRepository = new ReservationRepository();
        var reservationService = new ReservationService(reservationRepository, logger);

        // Load room data from JSON file
        string jsonFilePath = "Data.json";
        RoomData roomData = LoadRoomData(jsonFilePath);

        // Example room data usage
        Room room = roomData.Rooms.Find(r => r.RoomId == "001");
        if (room != null)
        {
            var reservation = new Reservation(DateTime.Now, DateTime.Today, "John Doe", room);
            reservationService.AddReservation(reservation);
            // Perform other operations as needed
        }
        else
        {
            Console.WriteLine("Room not found.");
        }
    }

    private static RoomData LoadRoomData(string filePath)
    {
        try
        {
            string jsonString = File.ReadAllText(filePath);
            RoomData roomData = JsonSerializer.Deserialize<RoomData>(jsonString);
            if (roomData == null)
            {
                Console.WriteLine("Failed to parse room data.");
                return new RoomData { Rooms = new List<Room>() };
            }
            return roomData;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading room data: {ex.Message}");
            return new RoomData { Rooms = new List<Room>() };
        }
    }
}
