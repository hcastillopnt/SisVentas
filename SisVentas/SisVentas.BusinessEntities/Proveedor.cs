using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SisVentas.BusinessEntities
{
    public class Proveedor
    {
        public int ID { get; set; }

        public string RazonSocial { get; set; }

        public string SectorComercial { get; set; }

        public string TipoDocumento { get; set; }

        public string NumDocumento { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string Email { get; set; }

        public string URL { get; set; }
    }
}
