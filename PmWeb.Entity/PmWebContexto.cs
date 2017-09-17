using PmWeb.Entidades;
using System.Data.Entity;

namespace PmWeb.Entity
{
    public class PmWebContexto : DbContext
    {
        public PmWebContexto() : base("name=PmWebContexto") { }

        public DbSet<Hospede> Hospedes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var mapHospede = modelBuilder.Entity<Hospede>();
            mapHospede.HasKey(h => h.IDHospede);
            mapHospede.Property(h => h.DataNascimento).HasColumnName("Data_Nasc").IsOptional().HasColumnType("datetime2");
            mapHospede.Property(h => h.DataHospedagem).HasColumnName("DataHosped").IsOptional().HasColumnType("datetime2");
            mapHospede.ToTable("Hospedes");
        }
    }
}
