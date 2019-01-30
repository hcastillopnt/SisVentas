using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisVentas.BusinessEntities;
using SisVentas.DataAccessLayer;

namespace SisVentas.BusinessLogicLayer
{
    public class PresentacionBLL
    {
        public static string insertPresentacion(Presentacion objpresentacion)
        {
            string message = string.Empty;

            ICollection<ValidationResult> results = null;

            if(!validate(objpresentacion, out results))
            {
                message = String.Join("\n", results.Select(o => o.ErrorMessage));

            }
            else
            {
                message = DataAccessLayer.PresentacionDAL.InsertarPresentacion(objpresentacion);
            }
            return message;
        }

        private static bool validate<T>(T obj, out ICollection<ValidationResult> results)
        {
            results = new List<ValidationResult>();
            return Validator.TryValidateObject(obj, new ValidationContext(obj), results, true);
        }
    }
}
