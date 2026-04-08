using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ZCPWebServices.Data.Model;
using ZCPWebServices.Data.Models;
using ZCPWebServices.Data.ViewModels;

namespace ZCPWebServices.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TicketsVM>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("TicketsWS");
            });

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CaracterizacionesVM>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("CaracterizacionesWS");
            });

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ParadasRelojVM>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("ParadasRelojWS");
            });
            
            modelBuilder.Entity<ViewModels.BaseZcpsVM>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("BaseZcpsWS");
            });
           
            modelBuilder.Entity<Models.BaseZcp>()
                .HasMany(b => b.Visitas)
                .WithOne(v => v.BaseZcp)
                .HasForeignKey(v => v.idSede)
                .IsRequired();
           
        }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<TicketsVM> TicketsView { get; set; }

        public DbSet<Caracterizacion> Caracterizaciones { get; set; }

        public DbSet<CaracterizacionesVM> CaracterizacionesView { get; set; }

        public DbSet<ParadaReloj> ParadaReloj { get; set; }

        public DbSet<ParadasRelojVM> ParadasRelojView { get; set; }

        public DbSet<Models.BaseZcp> BaseZcp { get; set; }

        public DbSet<ViewModels.BaseZcpsVM> BaseZcpsVM { get; set; }

        public DbSet<Visita> Visitas { get; set; }

        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}
