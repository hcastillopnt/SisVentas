using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class Trabajador
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        [StringLength(30, ErrorMessage = "La longuitud es de 30 caracteres")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "El campo Apellido es obligatorio")]
        [StringLength(30, ErrorMessage = "La longuitud es de 30 caracteres")]
        public string apellido { get; set; }

        public char sexo { get; set; }

        [Required(ErrorMessage = " El campo fecha_nacimiento es obligatorio ")]
        [DataType(DataType.DateTime)]
        public DateTime fecha_nacimiento { get; set; }

        [Required(ErrorMessage = "El campo Numero de documento es obligatorio")]
        [StringLength(15, ErrorMessage = "La longuitud es de 8 caracteres")]
        public String num_documento { get; set; }

        [StringLength(50, ErrorMessage = "La longuitud es de 50 caracteres")]
        public string direccion { get; set; }

        [StringLength(20, ErrorMessage = "La longuitud es de 20 caracteres")]
        public string telefono { get; set; }

        [StringLength(30, ErrorMessage = "La longuitud es de 30 caracteres")]
        public string email { get; set; }
        
        public string acceso { get; set; }

        [Required(ErrorMessage = "El campo usuario de documento es obligatorio")]
        [StringLength(20, ErrorMessage = "El usuario es de 20 caracteres")]
        public string usuario { get; set; }

        [Required(ErrorMessage = "El campo password de documento es obligatorio")]
        [StringLength(20, ErrorMessage = "El password es de 20 caracteres")]
        public string password { get; set; }
    }
}