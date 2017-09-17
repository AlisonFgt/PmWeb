namespace PmWeb.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriandoBaseCliente : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pessoas",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Nome = c.String(),
                        Email = c.String(),
                        IdExterno = c.String(),
                        DataCadastro = c.DateTime(precision: 7, storeType: "datetime2"),
                        Data_Nasc = c.DateTime(precision: 7, storeType: "datetime2"),
                        UltimaHosp = c.DateTime(precision: 7, storeType: "datetime2"),
                        DataAtualizacao = c.DateTime(precision: 7, storeType: "datetime2"),
                        QtdeHospedag = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pessoas");
        }
    }
}
