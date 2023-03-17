using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SydyTeste.Data.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Team
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 3)]
        [JsonPropertyName("nome")]
        public required string Name { get; set; }
    }
}
