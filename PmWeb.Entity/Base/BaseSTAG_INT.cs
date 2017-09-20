using PmWeb.Entidades;
using System;
using System.Data.Entity.Migrations;

namespace PmWeb.Entity.Base
{
    public class BaseSTAG_INT
    {
        public static void CarregarDadosDefault()
        {
            // metodo para alimentar a base Stag_int com dados iniciais de hospedes
            using (var db = new PmWebContexto())
            {
                db.Hospedes.AddOrUpdate(
                    new Hospede { IDHospede = "73F", Email = "armando@teste.com.br", Nome = "Armando", DataNascimento = DateTime.Parse("01/03/1990"), DataHospedagem = DateTime.Parse("10/02/2017") },
                    new Hospede { IDHospede = "33W", Email = "joao@joao.com.br", Nome = "João", DataNascimento = DateTime.Parse("21/01/1984"), DataHospedagem = DateTime.Parse("10/02/2017") },
                    new Hospede { IDHospede = "12D", Email = "jose@jose.com.br", Nome = "José", DataHospedagem = DateTime.Parse("10/02/2017") },
                    new Hospede { IDHospede = "43F", Email = "maico@terra.com.br", Nome = "Maico", DataNascimento = DateTime.Parse("22/11/1990"), DataHospedagem = DateTime.Parse("10/02/2017") },
                    new Hospede { IDHospede = "20S", Email = "will@will.com.br", Nome = "Will", DataNascimento = DateTime.Parse("11/05/1950"), DataHospedagem = DateTime.Parse("10/02/2017") },
                    new Hospede { IDHospede = "84X", Email = "jose@jose.com.br", Nome = "Carla", DataNascimento = DateTime.Parse("22/11/1991"), DataHospedagem = DateTime.Parse("10/02/2017") }
                );

                db.SaveChanges();
            }
        }
    }
}
