using PmWeb.Entidades;
using System;
using System.Data.Entity.Migrations;

namespace PmWeb.Entity.Base
{
    public class BaseCli
    {
        public static void CarregarDadosDefault()
        {
            // metodo para alimentar a base Cli com dados iniciais de pessoas
            using (var db = new PmWebCliente())
            {
                db.Pessoas.AddOrUpdate(
                    new Pessoa { ID = 123, Nome = "João", Email = "joao@joao.com.br", IdExterno = "22E", DataCadastro = DateTime.Parse("01/02/2017"), UltimaHospedagem = DateTime.Parse("22/10/2010"), QtdeHospedag = 1 },
                    new Pessoa { ID = 456, Nome = "Maria", Email = "maria@maria.com.br", DataCadastro = DateTime.Parse("01/02/2015")},
                    new Pessoa { ID = 789, Nome = "José", Email = "jose@jose.com.br", IdExterno = "12D", DataCadastro = DateTime.Parse("04/01/2016"), UltimaHospedagem = DateTime.Parse("01/01/2015"), QtdeHospedag = 3 },
                    new Pessoa { ID = 990, Nome = "Maico", Email = "maico@terra.com.br", IdExterno = "43F", DataCadastro = DateTime.Parse("01/02/2015"), UltimaHospedagem = DateTime.Parse("09/10/2009"), QtdeHospedag = 10 }
                );

                db.SaveChanges();
            }
        }
    }
}
