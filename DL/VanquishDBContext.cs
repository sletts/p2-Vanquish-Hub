using Microsoft.EntityFrameworkCore;
using Models;

namespace DL
{
    public class VanquishDBContext:DbContext
    {
        public VanquishDBContext() : base()
        {

        }
        public VanquishDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> users { get; set; }
        public DbSet<Artwork> artworks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            //modelBuilder.Entity<User>()
            //    .HasData(new User { Username = "Admin", Password = "AdminPassword", Email = "Admin@gmail.com", Phone = "111-111-1111", IsAdmin = true, Id = 1});
            
            modelBuilder.Entity<Artwork>()
                .Property(a => a.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            //modelBuilder.Entity<Artwork>()
            //    .HasData(new Artwork { PokemonName = "Temp Poke Name", ArtWorkName = "Temp Art Name", UserId = 1, Id = 1});
        }
    }
}
