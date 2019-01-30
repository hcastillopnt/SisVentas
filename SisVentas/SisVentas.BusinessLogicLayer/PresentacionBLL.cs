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

            if (!validate(objpresentacion, out results))
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

        public static string updatePresentacion(Presentacion presentacion)
        {
            //variable para almacenar mensaje en caso de error
            string message = string.Empty;

            //primer validacion - verificar campos vacios;          
            if (string.IsNullOrEmpty(presentacion.Nombre))
            {
                message = "El campo Nombre esta vacio, favor de completarlo";
            }
            else
            {
                if (string.IsNullOrEmpty(presentacion.Descripcion))
                {
                    message = "El campo Descripcion esta vacio, favor de completarlo";
                }
                else
                {
                    //puente
                    message = SisVentas.DataAccessLayer.PresentacionDAL.updatepresentacion(presentacion);
                }
            }
            //regresa el mensaje con o sin errores
            return message;
        }



        public static string deletePresentacion(int presentacionId)
        {
            if (presentacionId > 0)
            {
                return DataAccessLayer.PresentacionDAL.deletePresentacion(presentacionId);
            }
            else
            {
                return "Error";
            }
        }

        public static List<Presentacion> getPresentacionByNombre(string presentacionNom)
        {
            //lista para almacenar el objeto a buscar
            List<Presentacion> presentacions = new List<Presentacion>();

            //puente entre DAL y BLL
            presentacions = DataAccessLayer.PresentacionDAL.getPresentacionByNom(presentacionNom);

            return presentacions;
        }
    }


}
