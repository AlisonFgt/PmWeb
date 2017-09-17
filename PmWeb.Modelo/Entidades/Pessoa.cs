using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PmWeb.Entidades
{
    public class Pessoa
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string IdExterno { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime UltimaHospedagem { get; set; }
        public DateTime DataAtualizacao { get; set; }       
        public int QtdeHospedag { get; set; }
    }
}
