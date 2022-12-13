using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.Excepciones
{
    [Serializable]
    public class ExceptionResponse : Exception
    {
        public ExceptionResponse(string Message) : base(Message)
        {
        }
        public ExceptionResponse(string Message, Exception? exception) : base(Message, exception)
        {
        }
    }
}
