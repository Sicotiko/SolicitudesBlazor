using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorApp1.Shared.User
{
    public class Usuario
    {
        private string _User;
        private string _Password;

        public Usuario(string UserInBase64, string PaswordInBase64)
        {
            _User = UserInBase64;
            _Password = PaswordInBase64;
        }
        public string GetCredentials()
        {
            return $"{_User.ToUpper()}:{_Password}";
        }
    }
}
