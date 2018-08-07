using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while(args.Length < 3)
            {
                Console.WriteLine("Insira os parametros");
                Console.WriteLine("Instancia DataInicial DataFinal Repetições");
                string texto = Console.ReadLine();
                args = texto.Split(' ');
            }

            LoadData();
            Console.WriteLine();
            Console.ReadKey();


        }

        static async void LoadData()
        {
            string page = "https://jsonplaceholder.typicode.com/todos/1";
            using (HttpClient cliente = new HttpClient())
            using (HttpResponseMessage response = await cliente.GetAsync(page))
            using (HttpContent content = response.Content)
            {
                string data = await content.ReadAsStringAsync();

                if(data != null)
                {
                    Console.WriteLine(data);
                }
            }
        }
    }
}
