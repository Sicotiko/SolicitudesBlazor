using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.Excepciones
{
    [Serializable]
    public class CredentialsException : ExceptionResponse
    {
        public CredentialsException(string Message) : base(Message)
        {
        }
        public CredentialsException(string Message, Exception? exception) : base(Message, exception)
        {
        }
    }
}
