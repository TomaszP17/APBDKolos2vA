using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KolosAPBD2a.Models;

[Table("characters")]
public class Character
{
    [Key]
    [Column("Id")]
    public int Id { get; set; }
    
    [Column("FirstName")]
    [MaxLength(50)]
    public string FirstName { get; set; }
    
    [Column("LastName")]
    [MaxLength(120)]
    public string LastName { get; set; }
    
    [Column("CurrentWeight")]
    public int CurrentWeight { get; set; }
    
    [Column("MaxWeight")]
    public int MaxWeight { get; set; }

    public IEnumerable<BackPack> BackPacks { get; set; }
    public IEnumerable<CharacterTitle> CharacterTitles { get; set; }
}