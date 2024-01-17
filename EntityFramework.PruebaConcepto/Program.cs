using EntityFramework.PruebaConcepto.EF;
using EntityFramework.PruebaConcepto.Entities;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

using (var context = new ApplicationDbContext())
{
    // *************************** Insertar notificación
    var nuevaNotificacion = Notificacion.CrearNuevaNotificacion("Nueva notificación");
    context.Notificaciones.Add(nuevaNotificacion);
    Console.WriteLine($"Estado Notificacion {nuevaNotificacion.Id} antes de Add: {context.Entry(nuevaNotificacion).State}");
    foreach (var historico in nuevaNotificacion.Historico)
    {
        Console.WriteLine($"Estado historico {historico.Id} antes de Add: {context.Entry(historico).State}");
    }
    var numRegistrosAdd = context.SaveChanges();
    Console.WriteLine($"Registros afectados en Add {numRegistrosAdd}");

    // ************************** Actualizar notificación con nuevo historial
    nuevaNotificacion.ActualizarContenido("Notificación actualizada");
    context.Notificaciones.Update(nuevaNotificacion);
    Console.WriteLine($"Estado Notificacion {nuevaNotificacion.Id} antes de Update: {context.Entry(nuevaNotificacion).State}");
    foreach (var historico in nuevaNotificacion.Historico)
    {
        Console.WriteLine($"Estado historico {historico.Id} antes de Update: {context.Entry(historico).State}");
    }

    //var numRegistrosUpdate = context.SaveChanges();
    //Console.WriteLine($"Registros afectados en Update: {numRegistrosUpdate}");

    //Pruebas:
    //var historial = NotificacionHistorico.CrearNuevoHistorico(nuevaNotificacion.Contenido, nuevaNotificacion.Id);
    //context.NotificacionesHistorico.Add(historial);
    //context.Entry(nuevaNotificacion).Reload();
    //var notificacionActualizada = context
    //    .Notificaciones
    //    .AsNoTracking()
    //    .FirstOrDefault(n => n.Id == nuevaNotificacion.Id);
    // Acceder al estado de Historico
    //¿Utilizar Attach en lugar de Update para evitar marcar las entidades relacionadas para actualización?
    //context.Notificaciones.Attach(nuevaNotificacion);

    // Eliminar notificación
    context.Notificaciones.Remove(nuevaNotificacion);
    var numRegistrosRemove = context.SaveChanges();
    Console.WriteLine($"Registros afectados en Remove {numRegistrosRemove}");
    Console.WriteLine($"Estado Notificacion {nuevaNotificacion.Id} después de Remove: {context.Entry(nuevaNotificacion).State}");
}