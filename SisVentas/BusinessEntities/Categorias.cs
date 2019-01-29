using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class Categorias
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage ="Este campo es obligatorio")]
        [StringLength(50,ErrorMessage ="Longitud maxima de 50 caracteres")]
        public String nombre { get; set; }

        [StringLength(60,ErrorMessage ="Longitud maxima de 60 caracteres")]
        public String descripcion { get; set; }
    }
}