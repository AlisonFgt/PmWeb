using PmWeb.Core.Scheduler;
using PmWeb.Entity.Base;
using System;
using System.Globalization;

namespace PmWeb.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Debug("Entrou no sistema");
            AlimentaDadosDefault();
            MensagensAoUsuario();
            AtivandoJobs();
            Console.ReadLine();
        }

        private static void AtivandoJobs()
        {
            var scheduler = new JobManager();
            scheduler.ExecuteAllJobs();
        }

        private static void MensagensAoUsuario()
        {
            Console.WriteLine("Bem vindo!   Sistema projetado por Alison Machado Alves");
            Console.WriteLine();
            Console.WriteLine(DataAtual() + " -- Ligando o Scheduler para momentos T1 e T2 aguarde...");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Aproveite e acesse meu site http://alisonalves.com/");
            Console.WriteLine();
            Console.WriteLine("Projeto hospedado no GitHub https://github.com/AlisonFgt/PmWeb");
            Console.WriteLine();
            Console.ResetColor();
        }

        private static void AlimentaDadosDefault()
        {
            BaseCli.CarregarDadosDefault();
            BaseSTAG_INT.CarregarDadosDefault();
        }

        private static string DataAtual()
        {
            CultureInfo cult = new CultureInfo("pt-BR");
            string dta = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", cult);
            return dta;
        }
    }
}