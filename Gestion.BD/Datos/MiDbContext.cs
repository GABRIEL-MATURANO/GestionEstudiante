using Gestion.BD.Datos.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.BD.Datos
{
    public class MiDbContext : DbContext
    {
        public DbSet<Persona> Personas { get; set; }
        
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> rols { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Carrera> Carreras { get; set; }   

        
        public MiDbContext(DbContextOptions<MiDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relación 1:1 entre Usuario y Persona
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Personas)
                .WithOne(p => p.Usuarios)
                .HasForeignKey<Usuario>(u => u.PersonaId);

           

            // Relación N:1 entre Usuario y Rol
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Rols)
                .WithMany(r => r.Usuarios)
                .HasForeignKey(u => u.RolId);

            // Relación 1:1 entre Estudiante y Persona
            modelBuilder.Entity<Estudiante>()
                .HasOne(e => e.Personas)
                .WithOne(p => p.Estudiantes)
                .HasForeignKey<Estudiante>(e => e.PersonaId); 

            // Relación muchos a muchos entre Estudiantes y Carreras
            modelBuilder.Entity<EstudianteCarrera>()
                .HasKey(ec => new { ec.EstudiantesID, ec.CarrerasId});

            modelBuilder.Entity<EstudianteCarrera>()
                .HasOne(ec => ec.Estudiantes)
                .WithMany(e => e.EstudiantesCarreras)
                .HasForeignKey(ec => ec.EstudiantesID);

            modelBuilder.Entity<EstudianteCarrera>()
                .HasOne(ec => ec.Carreras)
                .WithMany(c => c.EstudiantesCarreras)
                .HasForeignKey(ec => ec.CarrerasId);


        }
    }
}
