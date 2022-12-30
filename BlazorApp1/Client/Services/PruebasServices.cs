using System;
using System.Threading.Tasks;

namespace BlazorApp1.Client.Services
{
    public class PruebasServices
    {
        public PruebasServices()
        {

        }

        public async Task Iniciar()
        {
            for(int i = 0; i < 100; i++)
            {
                Console.WriteLine(i);
                await Task.Delay(3000);
            }
        }
    }
}
