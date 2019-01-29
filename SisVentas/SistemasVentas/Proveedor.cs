using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemasVentas
{
   public  class Proveedor
    {
        [Key]
        public int Id;


        [Required(ErrorMessage = "El campo RazonSocial es obligatorio")]//Obligatorio
        [StringLength(150, ErrorMessage = "La longitud es de 150 caracteres")]//Longitud de la cadena
        public string RazonSocial { get; set; }


        [Required(ErrorMessage = "El campo SectorComercial es obligatorio")]//Obligatorio
        [StringLength(50, ErrorMessage = "La longitud es de 5 caracteres")]//Longitud de la cadena
        public string SectorComercial { get; set; }


        [Required(ErrorMessage = "El campo TipoDocumento es obligatorio")]//Obligatorio
        [StringLength(20, ErrorMessage = "La longitud es de 20 caracteres")]//Longitud de la cadena
        public string TipoDocumento { get; set; }


        [Required(ErrorMessage = "El campo NumeroDocumento es obligatorio")]//Obligatorio
        [StringLength(11, ErrorMessage = "La longitud es de 11 caracteres")]//Longitud de la cadena
        public string NumeroDocumento { get; set; }


        [Required(ErrorMessage = "El campo Direccion es obligatorio")]//Obligatorio
        [StringLength(100, ErrorMessage = "La longitud es de 100 caracter")]//Longitud de la cadena
        public string Direccion { get; set; }


        [Required(ErrorMessage = "El campo Telefono es obligatorio")]//Obligatorio
        [StringLength(15, ErrorMessage = "La longitud es de 15 caracter")]//Longitud de la cadena
        public string Telefono { get; set; }


        [Required(ErrorMessage = "El campo Email es obligatorio")]//Obligatorio
        [StringLength(50, ErrorMessage = "La longitud es de 50 caracter")]//Longitud de la cadena
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo Url es obligatorio")]//Obligatorio
        [StringLength(100, ErrorMessage = "La longitud es de 100 caracteres")]//Longitud de la cadena
        public string Url { get; set; }

        public virtual ICollection<Ingreso> Ingresos { get; set; }













    }
}
