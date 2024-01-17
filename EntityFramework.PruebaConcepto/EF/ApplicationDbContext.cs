using EntityFramework.PruebaConcepto.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.PruebaConcepto.EF;

public class ApplicationDbContext : DbContext
{
    //SQL Server:
    //public const string ConnectionString = "Server=(LocalDb)\\MSSQLLocalDB;Database=EntityFrameworkPruebaConcepto;Integrated Security=True";
    //SQL Express:
    public const string ConnectionString = "Server = DESKTOP-SRUHI3C\\SQLEXPRESS;Database=EntityFrameworkPruebaConcepto;Trusted_Connection=True;TrustServerCertificate=True;";

    public DbSet<Notificacion> Notificaciones { get; set; }
    public DbSet<NotificacionHistorico> NotificacionesHistorico { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionString, sqlServerAction =>
        {
            sqlServerAction.EnableRetryOnFailure(1);
            sqlServerAction.CommandTimeout(30);
        });
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NotificacionHistorico>()
            .HasOne(nh => nh.Notificacion)
            .WithMany(n => n.Historico)
            .HasForeignKey(nh => nh.NotificacionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}