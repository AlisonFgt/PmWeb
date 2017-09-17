using System;

namespace PmWeb.Entidades
{
    public class Hospede
    {
        public string IDHospede { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataHospedagem { get; set; }
    }
}
