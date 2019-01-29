using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class Presentacion
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        [StringLength(35, ErrorMessage = "La longuitud es de 35 caracteres")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "El campo Descripcion es obligatorio")]
        [StringLength(70, ErrorMessage = "La longuitud es de 70 caracteres")]
        public string descripcion { get; set; }

    }
}
