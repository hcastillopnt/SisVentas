using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        [StringLength(30, ErrorMessage = "La longuitud es de 30 caracteres")]
        public string nombre { get; set; }

        [StringLength(30, ErrorMessage = "La longuitud es de 30 caracteres")]
        public string apellido { get; set; }
        
        [StringLength(1, ErrorMessage = "La longuitud es de 1 caracter")]
        public char sexo { get; set; }

        [Required(ErrorMessage = " El campo fecha_nacimiento es obligatorio ")]
        [DataType(DataType.DateTime)]
        public DateTime fecha_nacimiento { get; set; }

        [Required(ErrorMessage = "El campo Tipo de documento es obligatorio")]
        [StringLength(30, ErrorMessage = "La longuitud es de 30 caracteres")]
        public string tipo_documento { get; set; }

        [Required(ErrorMessage = "El campo Numero de documento es obligatorio")]
        [StringLength(8, ErrorMessage = "La longuitud es de 8 caracteres")]
        public String num_documento { get; set; }
        
        [StringLength(50, ErrorMessage = "La longuitud es de 50 caracteres")]
        public string direccion { get; set; }
        
        [StringLength(20, ErrorMessage = "La longuitud es de 20 caracteres")]
        public string telefono { get; set; }
        
        [StringLength(30, ErrorMessage = "La longuitud es de 30 caracteres")]
        public string email { get; set; }
    }
}
