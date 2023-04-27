using BlazorApp1.Shared.Excepciones;
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
    }
}
