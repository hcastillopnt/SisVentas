namespace SisVentas.BusinessEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articulo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(unicode: false),
                        Nombre = c.String(unicode: false),
                        Descripcion = c.String(unicode: false),
                        Imagen = c.Binary(),
                        CategoriaId = c.Int(nullable: false),
                        PresentacionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categoria", t => t.CategoriaId, cascadeDelete: true)
                .ForeignKey("dbo.Presentacion", t => t.PresentacionId, cascadeDelete: true)
                .Index(t => t.CategoriaId)
                .Index(t => t.PresentacionId);
            
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(unicode: false),
                        Descripcion = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DetalleIngreso",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IngresoId = c.Int(nullable: false),
                        ArticuloId = c.Int(nullable: false),
                        PrecioCompra = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecioVenta = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StockInicial = c.Int(nullable: false),
                        StockActual = c.Int(nullable: false),
                        FechaProduccion = c.DateTime(nullable: false, precision: 0),
                        FechaVencimiento = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articulo", t => t.ArticuloId, cascadeDelete: true)
                .ForeignKey("dbo.Ingreso", t => t.IngresoId, cascadeDelete: true)
                .Index(t => t.ArticuloId)
                .Index(t => t.IngresoId);
            
            CreateTable(
                "dbo.DetalleVenta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VentaId = c.Int(nullable: false),
                        DetalleIngresoId = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        PrecioVenta = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Descuento = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DetalleIngreso", t => t.DetalleIngresoId, cascadeDelete: true)
                .ForeignKey("dbo.Venta", t => t.VentaId, cascadeDelete: true)
                .Index(t => t.DetalleIngresoId)
                .Index(t => t.VentaId);
            
            CreateTable(
                "dbo.Venta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClienteId = c.Int(nullable: false),
                        TrabajadorId = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false, precision: 0),
                        TipoComprobante = c.String(unicode: false),
                        Serie = c.String(unicode: false),
                        Correlativo = c.String(unicode: false),
                        IGV = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliente", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.Trabajador", t => t.TrabajadorId, cascadeDelete: true)
                .Index(t => t.ClienteId)
                .Index(t => t.TrabajadorId);
            
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(unicode: false),
                        Apellidos = c.String(unicode: false),
                        Sexo = c.String(unicode: false),
                        Fecha_Nacimiento = c.DateTime(nullable: false, precision: 0),
                        TipoDocumento = c.String(unicode: false),
                        NumDocumento = c.String(unicode: false),
                        Direccion = c.String(unicode: false),
                        Telefono = c.String(unicode: false),
                        Email = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Trabajador",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(unicode: false),
                        Apellidos = c.String(unicode: false),
                        Sexo = c.String(unicode: false),
                        FechaNacimiento = c.DateTime(nullable: false, precision: 0),
                        NumDocumento = c.String(unicode: false),
                        Direccion = c.String(unicode: false),
                        Telefono = c.String(unicode: false),
                        Email = c.String(unicode: false),
                        Acceso = c.String(unicode: false),
                        Usuario = c.String(unicode: false),
                        Password = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ingreso",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TrabajadorId = c.Int(nullable: false),
                        ProveedorId = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false, precision: 0),
                        TipoComprobante = c.String(unicode: false),
                        Serie = c.String(unicode: false),
                        Correlativo = c.String(unicode: false),
                        IGV = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Proveedor", t => t.ProveedorId, cascadeDelete: true)
                .ForeignKey("dbo.Trabajador", t => t.TrabajadorId, cascadeDelete: true)
                .Index(t => t.ProveedorId)
                .Index(t => t.TrabajadorId);
            
            CreateTable(
                "dbo.Proveedor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RazonSocial = c.String(unicode: false),
                        SectorComercial = c.String(unicode: false),
                        TipoDocumento = c.String(unicode: false),
                        NumDocumento = c.String(unicode: false),
                        Direccion = c.String(unicode: false),
                        Telefono = c.String(unicode: false),
                        Email = c.String(unicode: false),
                        URL = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Presentacion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(unicode: false),
                        Descripcion = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articulo", "PresentacionId", "dbo.Presentacion");
            DropForeignKey("dbo.Venta", "TrabajadorId", "dbo.Trabajador");
            DropForeignKey("dbo.Ingreso", "TrabajadorId", "dbo.Trabajador");
            DropForeignKey("dbo.Ingreso", "ProveedorId", "dbo.Proveedor");
            DropForeignKey("dbo.DetalleIngreso", "IngresoId", "dbo.Ingreso");
            DropForeignKey("dbo.DetalleVenta", "VentaId", "dbo.Venta");
            DropForeignKey("dbo.Venta", "ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.DetalleVenta", "DetalleIngresoId", "dbo.DetalleIngreso");
            DropForeignKey("dbo.DetalleIngreso", "ArticuloId", "dbo.Articulo");
            DropForeignKey("dbo.Articulo", "CategoriaId", "dbo.Categoria");
            DropIndex("dbo.Articulo", new[] { "PresentacionId" });
            DropIndex("dbo.Venta", new[] { "TrabajadorId" });
            DropIndex("dbo.Ingreso", new[] { "TrabajadorId" });
            DropIndex("dbo.Ingreso", new[] { "ProveedorId" });
            DropIndex("dbo.DetalleIngreso", new[] { "IngresoId" });
            DropIndex("dbo.DetalleVenta", new[] { "VentaId" });
            DropIndex("dbo.Venta", new[] { "ClienteId" });
            DropIndex("dbo.DetalleVenta", new[] { "DetalleIngresoId" });
            DropIndex("dbo.DetalleIngreso", new[] { "ArticuloId" });
            DropIndex("dbo.Articulo", new[] { "CategoriaId" });
            DropTable("dbo.Presentacion");
            DropTable("dbo.Proveedor");
            DropTable("dbo.Ingreso");
            DropTable("dbo.Trabajador");
            DropTable("dbo.Cliente");
            DropTable("dbo.Venta");
            DropTable("dbo.DetalleVenta");
            DropTable("dbo.DetalleIngreso");
            DropTable("dbo.Categoria");
            DropTable("dbo.Articulo");
        }
    }
}
