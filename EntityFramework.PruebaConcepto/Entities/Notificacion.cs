namespace EntityFramework.PruebaConcepto.Entities;

public class Notificacion
{
    public Guid Id { get; private set; }
    public string Contenido { get; private set; }
    public List<NotificacionHistorico> Historico { get; private set; } = new List<NotificacionHistorico>();

    private Notificacion()
    { } // Constructor privado para EF Core

    private Notificacion(string contenido)
    {
        Id = Guid.NewGuid();
        Contenido = contenido;
        AgregarHistorico(Contenido);
    }

    public static Notificacion CrearNuevaNotificacion(string contenido)
    {
        return new Notificacion(contenido);
    }

    public void ActualizarContenido(string nuevoContenido)
    {
        Contenido = nuevoContenido;
        AgregarHistorico(Contenido);
    }

    private void AgregarHistorico(string contenidoHistorico)
    {
        var historico = NotificacionHistorico.CrearNuevoHistorico(contenidoHistorico, Id);
        Historico.Add(historico);
    }
}