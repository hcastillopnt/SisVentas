using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisVentas.BusinessEntities
{
    public class Articulo
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public byte[] Imagen { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public int PresentacionId { get; set; }
        public Presentacion Presentacion { get; set; }
        public virtual ICollection<DetalleIngreso> DetalleIngresos { get; set; }
    }
}
