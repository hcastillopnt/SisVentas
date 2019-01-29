namespace SistemasVentas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Nombre = c.String(nullable: false, maxLength: 20, storeType: "nvarchar"),
                    Apellidos = c.String(nullable: false, maxLength: 40, storeType: "nvarchar"),
                    Sexo = c.String(nullable: false, maxLength: 1, storeType: "nvarchar"),
                    FechaNacimiento = c.DateTime(nullable: false, precision: 0),
                    TipoDocumento = c.String(nullable: false, maxLength: 20, storeType: "nvarchar"),
                    NumeroDocumento = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                    Direccion = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                    Telefono = c.String(nullable: false, maxLength: 15, storeType: "nvarchar"),
                    Email = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Venta",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Fecha = c.DateTime(nullable: false, precision: 0),
                    TipoComporbante = c.String(nullable: false, maxLength: 20, storeType: "nvarchar"),
                    Serie = c.String(nullable: false, maxLength: 4, storeType: "nvarchar"),
                    Correlativo = c.String(nullable: false, maxLength: 7, storeType: "nvarchar"),
                    Igv = c.Double(nullable: false),
                    TrabajadorId = c.Int(nullable: false),
                    ClienteId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliente", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.Trabajador", t => t.TrabajadorId, cascadeDelete: true);
            // .Index(t => t.TrabajadorId)
            // .Index(t => t.ClienteId);
            Sql("CREATE index Ix_TrabajadorId on Venta (TrabajadorId DESC)");
            Sql("CREATE index Ix_ClienteId on Venta (ClienteId DESC)");



            CreateTable(
                "dbo.Trabajador",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Nombre = c.String(nullable: false, maxLength: 20, storeType: "nvarchar"),
                    Apellidos = c.String(nullable: false, maxLength: 40, storeType: "nvarchar"),
                    Sexo = c.String(nullable: false, maxLength: 1, storeType: "nvarchar"),
                    FechaNacimiento = c.DateTime(nullable: false, precision: 0),
                    NumeroDocumento = c.String(nullable: false, maxLength: 8, storeType: "nvarchar"),
                    Direccion = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                    Telefono = c.String(nullable: false, maxLength: 15, storeType: "nvarchar"),
                    Email = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                    Acceso = c.String(nullable: false, maxLength: 20, storeType: "nvarchar"),
                    Usuario = c.String(nullable: false, maxLength: 20, storeType: "nvarchar"),
                    Password = c.String(nullable: false, maxLength: 20, storeType: "nvarchar"),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Ingreso",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Fecha = c.DateTime(nullable: false, precision: 0),
                    TipoComporbante = c.String(nullable: false, maxLength: 20, storeType: "nvarchar"),
                    Serie = c.String(nullable: false, maxLength: 4, storeType: "nvarchar"),
                    Correlativo = c.String(nullable: false, maxLength: 7, storeType: "nvarchar"),
                    Igv = c.Double(nullable: false),
                    TrabajadorId = c.Int(nullable: false),
                    ProveedorId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Proveedor", t => t.ProveedorId, cascadeDelete: true)
                .ForeignKey("dbo.Trabajador", t => t.TrabajadorId, cascadeDelete: true);
            // .Index(t => t.TrabajadorId)
            //.Index(t => t.ProveedorId);
            Sql("CREATE index Ix_ProveedorId on Ingreso (ProveedorId DESC)");
            Sql("CREATE index Ix_TrabajadorId on Ingreso (TrabajadorId DESC)");

            CreateTable(
                "dbo.Proveedor",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    RazonSocial = c.String(nullable: false, maxLength: 150, storeType: "nvarchar"),
                    SectorComercial = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                    TipoDocumento = c.String(nullable: false, maxLength: 20, storeType: "nvarchar"),
                    NumeroDocumento = c.String(nullable: false, maxLength: 11, storeType: "nvarchar"),
                    Direccion = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                    Telefono = c.String(nullable: false, maxLength: 15, storeType: "nvarchar"),
                    Email = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                    Url = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                })
                .PrimaryKey(t => t.Id);

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Venta", "TrabajadorId", "dbo.Trabajador");
            DropForeignKey("dbo.Ingreso", "TrabajadorId", "dbo.Trabajador");
            DropForeignKey("dbo.Ingreso", "ProveedorId", "dbo.Proveedor");
            DropForeignKey("dbo.Venta", "ClienteId", "dbo.Cliente");
            DropIndex("dbo.Ingreso", new[] { "ProveedorId" });
            DropIndex("dbo.Ingreso", new[] { "TrabajadorId" });
            DropIndex("dbo.Venta", new[] { "ClienteId" });
            DropIndex("dbo.Venta", new[] { "TrabajadorId" });
            DropTable("dbo.Proveedor");
            DropTable("dbo.Ingreso");
            DropTable("dbo.Trabajador");
            DropTable("dbo.Venta");
            DropTable("dbo.Cliente");
        }
    }
}
