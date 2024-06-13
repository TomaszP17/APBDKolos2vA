using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KolosAPBD2a.Models;

[Table("character_titles")]
[PrimaryKey("CharacterId", "TitleId")]
public class CharacterTitle
{
    [Column("CharacterId")]
    [ForeignKey("Character")]
    public int CharacterId { get; set; }
    
    [Column("Title")]
    [ForeignKey("TitleId")]
    public int TitleId { get; set; }
    
    [Column("AcquiredAt")]
    public DateTime AcquiredAt { get; set; }

    public Character Character { get; set; }
    
    public Title Title { get; set; }
}