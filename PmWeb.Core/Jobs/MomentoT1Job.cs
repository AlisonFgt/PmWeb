using PmWeb.Core.Scheduler;
using PmWeb.Entidades;
using PmWeb.Entity.Repositories;
using System;
using System.IO;
using System.Linq;

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
            InformarOUsuario();
            AtualizarTabelaPessoa();
            ExportarExcelPessoas();
            ExportarExcelHospedagens(); // não foi solicitado porém estou exportando somente para visualização...
            System.Console.WriteLine(String.Format(DataAtual() + " - O processo de ETL(Momento T1) executou com sucesso, repetirá em 1 dia.", this.GetName()));
            System.Console.WriteLine();
            System.Console.WriteLine(String.Format(DataAtual() + " - Excel de Pessoas e Hospedes foi exportado para o caminho: {0}", Directory.GetCurrentDirectory()));
            System.Console.WriteLine();
            counter++;
        }

        private void InformarOUsuario()
        {
            System.Console.WriteLine(String.Format(DataAtual() + " - Atualizar Tabela pessoas, executado pela " + counter.ToString() + "° vez", this.GetName()));
            System.Console.WriteLine();
            System.Console.WriteLine(DataAtual() + " - Agora começa o processo de ETL(Momento T1)");
            System.Console.WriteLine();
        }

        private void ExportarExcelHospedagens()
        {
            var hospedes = hospedeRepository.GetAll().ToList();
            string[] colunasIgnoradas = { "" };
            byte[] filecontent = PmWeb.Core.Excel.Excel.ExportaExcel(hospedes, "Hospedes", true, colunasIgnoradas);
            File.WriteAllBytes(string.Format("{0}_MomentoT1_Hospedes.xlsx", DateTime.Now.ToString("dd_MM_HH_mm").ToString()), filecontent);
        }

        private void ExportarExcelPessoas()
        {
            var pessoas = pessoaRepository.GetAll().ToList();
            string[] colunasIgnoradas = { "" };
            byte[] filecontent = PmWeb.Core.Excel.Excel.ExportaExcel(pessoas, "Pessoas", true, colunasIgnoradas);
            File.WriteAllBytes(string.Format("{0}_MomentoT1_Pessoas.xlsx", DateTime.Now.ToString("dd_MM_HH_mm").ToString()), filecontent);
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
            pessoa = Pessoa.AtualizaPessoa(pessoa, hospede);
            pessoaRepository.Update(pessoa);
        }

        private void CriaPessoa(Hospede hospede)
        {
            var pessoa = Pessoa.CriaPessoa(pessoaRepository.GetNextId(), hospede);
            pessoaRepository.Add(pessoa);
        }

        public override bool IsRepeatable()
        {
            return true;
        }

        public override int GetRepetitionIntervalTime()
        {
            // 1 dia
            return 86400000;
        }
    }
}
