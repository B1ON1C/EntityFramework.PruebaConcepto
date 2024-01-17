namespace EntityFramework.PruebaConcepto.Entities;

public class NotificacionHistorico
{
    public Guid Id { get; private set; }
    public DateTime Fecha { get; private set; }
    public string ContenidoHistorico { get; private set; }
    public Guid NotificacionId { get; private set; }
    public Notificacion Notificacion { get; private set; }

    private NotificacionHistorico()
    { } // Constructor privado para EF Core

    private NotificacionHistorico(string contenidoHistorico, Guid notificacionId)
    {
        Id = Guid.NewGuid();
        Fecha = DateTime.Now;
        ContenidoHistorico = contenidoHistorico;
        NotificacionId = notificacionId;
    }

    public static NotificacionHistorico CrearNuevoHistorico(string contenidoHistorico, Guid notificacionId)
    {
        return new NotificacionHistorico(contenidoHistorico, notificacionId);
    }
}