using System.Text.Json.Serialization;

namespace Application.Common.Models
{
    public class Result
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("response")]
        public object? Response { get; set; }
    }
}
