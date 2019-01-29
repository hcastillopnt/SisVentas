using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisVentas.BusinessEntities
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class SisVentasDbContext : DbContext
    {
        public SisVentasDbContext():
            base("SisVentasDbContext")
        {

        }

        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<DetalleIngreso> DetalleIngresos { get; set; }
        public DbSet<DetalleVenta> DetalleVentas { get; set; }
        public DbSet<Ingreso> Ingresos { get; set; }
        public DbSet<Presentacion> Presentaciones { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Trabajador> Trabajadores { get; set; }
        public DbSet<Venta> Ventas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
