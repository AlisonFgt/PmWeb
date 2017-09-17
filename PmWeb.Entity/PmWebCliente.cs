using PmWeb.Entidades;
using System.Data.Entity;

namespace PmWeb.Entity
{
    public class PmWebCliente : DbContext
    {
        public PmWebCliente() : base("name=PmWebCliente") { }

        public DbSet<Pessoa> Pessoas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var mapPessoa = modelBuilder.Entity<Pessoa>();
            mapPessoa.HasKey(p => p.ID);
            mapPessoa.Property(p => p.DataCadastro).HasColumnName("DataCadastro").IsOptional().HasColumnType("datetime2");
            mapPessoa.Property(p => p.DataNascimento).HasColumnName("Data_Nasc").IsOptional().HasColumnType("datetime2");
            mapPessoa.Property(p => p.UltimaHospedagem).HasColumnName("UltimaHosp").IsOptional().HasColumnType("datetime2");
            mapPessoa.Property(p => p.DataAtualizacao).HasColumnName("DataAtualizacao").IsOptional().HasColumnType("datetime2");
            mapPessoa.ToTable("Pessoas");
        }
    }
}