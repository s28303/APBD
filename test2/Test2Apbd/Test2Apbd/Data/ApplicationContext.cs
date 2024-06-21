using Microsoft.EntityFrameworkCore;
using Test2Apbd.Entities;

namespace Test2Apbd.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
            
        }

        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Backpack> Backpacks { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<CharacterTitle> CharactersTitles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Character>().HasData(new List<Character>()
            {
                new() {Id = 1, FirstName = "Vladyslav", LastName = "Miekh", CurrentWeight = 50, MaxWeight = 60}
            });

            modelBuilder.Entity<Title>().HasData(new List<Title>()
            {
                new() {Id = 1, Name = "Lord"}
            });

            modelBuilder.Entity<Item>().HasData(new List<Item>()
            {
                new() {Id = 1, Name = "Sword", Weight = 5}
            });

            modelBuilder.Entity<Backpack>().HasData(new List<Backpack>()
            {
                new() {CharacterId = 1, ItemId = 1, Amount = 2}
            });

            modelBuilder.Entity<CharacterTitle>().HasData(new List<CharacterTitle>()
            {
                new() {CharacterId = 1, TitleId = 1, AcquiredAt = DateTime.Now}
            });
        }
    }
}
