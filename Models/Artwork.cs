using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("artwork")]
    public class Artwork
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [ForeignKey("id")]
        [Column("userid")]
        public int UserId { get; set; }
        [Column("pokemonname")]
        public string PokemonName { get; set; } = string.Empty;
        [Column("artworkname")]
        public string ArtWorkName { get; set; } = string.Empty;
        [Column("artworkdata")]
        public Byte[]? ArtWorkData { get; set; } = null;
    }
}
