using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KolosAPBD2a.Models;

[Table("titles")]
public class Title
{
    [Key]
    [Column("Id")]
    public int Id { get; set; }
    
    [Column("Name")]
    [MaxLength(100)]
    public string Name { get; set; }

    public IEnumerable<CharacterTitle> CharacterTitles { get; set; }
}