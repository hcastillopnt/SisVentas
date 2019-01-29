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
        [Key]
        public int ID { get; set; }


        [Required(ErrorMessage = "El campo RazonSocial es oblogatorio")]//Obligatorio 
        [StringLength(150, ErrorMessage = "La longitud máxima es de 150 caracteres")]//Longitud de la cadena
        public string RazonSocial { get; set; }


        [Required(ErrorMessage = "El campo SectorComercial es oblogatorio")]//Obligatorio 
        [StringLength(50, ErrorMessage = "La longitud máxima es de 50 caracteres")]//Longitud de la cadena
        public string SectorComercial { get; set; }


        [Required(ErrorMessage = "El campo TipoDocumento es oblogatorio")]//Obligatorio 
        [StringLength(20, ErrorMessage = "La longitud máxima es de 20 caracteres")]//Longitud de la cadena
        public string TipoDocumento { get; set; }


        [Required(ErrorMessage = "El campo NumDocumento es oblogatorio")]//Obligatorio 
        [StringLength(11, ErrorMessage = "La longitud máxima es de 11 caracteres")]//Longitud de la cadena
        public string NumDocumento { get; set; }
        

        [StringLength(100, ErrorMessage = "La longitud máxima es de 100 caracteres")]//Longitud de la cadena
        public string Direccion { get; set; }


        [StringLength(50, ErrorMessage = "La longitud máxima es de 50 caracteres")]//Longitud de la cadena
        public string Telefono { get; set; }


        [StringLength(50, ErrorMessage = "La longitud máxima es de 50 caracteres")]//Longitud de la cadena
        public string Email { get; set; }


        [StringLength(100, ErrorMessage = "La longitud máxima es de 100 caracteres")]//Longitud de la cadena
        public string URL { get; set; }
    }
}
