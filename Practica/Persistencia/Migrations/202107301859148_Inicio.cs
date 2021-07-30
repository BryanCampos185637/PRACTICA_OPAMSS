namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cargoes",
                c => new
                    {
                        CargoId = c.Long(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 200),
                        Descripcion = c.String(nullable: false, maxLength: 200),
                        Estado = c.String(nullable: false, maxLength: 3),
                    })
                .PrimaryKey(t => t.CargoId);
            
            CreateTable(
                "dbo.Empleadoes",
                c => new
                    {
                        EmpleadoId = c.Long(nullable: false, identity: true),
                        CargoId = c.Long(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 200),
                        Apellido = c.String(nullable: false, maxLength: 200),
                        Edad = c.Int(nullable: false),
                        FechaNacimiento = c.DateTime(nullable: false, storeType: "date"),
                        Estado = c.String(nullable: false, maxLength: 3),
                    })
                .PrimaryKey(t => t.EmpleadoId)
                .ForeignKey("dbo.Cargoes", t => t.CargoId, cascadeDelete: true)
                .Index(t => t.CargoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Empleadoes", "CargoId", "dbo.Cargoes");
            DropIndex("dbo.Empleadoes", new[] { "CargoId" });
            DropTable("dbo.Empleadoes");
            DropTable("dbo.Cargoes");
        }
    }
}
