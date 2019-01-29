using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisVentas.BusinessEntities
{
    public class Ingreso
    {
        public int Id { get; set; }
        public int TrabajadorId { get; set; }
        public Trabajador Trabajador { get; set; }
        public int ProveedorId { get; set; }
        public Proveedor Proveedor { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoComprobante { get; set; }
        public string Serie { get; set; }
        public string Correlativo { get; set; }
        public decimal IGV { get; set; }
        public virtual ICollection<DetalleIngreso> DetalleIngresos { get; set; }
    }
}
