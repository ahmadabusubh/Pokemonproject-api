using Microsoft.EntityFrameworkCore;
using Pokemonproject.Model;

namespace Pokemonproject.data
{
    public class datacontexts : DbContext
    {
        public datacontexts(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Owner> Owner { get; set; }
        public DbSet<Pokemon> Pokemon { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<Reviewer> Reviewer { get; set; }
        public DbSet<PokemonCategory> PokemonCategory { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Token> Token { get; set; }


        public DbSet<PokemonOwner> PokemonOwner { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PokemonCategory>()
                .HasKey(sc => new { sc.PokemonId, sc.CategoryId });
            modelBuilder.Entity<PokemonCategory>()
                .HasOne(sc => sc.Category)
                .WithMany(s => s.PokemonCategory)
                .HasForeignKey(sc => sc.CategoryId);

            modelBuilder.Entity<PokemonCategory>()
                .HasOne(sc => sc.Pokemon)
                .WithMany(c => c.PokemonCategory)
                .HasForeignKey(sc => sc.PokemonId);

            modelBuilder.Entity<PokemonOwner>()
                .HasKey(sc => new { sc.PokemonId, sc.OwnerId });

            modelBuilder.Entity<PokemonOwner>()
                .HasOne(sc => sc.Owner)
                .WithMany(s => s.PokemonOwner)
                .HasForeignKey(sc => sc.OwnerId);

            modelBuilder.Entity<PokemonOwner>()
                .HasOne(sc => sc.Pokemon)
                .WithMany(c => c.PokemonOwner)
                .HasForeignKey(sc => sc.PokemonId);
        }

    }
}
