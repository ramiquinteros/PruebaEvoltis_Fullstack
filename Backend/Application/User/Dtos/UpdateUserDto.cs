using System.Text.Json.Serialization;

namespace Application.User.Dtos
{
    public class UpdateUserDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("last_name")]
        public string? LastName { get; set; }
        
        [JsonPropertyName("email")]
        public string? Email { get; set; }
    }
}
