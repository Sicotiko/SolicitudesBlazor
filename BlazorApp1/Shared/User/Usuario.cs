using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorApp1.Shared.User
{
    public class Usuario : IUsuario
    {
        public string UserInBase64 { get; set; }
        public string PaswordInBase64 { get; set; }

        public Usuario(string UserInBase64, string PaswordInBase64)
        {
            this.UserInBase64 = UserInBase64;
            this.PaswordInBase64 = PaswordInBase64;
        }
        public Usuario()
        {
        }
        public string GetCredentials()
        {
            if (UserInBase64 == null)
                throw new NullReferenceException($"{nameof(UserInBase64)} no puede ser nulo");
            if (PaswordInBase64 == null)
                throw new NullReferenceException($"{nameof(PaswordInBase64)} no puede ser nulo");

            return $"{this.UserInBase64.ToUpper()}:{this.PaswordInBase64}";
        }
    }
}
