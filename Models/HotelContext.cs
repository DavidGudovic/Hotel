using Microsoft.EntityFrameworkCore;

namespace Hotel.Models
{
    public class HotelContext : DbContext
    {
        public HotelContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-VV2JJVO;Database=Hotel;Integrated Security=True;");
        }
        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<Rezervacija> Rezervacije { get;set; }
        public DbSet<Kupon> Kuponi { get; set; }
        public DbSet<Ponuda> Ponude { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Korisnik>().ToTable("Korisnici");
            modelBuilder.Entity<Rezervacija>().ToTable("Rezervacije");
            modelBuilder.Entity<Ponuda>().ToTable("Ponude");
            modelBuilder.Entity<Kupon>().ToTable("Kuponi");
        }
    }
}
