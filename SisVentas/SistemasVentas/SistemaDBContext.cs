using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//
namespace SistemasVentas
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class SistemaDBContext : DbContext
    {
        public SistemaDBContext() : base("SistemaDBContext")
        {

        }

        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Trabajador> Trabajadors{ get; set; }
        public DbSet<Proveedor> Proveedors{ get; set; }
        public DbSet<Ingreso> Ingresos{ get; set; }
        public DbSet<Cliente> Clientes{ get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}
