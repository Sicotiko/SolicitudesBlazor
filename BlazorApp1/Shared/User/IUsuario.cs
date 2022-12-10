using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.User
{
    public interface IUsuario
    {
        public string UserInBase64 { get; set; }
        public string PaswordInBase64 { get; set; }

        public string GetCredentials();
    }
}
