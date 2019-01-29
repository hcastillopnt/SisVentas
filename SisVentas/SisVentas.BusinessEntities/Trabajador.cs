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
        [Key]//llave primaria
        public int ID { get; set; }

        [Required(ErrorMessage ="Campo NOMBRE es obligatorio")]//requerido
        [StringLength(20, ErrorMessage ="Longitud maxima es 20")]//longitud del string
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Campo APELLIDOS es obligatorio")]//requerido
        [StringLength(40, ErrorMessage = "Longitud maxima es 40")]//longitud del string
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "Campo SEXO es obligatorio")]//requerido
        [StringLength(1, ErrorMessage = "Longitud maxima es 1")]//longitud del string
        public string Sexo { get; set; }

        [Required(ErrorMessage = "Campo FECHA DE NACIMIENTO es obligatorio")]//requerido
        [DataType(DataType.DateTime)]//fecha
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Campo NUMERO DE DOCUMENTO es obligatorio")]//requerido
        [StringLength(8, ErrorMessage = "Longitud maxima es 8")]//longitud del string
        public string NumDocumento { get; set; }

        [StringLength(100, ErrorMessage = "Longitud maxima es 100")]//longitud del string
        public string Direccion { get; set; }

        [StringLength(10, ErrorMessage = "Longitud maxima es 10")]//longitud del string
        public string Telefono { get; set; }

        [StringLength(50, ErrorMessage = "Longitud maxima es 50")]//longitud del string
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo ACCESO es obligatorio")]//requerido
        [StringLength(20, ErrorMessage = "Longitud maxima es 20")]//longitud del string
        public string Acceso { get; set; }

        [Required(ErrorMessage = "Campo USUARIO es obligatorio")]//requerido
        [StringLength(20, ErrorMessage = "Longitud maxima es 20")]//longitud del string
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Campo CONTRASEÑA es obligatorio")]//requerido
        [StringLength(20, ErrorMessage = "Longitud maxima es 20")]//longitud del string
        public string Contraseña { get; set; }
    }
}
