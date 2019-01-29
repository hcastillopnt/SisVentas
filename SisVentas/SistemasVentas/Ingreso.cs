using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemasVentas
{
    public class Ingreso
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = " El campo Fecha es obligatorio ")]
        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }



        [Required(ErrorMessage = "El campo TipoComprobante es obligatorio")]//Obligatorio
        [StringLength(20, ErrorMessage = "La longitud es de 20 caracteres")]//Longitud de la cadena
        public string TipoComporbante { get; set; }



        [Required(ErrorMessage = "El campo Serie es obligatorio")]//Obligatorio
        [StringLength(4, ErrorMessage = "La longitud es de 4 caracteres")]//Longitud de la cadena
        public string Serie { get; set; }


        [Required(ErrorMessage = "El campo Correlativo es obligatorio")]//Obligatorio
        [StringLength(7, ErrorMessage = "La longitud es de 7 caracteres")]//Longitud de la cadena
        public string Correlativo { get; set; }


        [Required(ErrorMessage = "El campo Igv es obligatorio")]//Obligatorio
        [Range(0, double.MaxValue, ErrorMessage = "Debe ser un numero con decimales")]
        public double Igv { get; set; }

        [ForeignKey("Trabajador")]
        [Required(ErrorMessage = "El campo TrabajadorId es obligatorio")]
        [Range(0, int.MaxValue, ErrorMessage = "Debe ser un numero entero")]
        public int TrabajadorId { get; set; }
        public Trabajador Trabajador { get; set; }


        [ForeignKey("Proveedor")]
        [Required(ErrorMessage = "El campo ProveedorId es obligatorio")]
        [Range(0, int.MaxValue, ErrorMessage = "Debe ser un numero entero")]
        public int ProveedorId { get; set; }
        public Proveedor Proveedor { get; set; }








    }
}
