using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.Excepciones
{
    [Serializable]
    public class ConnectionException : ExceptionResponse
    {
        public ConnectionException(string Message) : base(Message)
        {
        }

        public ConnectionException(string Message, Exception exception) : base(Message, exception)
        {
        }
    }
}
