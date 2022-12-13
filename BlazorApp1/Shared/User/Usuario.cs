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
                throw new NullReferenceException("Usuario no puede estar vacio");
            if (PaswordInBase64 == null)
                throw new NullReferenceException("Contraseña no puede estar vacia");

            return $"{this.UserInBase64.ToUpper()}:{this.PaswordInBase64}";
        }


    }
}
