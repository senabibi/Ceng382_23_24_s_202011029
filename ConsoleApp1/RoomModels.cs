using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace YourProjectName.Models
{
    public class Room
    {
        [JsonPropertyName("roomId")]
        public string RoomId { get; set; }

        [JsonPropertyName("roomName")]
        public string RoomName { get; set; }

        [JsonPropertyName("capacity")]
        public int Capacity { get; set; }
    }

    public class RoomData
    {
        [JsonPropertyName("Room")]
        public List<Room> Rooms { get; set; }
    }
}
