using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KolosAPBD2a.Models;

[Table("items")]
public class Item
{
    [Key]
    [Column("Id")]
    public int Id { get; set; }
    
    [Column("Name")]
    [MaxLength(100)]
    public string Name { get; set; }
    
    [Column("Weight")]
    public int Weight { get; set; }

    public IEnumerable<BackPack> BackPacks { get; set; }
}