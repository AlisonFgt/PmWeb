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

        public static Pessoa AtualizaPessoa(Pessoa pessoa, string[] words)
        {
            pessoa.Nome = words[1];
            pessoa.UltimaHospedagem = DateTime.Parse(words[2]);
            pessoa.DataAtualizacao = DateTime.Now;
            return pessoa;
        }

        public static Pessoa AtualizaPessoa(Pessoa pessoa, Hospede hospede)
        {
            if (!pessoa.UltimaHospedagem.Equals(hospede.DataHospedagem) && pessoa.UltimaHospedagem < hospede.DataHospedagem)
                pessoa.QtdeHospedag++;

            if (hospede.DataNascimento != null)
                pessoa.DataNascimento = hospede.DataNascimento;

            pessoa.UltimaHospedagem = hospede.DataHospedagem;
            pessoa.DataAtualizacao = DateTime.Now;
            
            return pessoa;
        }

        public static Pessoa CriaPessoa(int nextId, string[] words)
        {
            Pessoa novaPessoa = new Pessoa { ID = nextId, DataCadastro = DateTime.Now, Email = words[0], Nome = words[1], UltimaHospedagem = DateTime.Parse(words[2]), DataAtualizacao = DateTime.Now };
            return novaPessoa;
        }

        public static Pessoa CriaPessoa(int nextId, Hospede hospede)
        {
            var pessoa = new Pessoa
            {
                ID = nextId,
                DataCadastro = DateTime.Now,
                DataAtualizacao = DateTime.Now,
                DataNascimento = hospede.DataNascimento,
                Email = hospede.Email,
                IdExterno = hospede.IDHospede,
                Nome = hospede.Nome,
                QtdeHospedag = 1,
                UltimaHospedagem = hospede.DataHospedagem
            };

            return pessoa;
        }
    }
}
