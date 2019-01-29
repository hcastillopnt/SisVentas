using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemasVentas
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "El campo Nombre es obligatorio")]//Obligatorio
        [StringLength(20, ErrorMessage = "La longitud es de 20 caracteres")]//Longitud de la cadena
        public string Nombre { get; set; }



        [Required(ErrorMessage = "El campo Apellidos es obligatorio")]//Obligatorio
        [StringLength(40, ErrorMessage = "La longitud es de 40 caracteres")]//Longitud de la cadena
        public string Apellidos { get; set; }



        [Required(ErrorMessage = "El campo Sexo es obligatorio")]//Obligatorio
        [StringLength(1, ErrorMessage = "La longitud es de 1 caracter")]//Longitud de la cadena
        public string Sexo { get; set; }


        [Required(ErrorMessage = " El campo FechaNacimiento es obligatorio ")]
        [DataType(DataType.DateTime)]
        public DateTime FechaNacimiento { get; set; }



        [Required(ErrorMessage = "El campo TipoDocumento es obligatorio")]//Obligatorio
        [StringLength(20, ErrorMessage = "La longitud es de 20caracter")]//Longitud de la cadena
        public  string TipoDocumento { get; set; }


        [Required(ErrorMessage = "El campo NumeroDocumento es obligatorio")]//Obligatorio
        [StringLength(50, ErrorMessage = "La longitud es de 50 caracteres")]//Longitud de la cadena
        public string NumeroDocumento { get; set; }


        [Required(ErrorMessage = "El campo Direccion es obligatorio")]//Obligatorio
        [StringLength(100, ErrorMessage = "La longitud es de 100 caracter")]//Longitud de la cadena
        public string Direccion { get; set;}


        [Required(ErrorMessage = "El campo Telefono es obligatorio")]//Obligatorio
        [StringLength(15, ErrorMessage = "La longitud es de 15 caracter")]//Longitud de la cadena
        public string Telefono { get; set; }


        [Required(ErrorMessage = "El campo Email es obligatorio")]//Obligatorio
        [StringLength(50, ErrorMessage = "La longitud es de 50 caracter")]//Longitud de la cadena
        public string Email { get; set; }



        [ForeignKey("Venta")]
        [Required(ErrorMessage = "El campo VentaId es obligatorio")]
        [Range(0, int.MaxValue, ErrorMessage = "Debe ser un numero entero")]
        public int VentaId { get; set; }






    }
}
