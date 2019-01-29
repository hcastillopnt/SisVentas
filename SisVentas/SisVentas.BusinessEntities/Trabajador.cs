using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SisVentas.BusinessEntities
{
    public class Trabajador
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage ="Campo NOMBRE es obligatorio")]
        [StringLength(20, ErrorMessage ="Longitud maxima es 20")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Campo APELLIDOS es obligatorio")]
        [StringLength(40, ErrorMessage = "Longitud maxima es 40")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "Campo SEXO es obligatorio")]
        [StringLength(1, ErrorMessage = "Longitud maxima es 1")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "Campo FECHA DE NACIMIENTO es obligatorio")]
        [DataType(DataType.DateTime)]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Campo NUMERO DE DOCUMENTO es obligatorio")]
        [StringLength(8, ErrorMessage = "Longitud maxima es 8")]
        public string NumDocumento { get; set; }

        [StringLength(100, ErrorMessage = "Longitud maxima es 100")]
        public string Direccion { get; set; }

        [StringLength(10, ErrorMessage = "Longitud maxima es 10")]
        public string Telefono { get; set; }

        [StringLength(50, ErrorMessage = "Longitud maxima es 50")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo ACCESO es obligatorio")]
        [StringLength(20, ErrorMessage = "Longitud maxima es 20")]
        public string Acceso { get; set; }

        [Required(ErrorMessage = "Campo USUARIO es obligatorio")]
        [StringLength(20, ErrorMessage = "Longitud maxima es 20")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Campo CONTRASEÑA es obligatorio")]
        [StringLength(20, ErrorMessage = "Longitud maxima es 20")]
        public string Contraseña { get; set; }
    }
}
