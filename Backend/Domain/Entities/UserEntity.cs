using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        [Column("name")]
        public string Name { get; set; }

        [Column("last_name")]
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [Column("email")]
        public string Email { get; set; }
    }
}
