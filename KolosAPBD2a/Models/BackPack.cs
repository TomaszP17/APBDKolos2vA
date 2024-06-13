using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KolosAPBD2a.Models;

[Table("backpacks")]
[PrimaryKey("CharacterId", "ItemId")]
public class BackPack
{
    [ForeignKey("Character")]
    [Column("CharacterId")]
    public int CharacterId { get; set; }
    
    [ForeignKey("Item")]
    [Column("ItemId")]
    public int ItemId { get; set; }
    
    [Column("Amount")]
    public int Amount { get; set; }
    
    public Character Character { get; set; }
    
    public Item Item { get; set; }
    
}