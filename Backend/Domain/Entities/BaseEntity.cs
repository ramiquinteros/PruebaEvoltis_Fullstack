using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public abstract class BaseEntity
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("creation_date")]
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
