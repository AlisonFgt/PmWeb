using System;
using System.ComponentModel;

namespace PmWeb.Entidades
{
    public class Hospede
    {
        public string IDHospede { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }

        [DisplayName("Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [DisplayName("Data da Hospedagem")]
        public DateTime DataHospedagem { get; set; }
    }
}
