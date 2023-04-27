using BlazorApp1.Shared.Excepciones;
using Radzen;
using System;

namespace BlazorApp1.Client.Services.Notifications
{
    public class NoteService : INoteService
    {
        private readonly NotificationService notificationService;
        private readonly int DurationLocal;
        public NoteService(NotificationService notificationService)
        {
            this.notificationService = notificationService;
            this.DurationLocal = 5000;
        }

        public void NotifyResponse(ExceptionResponse exceptionResponse)
        {
            notificationService.Notify(new NotificationMessage()
            {
                Summary = "Error",
                Detail = exceptionResponse.Message,
                Severity = NotificationSeverity.Warning,
                Duration = DurationLocal
            });
        }

        public void NotifyNull(NullReferenceException nullReferenceException)
        {
            notificationService.Notify(new NotificationMessage()
            {
                Summary = "Error",
                Detail = nullReferenceException.Message,
                Severity = NotificationSeverity.Warning,
                Duration = DurationLocal
            });
        }

        public void NotifyVoidData()
        {
            notificationService.Notify(new NotificationMessage()
            {
                Summary = "Datos Faltantes",
                Detail = "Primero prepara Todo",
                Severity = NotificationSeverity.Warning,
                Duration = DurationLocal
            });
        }


        public void NotifyTime()
        {
            notificationService.Notify(new NotificationMessage()
            {
                Summary = "Tiempo Invalido!",
                Detail = "Selecciona un tiempo mayor a 15 segundos.",
                Severity = NotificationSeverity.Warning,
                Duration = DurationLocal
            });
        }

        public void NotifyOtNoCerrada(BlazorApp1.Shared.Modelo.OT.OrdenTrabajo ordenTrabajo)
        {
            notificationService.Notify(new NotificationMessage()
            {
                Summary = $"No Cerrada ({ordenTrabajo.Movil})",
                Detail = $"La OT {ordenTrabajo.Numero} no se cerró.",
                Severity = NotificationSeverity.Warning,
                Duration = DurationLocal
            });
        }

        public void NotifyOtCerrada(BlazorApp1.Shared.Modelo.OT.OrdenTrabajo ordenTrabajo)
        {
            notificationService.Notify(new NotificationMessage()
            {
                Summary = $"OT Cerrada",
                Detail = $"La OT {ordenTrabajo.Numero} se cerró exitosamente.",
                Severity = NotificationSeverity.Success,
                Duration = DurationLocal
            });
        }
    }
}
