using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisVentas.BusinessEntities
{
    public class Trabajador
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string NumDocumento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Acceso { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Ingreso> Ingresos { get; set; }
        public virtual ICollection<Venta> Ventas { get; set; }
    }
}
