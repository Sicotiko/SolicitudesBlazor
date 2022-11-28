using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorApp1.Shared.Utilities
{
    public static class MobileNumber
    {
        public static string ToCCMobileNumber(this int Movil)
        {
            switch (Movil.ToString().Length)
            {
                case 2:
                    return $"8640{Movil}";
                case 3:
                    return $"864{Movil}";
                case 6:
                    return $"{Movil}";
                default:
                    return $"";
            }
        }
    }
}
