using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisVentas.BusinessEntities
{
    public class DetalleIngreso
    {
        public int Id { get; set; }
        public int IngresoId { get; set; }
        public Ingreso Ingreso { get; set; }
        public int ArticuloId { get; set; }
        public Articulo Articulo { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public int StockInicial { get; set; }
        public int StockActual { get; set; }
        public DateTime FechaProduccion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public virtual ICollection<DetalleVenta> DetalleVentas { get; set; }
    }
}
