using BlazorApp1.Shared.Excepciones;
using System;

namespace BlazorApp1.Client.Services.Notifications
{
    public interface INoteService
    {
        public void NotifyResponse(ExceptionResponse exceptionResponse);
        public void NotifyNull(NullReferenceException nullReferenceException);
        public void NotifyVoidData();
    }
}
