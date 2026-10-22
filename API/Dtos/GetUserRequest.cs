using System.Text.Json.Serialization;

namespace API.Dtos;

public class GetUserRequest {
    public long? Id { get; set; } = null;

    
    [JsonPropertyName("first_name")]
    public required string Firstname { get; set; }

    [JsonPropertyName("last_name")]
    public required string Lastname { get; set; }

    public required string Username { get; set; }
}