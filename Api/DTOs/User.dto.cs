using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SOneWeb.Api.DTOs
{
    public class UserCreateDto
    {
        [Required]
        [Column("first_name")]
        public int FirtsName { get; set; }

        [Required]
        [Column("last_name")]
        public int LastName { get; set; }
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