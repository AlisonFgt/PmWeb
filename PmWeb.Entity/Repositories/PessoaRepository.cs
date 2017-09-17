using PmWeb.Entidades;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PmWeb.Entity.Repositories
{
    public class PessoaRepository
    {
        protected PmWebCliente Db = new PmWebCliente();

        public void Add(Pessoa obj)
        {
            Db.Set<Pessoa>().Add(obj);
            Db.SaveChanges();
        }

        public Pessoa GetByIdExterno(string idExterno)
        {
            return Db.Set<Pessoa>().Where(p => p.IdExterno.Equals(idExterno)).FirstOrDefault();
        }

        public Pessoa GetById(int id)
        {
            return Db.Set<Pessoa>().Find(id);
        }

        public int GetNextId()
        {
            return Db.Set<Pessoa>().OrderByDescending(p => p.ID).Select(p => p.ID + 1).FirstOrDefault();
        }

        public IEnumerable<Pessoa> GetAll()
        {
            return Db.Set<Pessoa>().ToList();
        }

        public void Update(Pessoa obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Remove(int id)
        {
            Db.Set<Pessoa>().Remove(GetById(id));
            Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
