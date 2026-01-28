using AnimalShelter.Api.Models;
using AnimalShelter.Api.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Api.Data
{
    public class AnimalShelterDbContext : DbContext
    {
        public AnimalShelterDbContext(DbContextOptions <AnimalShelterDbContext> options) : base(options)
        {
            //CONFIGURAMOS NUESTRO DBSET
        }


        //ENTIDADES EN EF
        public DbSet<AnimalModel> Animals { get; set; }
        public DbSet<AdoptionModel> Adoptions { get; set; }
        public DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasPostgresEnum<AdoptionState>();
            modelBuilder.HasPostgresEnum<AnimalState>();
            modelBuilder.HasPostgresEnum<AnimalType>();
            modelBuilder.HasPostgresEnum<UserRol>();
            modelBuilder.HasPostgresEnum<UserState>();


            // Configuración de la tabla Adoptions con múltiples FK hacia Users

            modelBuilder.Entity<AdoptionModel>(entity =>
            {
                // ENUM
                entity.Property(a => a.State)
                    .HasColumnType("adoption_state");

                // RELACIONES
                entity.HasOne(a => a.Volunteer)
                    .WithMany(u => u.VolunteerAdoptions)
                    .HasForeignKey(a => a.VolunteerId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(a => a.Adopter)
                    .WithMany(u => u.AdopterAdoptions)
                    .HasForeignKey(a => a.AdopterId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(a => a.Animal)
                    .WithMany(an => an.Adoptions)
                    .HasForeignKey(a => a.AnimalId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<AnimalModel>(entity =>
            {
                entity.Property(a => a.Type)
                    .HasColumnType("animal_type");

                entity.Property(a => a.State)
                    .HasColumnType("animal_state");
            });


            modelBuilder.Entity<UserModel>(entity =>
            {
                entity.Property(u => u.Rol)
                    .HasColumnType("user_rol");

                entity.Property(u => u.State)
                    .HasColumnType("user_state");
            });
        }
    }
}
