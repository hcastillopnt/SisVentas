using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SisVentas.BusinessEntities
{
    public class Cliente
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        [StringLength(20, ErrorMessage = "La longitud es de 20 caracteres")]

        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo Apellido es obligatorio")]
        [StringLength(40, ErrorMessage = "La longitud es de 40 caracteres")]

        public string Apellidos { get; set; }
        [Required(ErrorMessage = "El campo Sexo es obligatorio")]
        [StringLength(1, ErrorMessage = "La longitud es de 1 caracteres")]

        public string Sexo { get; set; }
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo FechaNacimiento es obligatorio")]

        public DateTime FechaNacimiento { get; set; }
        [Required(ErrorMessage = "El campo TipoDocumento es obligatorio")]
        [StringLength(20, ErrorMessage = "La longitud es de 20 caracteres")]

        public string TipoDocumento { get; set; }
        [Required(ErrorMessage = "El campo NumDocumento es obligatorio")]
        [StringLength(8, ErrorMessage = "La longitud es de 8 caracteres")]

        public string NumDocumento { get; set; }
        [Required(ErrorMessage = "El campo Direccion es obligatorio")]
        [StringLength(100, ErrorMessage = "La longitud es de 100 caracteres")]

        public string Direccion { get; set; }
        [Required(ErrorMessage = "El campo Telefono es obligatorio")]
        [StringLength(10, ErrorMessage = "La longitud es de 10 caracteres")]

        public string Telefono { get; set; }
        [Required(ErrorMessage = "El campo Email es obligatorio")]
        [StringLength(50, ErrorMessage = "La longitud es de 50 caracteres")]

        public string Email { get; set; }

    }
}
