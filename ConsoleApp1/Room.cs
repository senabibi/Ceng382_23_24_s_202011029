using System.Text.Json.Serialization;

public class Room
{
    public Room(string roomId)
    {
        RoomId = roomId;
    }

    [JsonPropertyName("roomId")]
    public string RoomId { get; set; }

    [JsonPropertyName("roomName")]
    public string RoomName { get; set; }

    [JsonPropertyName("capacity")]
    public string Capacity { get; set; }
}
