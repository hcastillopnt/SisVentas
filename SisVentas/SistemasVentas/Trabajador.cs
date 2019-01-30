using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemasVentas
{
    public class Trabajador
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



        [Required(ErrorMessage = "El campo NumeroDocumento es obligatorio")]//Obligatorio
        [StringLength(8, ErrorMessage = "La longitud es de 8 caracteres")]//Longitud de la cadena
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



        [Required(ErrorMessage = "El campo Acceso es obligatorio")]//Obligatorio
        [StringLength(20, ErrorMessage = "La longitud es de 20 caracter")]//Longitud de la cadena
        public string Acceso { get; set; }



        [Required(ErrorMessage = "El campo Usuario es obligatorio")]//Obligatorio
        [StringLength(20, ErrorMessage = "La longitud es de 20 caracter")]//Longitud de la cadena
        public string Usuario { get; set; }



        [Required(ErrorMessage = "El campo Email es obligatorio")]//Obligatorio
        [StringLength(20, ErrorMessage = "La longitud es de 20 caracter")]//Longitud de la cadena
        public string Password { get; set; }

        public virtual ICollection<Venta> Ventas { get; set; }
        public virtual ICollection<Ingreso> Ingresos { get; set; }









    }
}
