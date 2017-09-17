using PmWeb.Core.Scheduler;
using PmWeb.Entidades;
using PmWeb.Entity.Repositories;
using System;

namespace PmWeb.Core.Jobs
{
    public class MomentoT1Job : Job
    {
        protected HospedeRepository hospedeRepository = new HospedeRepository();
        protected PessoaRepository pessoaRepository = new PessoaRepository();

        public override string GetName()
        {
            return this.GetType().Name;
        }

        public override void DoJob()
        {
            System.Console.WriteLine(String.Format(DataAtual() + " -- Atualizar Tabela Pessoa. Executado pela " + counter.ToString() + "° vez", this.GetName()));
            System.Console.WriteLine();
            AtualizarTabelaPessoa();            
            System.Console.WriteLine(String.Format(DataAtual() + " -- O Job \"{0}\" foi executado com sucesso, repetira em 1 minuto.", this.GetName()));
            System.Console.WriteLine();
            counter++;
        }

        private void AtualizarTabelaPessoa()
        {
            

            var hospedes = hospedeRepository.GetAll();

            foreach (var hospede in hospedes)
            {
                var pessoa = pessoaRepository.GetByIdExterno(hospede.IDHospede);

                if (pessoa == null)
                    CriaPessoa(hospede);
                else
                    AtualizaPessoa(pessoa, hospede);
            }
        }

        private void AtualizaPessoa(Pessoa pessoa, Hospede hospede)
        {
            if(!pessoa.UltimaHospedagem.Equals(hospede.DataHospedagem) && pessoa.UltimaHospedagem < hospede.DataHospedagem)
            {
                pessoa.UltimaHospedagem = hospede.DataHospedagem;
                pessoa.QtdeHospedag++;
                pessoa.DataCadastro = DateTime.Now;
                pessoa.DataAtualizacao = DateTime.Now;

                pessoaRepository.Update(pessoa);
            }
        }

        private void CriaPessoa(Hospede hospede)
        {
            var pessoa = new Pessoa
            {
                ID = pessoaRepository.GetNextId(),
                DataAtualizacao = DateTime.Now,
                DataCadastro = DateTime.Now,
                DataNascimento = hospede.DataNascimento,
                Email = hospede.Email,
                IdExterno = hospede.IDHospede,
                Nome = hospede.Nome,
                QtdeHospedag = 1,
                UltimaHospedagem = hospede.DataHospedagem
            };

            pessoaRepository.Add(pessoa);
        }

        public override bool IsRepeatable()
        {
            return true;
        }

        public override int GetRepetitionIntervalTime()
        {
            // 1 minuto
            return 60000;
        }
    }
}
