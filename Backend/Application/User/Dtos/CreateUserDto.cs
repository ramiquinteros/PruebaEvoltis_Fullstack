using System.Text.Json.Serialization;

namespace Application.User.Dtos
{
    public class CreateUserDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}
