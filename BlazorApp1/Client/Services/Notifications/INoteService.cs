using BlazorApp1.Shared.Excepciones;
using Radzen;
using System;

namespace BlazorApp1.Client.Services.Notifications
{
    public interface INoteService
    {
        public void NotifyResponse(ExceptionResponse exceptionResponse);
        public void NotifyNull(NullReferenceException nullReferenceException);
        public void NotifyVoidData();
        public void NotifyTime();
        public void NotifyOtNoCerrada(BlazorApp1.Shared.Modelo.OT.OrdenTrabajo ordenTrabajo);
        public void NotifyOtCerrada(BlazorApp1.Shared.Modelo.OT.OrdenTrabajo ordenTrabajo);
        public void NotifyBase(string Titulo,string Detalle, NotificationSeverity Gravedad = NotificationSeverity.Success, double Duracion = 5000d);
    }
}
