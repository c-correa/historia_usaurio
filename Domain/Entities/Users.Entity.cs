using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Identity;

namespace SOneWeb.Domain.Entities
{
    [Table("owners")]
    public abstract class UserEntity : IdentityUser<int>
    {
        [Required]
        [Column("first_name")]
        [NotNull]
        public required string FirstName { get; set; }

        [Required]
        [Column("last_name")]
        [NotNull]
        public required string LastName { get; set; }

        [Required]
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;

        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }
    }
}