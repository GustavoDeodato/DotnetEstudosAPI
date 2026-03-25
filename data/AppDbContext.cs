using Microsoft.EntityFrameworkCore;

namespace DotnetEstudo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Animal> Animais { get; set; }
        public DbSet<Sexo> Sexos { get; set; }
        public DbSet<Habitat> Habitats { get; set; }
        public DbSet<HabitatAnimal> HabitatAnimais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>().ToTable("tbl_animal");
            modelBuilder.Entity<Sexo>().ToTable("tbl_sexo");
            modelBuilder.Entity<Habitat>().ToTable("tbl_habitat");
            modelBuilder.Entity<HabitatAnimal>().ToTable("habitat_animal");

            base.OnModelCreating(modelBuilder);
        }
    }
}
