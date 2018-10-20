using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBodas.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Llave primaria Compuesta de la tabla - Paquete y Servicio
            // porque un paquete no puede tener dos veces el mismo id de servicio
            modelBuilder.Entity<PaqueteServicio>().HasKey(x => new { x.PaqueteId, x.ServicioId });


            modelBuilder.Entity<Agenda>().HasOne<LugarCena>(a => a.LugarCena).WithMany(c => c.Agendas).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Agenda>().HasOne<LugarCeremonia>(a => a.LugarCeremonia).WithMany(c => c.Agendas).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Agenda>().HasOne<Hotel>(a => a.Hotel).WithMany(h => h.Agendas).OnDelete(DeleteBehavior.Restrict);

            // Valor por defaulr
            modelBuilder.Entity<Agenda>().Property(a => a.Deposito).HasDefaultValue(0);

            //modelBuilder.Entity<Agenda>().HasOne<Hotel>(t => t.Hotel).WithMany(s => s.Agendas).HasForeignKey(s => s.HotelId)
            //    .OnDelete(DeleteBehavior.Restrict);


           

        }

        public DbSet<Agenda> Agendas { get; set; }
        public DbSet<Hotel> Hoteles { get; set; }
        public DbSet<Ejecutivo> Ejecutivos { get; set; }
        public DbSet<Coordinador> Cordinadores { get; set; }
        public DbSet<LugarCena> LugaresCena { get; set; }
        public DbSet<LugarCeremonia> LugaresCeremonia { get; set; }
        public DbSet<BackUp> BackUps { get; set; }
        public DbSet<Horas> Horas { get; set; }
        public DbSet<TipoCeremonia> TiposCeremonia { get; set; }
        public DbSet<Agencia> Agencias { get; set; }
        public DbSet<DiasBloqueados> DiasBloquedo { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Historial> historial { get; set; }
        public DbSet<MasterFile> MasterFile { get; set; }
        public DbSet<MasterFileContent> MasterFileContenido { get; set; }
        public DbSet<Paquete> Paquetes { get; set; }
        public DbSet<PaqueteServicio> PaqueteServicio { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<CategoriaServicio> CategoriasServicios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Role> Roles { get; set; }

    }
}
