using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SOneWeb.Api.DTOs
{
    public class UserCreateDto
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }

    public class UserReadDto
    {
        public int FirtsName { get; set; }
        public int LastName { get; set; }
    }
    
       public class UserUpdateDto : UserReadDto
    {
        [Required]
        [Column("id")]
        public int Id { get; set; }
    }
}