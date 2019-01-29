using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisVentas.BusinessEntities
{
    public class Venta
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public int TrabajadorId { get; set; }
        public Trabajador Trabajador { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoComprobante { get; set; }
        public string Serie { get; set; }
        public string Correlativo { get; set; }
        public decimal IGV { get; set; }
        public virtual ICollection<DetalleVenta> DetalleVentas { get; set; }
    }
}
