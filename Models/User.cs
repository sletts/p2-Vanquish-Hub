using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("username")]
        public string Username { get; set; } = string.Empty;
        [Column("email")]
        public string Email { get; set; } = string.Empty;
        [Column("password")]
        public string Password { get; set; } = string.Empty;
        [Column("phone")]
        public string Phone { get; set; } = string.Empty;
        [Column("isadmin")]
        public bool IsAdmin { get; set; }

    }
}