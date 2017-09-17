using PmWeb.Entidades;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PmWeb.Entity.Repositories
{
    public class HospedeRepository
    {
        protected PmWebContexto Db = new PmWebContexto();

        public void Add(Hospede obj)
        {
            Db.Set<Hospede>().Add(obj);
            Db.SaveChanges();
        }

        public Hospede GetById(int id)
        {
            return Db.Set<Hospede>().Find(id);
        }

        public IEnumerable<Hospede> GetAll()
        {
            return Db.Set<Hospede>().ToList();
        }

        public void Update(Hospede obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Remove(int id)
        {
            Db.Set<Hospede>().Remove(GetById(id));
            Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
