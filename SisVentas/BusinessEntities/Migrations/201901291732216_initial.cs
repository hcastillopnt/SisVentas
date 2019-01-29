namespace BusinessEntities.Migrations
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
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 50, unicode: false, storeType: "nvarchar"),
                        descripcion = c.String(maxLength: 60, unicode: false, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 30, unicode: false, storeType: "nvarchar"),
                        apellido = c.String(maxLength: 30, unicode: false, storeType: "nvarchar"),
                        fecha_nacimiento = c.DateTime(nullable: false, precision: 0),
                        tipo_documento = c.String(nullable: false, maxLength: 30, unicode: false, storeType: "nvarchar"),
                        num_documento = c.String(nullable: false, maxLength: 8, unicode: false, storeType: "nvarchar"),
                        direccion = c.String(maxLength: 50, unicode: false, storeType: "nvarchar"),
                        telefono = c.String(maxLength: 20, unicode: false, storeType: "nvarchar"),
                        email = c.String(maxLength: 30, unicode: false, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Presentacion",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 35, unicode: false, storeType: "nvarchar"),
                        descripcion = c.String(nullable: false, maxLength: 70, unicode: false, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Proveedor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        razon_Social = c.String(nullable: false, maxLength: 50, unicode: false, storeType: "nvarchar"),
                        sector_Comercial = c.String(nullable: false, maxLength: 30, unicode: false, storeType: "nvarchar"),
                        tipo_Documento = c.String(nullable: false, maxLength: 20, unicode: false, storeType: "nvarchar"),
                        num_Caracter = c.String(nullable: false, maxLength: 10, unicode: false, storeType: "nvarchar"),
                        direccion = c.String(maxLength: 50, unicode: false, storeType: "nvarchar"),
                        telefono = c.String(maxLength: 20, unicode: false, storeType: "nvarchar"),
                        email = c.String(maxLength: 30, unicode: false, storeType: "nvarchar"),
                        url = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Trabajador",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 30, unicode: false, storeType: "nvarchar"),
                        apellido = c.String(nullable: false, maxLength: 30, unicode: false, storeType: "nvarchar"),
                        fecha_nacimiento = c.DateTime(nullable: false, precision: 0),
                        num_documento = c.String(nullable: false, maxLength: 8, unicode: false, storeType: "nvarchar"),
                        direccion = c.String(maxLength: 50, unicode: false, storeType: "nvarchar"),
                        telefono = c.String(maxLength: 20, unicode: false, storeType: "nvarchar"),
                        email = c.String(maxLength: 30, unicode: false, storeType: "nvarchar"),
                        acceso = c.String(nullable: false, maxLength: 20, unicode: false, storeType: "nvarchar"),
                        usuario = c.String(nullable: false, maxLength: 20, unicode: false, storeType: "nvarchar"),
                        password = c.String(nullable: false, maxLength: 20, unicode: false, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
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
