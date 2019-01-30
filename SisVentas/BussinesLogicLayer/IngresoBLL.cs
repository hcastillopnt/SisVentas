using SistemasVentas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogicLayer
{
    public class IngresoBLL
    {
        public static List<Ingreso> getProveedorByID(int IngresoID)
        {
            //Lista para almacenar el objeto a buscar
            List<Ingreso> ingresos = new List<Ingreso>();

            //Puente entre el DataAccessLayer y el BussinesLogicLayer
            ingresos = DataAccessLayer.IngresoDAL.getIngresoByID(IngresoID);

            return ingresos;

        }

        public static List<Ingreso> getAllIngreso()
        {
            //Lista para almacenar el objeto a buscar
            List<Ingreso> ingresos = new List<Ingreso>();

            //Puente entre el DataAccessLayer y el BussinesLogicLayer
            ingresos = DataAccessLayer.IngresoDAL.getAllIngreso();

            return ingresos;
        }

        //metodo para insertar los estudiantes
        public static string insertIngreso(Ingreso objIngreso)

        {//Variable para almacenar el mensaje de error en caso de que ocurra alguno
            string message = string.Empty;

            ICollection<ValidationResult> result = null;

            if (!validate(objIngreso, out result))
            {
                message = string.Join("\n", result.Select(o => o.ErrorMessage));
            }
            else
            {
                message = DataAccessLayer.IngresoDAL.insertarIngreso(objIngreso);
            }


            //regresa el mensaje con o sin errores
            return message;

        }

        public static bool validate<T>(T obj, out ICollection<ValidationResult> results)
        {
            results = new List<ValidationResult>();
            return Validator.TryValidateObject(obj, new ValidationContext(obj), results, true);
        }


        public static string updateIngreso(Ingreso objIngreso)
        {
            //Variable para almacenar el mensaje de error en caso de que ocurra alguno
            string message = string.Empty;

            ICollection<ValidationResult> result = null;

            if (!validate(objIngreso, out result))
            {
                message = string.Join("\n", result.Select(o => o.ErrorMessage));
            }
            else
            {
                message = DataAccessLayer.IngresoDAL.updateInngreso(objIngreso);
            }

            //regresa el mensaje con o sin errores
            return message;
        }

        public static string removeProveedor(int IngresoID)
        {
            //Variable para almacenar el mensaje de error en caso de que ocurra alguno
            string message = string.Empty;

            if (IngresoID > 0)
            {

                return DataAccessLayer.IngresoDAL.removeIngreso(IngresoID);

            }
            else
            {
                return "Error";
            }

        }

    }
}
