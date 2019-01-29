using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
   public class Proveedor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Razon Social es obligatorio ")]
        [StringLength(50, ErrorMessage = "La longitud es de 50 caracteres")]
        public string razon_Social { get; set; }

        [Required(ErrorMessage = "El campo Sector Comercial es obligatorio ")]
        [StringLength(30, ErrorMessage = "La longitud es de 30 caracteres")]
        public string sector_Comercial { get; set; }

        [Required(ErrorMessage = "El campo Tipo Documento es obligatorio ")]
        [StringLength(20, ErrorMessage = "La longitud es de 20 caracteres")]
        public string tipo_Documento { get; set; }

        [Required(ErrorMessage = "El campo Numero de Documento es obligatorio ")]
        [StringLength(10, ErrorMessage = "La longitud es de 10 caracteres")]
        public string num_Caracter { get; set; }

        
        [StringLength(50, ErrorMessage = "La longitud es de 50 caracteres")]
        public string direccion { get; set; }

        
        [StringLength(20, ErrorMessage = "La longitud es de 20 caracteres")]
        public string telefono { get; set; }

     
        [StringLength(30, ErrorMessage = "La longitud es de 30 caracteres")]
        public string email { get; set; }

       
        [DataType(DataType.Url)]
        public string url { get; set; }


    }
}
