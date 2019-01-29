namespace SisVentas.BusinessEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false, storeType: "nvarchar"),
                        Descripcion = c.String(nullable: false, maxLength: 50, unicode: false, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 20, unicode: false, storeType: "nvarchar"),
                        Apellidos = c.String(nullable: false, maxLength: 40, unicode: false, storeType: "nvarchar"),
                        Sexo = c.String(nullable: false, maxLength: 1, unicode: false, storeType: "nvarchar"),
                        FechaNacimiento = c.DateTime(nullable: false, precision: 0),
                        TipoDocumento = c.String(nullable: false, maxLength: 20, unicode: false, storeType: "nvarchar"),
                        NumDocumento = c.String(nullable: false, maxLength: 8, unicode: false, storeType: "nvarchar"),
                        Direccion = c.String(nullable: false, maxLength: 100, unicode: false, storeType: "nvarchar"),
                        Telefono = c.String(nullable: false, maxLength: 10, unicode: false, storeType: "nvarchar"),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Presentacion",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false, storeType: "nvarchar"),
                        Descripcion = c.String(nullable: false, maxLength: 50, unicode: false, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Proveedor",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RazonSocial = c.String(nullable: false, maxLength: 150, unicode: false, storeType: "nvarchar"),
                        SectorComercial = c.String(nullable: false, maxLength: 50, unicode: false, storeType: "nvarchar"),
                        TipoDocumento = c.String(nullable: false, maxLength: 20, unicode: false, storeType: "nvarchar"),
                        NumDocumento = c.String(nullable: false, maxLength: 11, unicode: false, storeType: "nvarchar"),
                        Direccion = c.String(maxLength: 100, unicode: false, storeType: "nvarchar"),
                        Telefono = c.String(maxLength: 50, unicode: false, storeType: "nvarchar"),
                        Email = c.String(maxLength: 50, unicode: false, storeType: "nvarchar"),
                        URL = c.String(maxLength: 100, unicode: false, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Trabajador",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 20, unicode: false, storeType: "nvarchar"),
                        Apellidos = c.String(nullable: false, maxLength: 40, unicode: false, storeType: "nvarchar"),
                        Sexo = c.String(nullable: false, maxLength: 1, unicode: false, storeType: "nvarchar"),
                        FechaNacimiento = c.DateTime(nullable: false, precision: 0),
                        NumDocumento = c.String(nullable: false, maxLength: 8, unicode: false, storeType: "nvarchar"),
                        Direccion = c.String(maxLength: 100, unicode: false, storeType: "nvarchar"),
                        Telefono = c.String(maxLength: 10, unicode: false, storeType: "nvarchar"),
                        Email = c.String(maxLength: 50, unicode: false, storeType: "nvarchar"),
                        Acceso = c.String(nullable: false, maxLength: 20, unicode: false, storeType: "nvarchar"),
                        Usuario = c.String(nullable: false, maxLength: 20, unicode: false, storeType: "nvarchar"),
                        Contraseña = c.String(nullable: false, maxLength: 20, unicode: false, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Trabajador");
            DropTable("dbo.Proveedor");
            DropTable("dbo.Presentacion");
            DropTable("dbo.Cliente");
            DropTable("dbo.Categoria");
        }
    }
}
