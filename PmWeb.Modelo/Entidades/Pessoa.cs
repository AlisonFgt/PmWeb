using System;
using System.ComponentModel;
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

        [DisplayName("Data de Cadastro")]
        public DateTime DataCadastro { get; set; }

        [DisplayName("Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [DisplayName("Última Hospedagem")]
        public DateTime UltimaHospedagem { get; set; }

        [DisplayName("Data da Atualização")]
        public DateTime DataAtualizacao { get; set; }

        [DisplayName("Quantidade de Hospedagem")]
        public int QtdeHospedag { get; set; }
    }
}
