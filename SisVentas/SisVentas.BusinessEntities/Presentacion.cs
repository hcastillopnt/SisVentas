using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisVentas.BusinessEntities
{
    public class Presentacion

    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "El nombre tiene capasidad de 50 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La descripcion es obligatoria")]
        [StringLength(50, ErrorMessage = "La descripcion es de 50 caracteres")]
        public string Descripcion { get; set; }
    }
}
