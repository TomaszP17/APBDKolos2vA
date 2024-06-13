using KolosAPBD2a.Models;
using Microsoft.EntityFrameworkCore;

namespace KolosAPBD2a.Contexts;

public class DatabaseContext : DbContext
{
    public DbSet<Item> Items { get; set; }
    public DbSet<BackPack> BackPacks { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<CharacterTitle> CharacterTitles { get; set; }
    public DbSet<Title> Titles { get; set; }
    
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Item>().HasData(new Item
        {
            Id = 1,
            Name = "Kredka",
            Weight = 2
        });

        modelBuilder.Entity<Character>().HasData(new Character
        {
            Id = 1,
            FirstName = "Patryk",
            LastName = "Rozgwiazda",
            CurrentWeight = 100,
            MaxWeight = 200
        });

        modelBuilder.Entity<BackPack>().HasData(new BackPack
        {
            CharacterId = 1,
            ItemId = 1,
            Amount = 5
        });

        modelBuilder.Entity<Title>().HasData(new Title
        {
            Id = 1,
            Name = "Gwiazda"
        });

        modelBuilder.Entity<CharacterTitle>().HasData(new CharacterTitle
        {
            CharacterId = 1,
            TitleId = 1,
            AcquiredAt = DateTime.Now
        });
    }
}