using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace SOneWeb.Domain.Entities
{
    [Table("owners")]
    public abstract class UserEntity : BaseEntity
    {
        [Required]
        [Column("first_name")]
        [NotNull]
        public required string FirstName { get; set; }

        [Required]
        [Column("last_name")]
        [NotNull]
        public required string LastName { get; set; }
    }
}