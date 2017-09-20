using PmWeb.Core.Scheduler;
using PmWeb.Entidades;
using PmWeb.Entity.Repositories;
using System;
using System.IO;
using System.Linq;
using System.Threading;

namespace PmWeb.Core.Jobs
{
    public class MomentoT2Job : Job
    {
        protected PessoaRepository pessoaRepository = new PessoaRepository();

        public override string GetName()
        {
            return this.GetType().Name;
        }

        public override void DoJob()
        {
            Thread.Sleep(5000);
            InformarOUsuario();
            UploadArquivoTxt();
            ExportarExcelPessoas();
            InformarFimProcesso();
            counter++;
        }

        private void InformarFimProcesso()
        {
            System.Console.WriteLine(String.Format(DataAtual() + " - Excel de Pessoas foi exportado após upload de arquivo.txt, para o caminho: {0}", Directory.GetCurrentDirectory()));
            System.Console.WriteLine();
            System.Console.WriteLine(String.Format(DataAtual() + " - O Momento T2, Upload arquivo.txt foi executado com sucesso, repetirá em 1 dia.", this.GetName()));
            System.Console.WriteLine();
        }

        private void ExportarExcelPessoas()
        {
            var pessoas = pessoaRepository.GetAll().ToList();
            string[] colunasIgnoradas = { "" };
            byte[] filecontent = PmWeb.Core.Excel.Excel.ExportaExcel(pessoas, "Pessoas", true, colunasIgnoradas);
            File.WriteAllBytes(string.Format("{0}_MomentoT2_Pessoas.xlsx", DateTime.Now.ToString("dd_MM_HH_mm").ToString()), filecontent);
        }

        private void UploadArquivoTxt()
        {
            int count = 0;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "20170519_Clientes.txt");
            //string text = File.ReadAllText(path);
            string line;
            var text = new System.IO.StreamReader(path);

            while ((line = text.ReadLine()) != null)
            {
                System.Console.WriteLine(line);
                if (!count.Equals(0))
                    ImportaPessoa(line);
                count++;
            }
            System.Console.WriteLine();
        }

        private void ImportaPessoa(string line)
        {
            string[] words = line.Split('\t');
            var pessoa = pessoaRepository.GetByEmail(words[0]);

            if (pessoa == null)
                CriaPessoa(words);
            else
                AtualizaPessoa(pessoa, words);
        }

        private void AtualizaPessoa(Pessoa pessoa, string[] words)
        {
            pessoa.Nome = words[1];
            pessoa.UltimaHospedagem = DateTime.Parse(words[2]);
            pessoa.DataAtualizacao = DateTime.Now;
            pessoaRepository.Update(pessoa);
        }

        private void CriaPessoa(string[] words)
        {
            Pessoa novaPessoa = new Pessoa { ID = pessoaRepository.GetNextId(), DataCadastro = DateTime.Now, Email = words[0], Nome = words[1], UltimaHospedagem = DateTime.Parse(words[2]), DataAtualizacao = DateTime.Now };
            pessoaRepository.Add(novaPessoa);
        }

        private void InformarOUsuario()
        {
            System.Console.WriteLine(String.Format(DataAtual() + " - Momento T2, Upload arquivo.txt, executado pela " + counter.ToString() + "° vez", this.GetName()));
            System.Console.WriteLine();
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
