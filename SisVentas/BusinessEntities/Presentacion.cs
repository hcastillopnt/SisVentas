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
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        [StringLength(35, ErrorMessage = "La longuitud es de 35 caracteres")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "El campo Descripcion es obligatorio")]
        [StringLength(60, ErrorMessage = "La longuitud es de 60 caracteres")]
        public string descripcion { get; set; }
    }
}


