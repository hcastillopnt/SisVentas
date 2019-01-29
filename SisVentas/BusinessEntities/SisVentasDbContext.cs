using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class SisVentasDbContext : DbContext
    {
        public SisVentasDbContext() : base("SisVentasDbContext")
        {
            //Constructor vacio.
            //La cadena de conexion se llamara ... 
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Presentacion> Presentacions { get; set; }

        public DbSet<Proveedor> Proveedors { get; set; }
        public DbSet<Trabajador> Trabajadors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();//Le quita lo plural a la tabla.
        }
    }
}
