using SistemasVentas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogicLayer
{
    public class VentaBLL
    {
       

        public static List<Venta> getVentaByFecha(DateTime Ventafecha)
        {
            //Lista para almacenar el objeto a buscar
            List<Venta> ventas = new List<Venta>();

            //Puente entre el DataAccessLayer y el BussinesLogicLayer
            ventas = DataAccessLayer.VentaDAL.getVentaByFecha(Ventafecha);

            return ventas;

        }

        public static List<Venta> getAllVenta()
        {
            //Lista para almacenar el objeto a buscar
            List<Venta> ventas = new List<Venta>();

            //Puente entre el DataAccessLayer y el BussinesLogicLayer
            ventas = DataAccessLayer.VentaDAL.getAllVentas();

            return ventas;
        }

        //metodo para insertar los estudiantes
        public static string insertVenta(Venta objVenta)

        {//Variable para almacenar el mensaje de error en caso de que ocurra alguno
            string message = string.Empty;

            ICollection<ValidationResult> result = null;

            if (!validate(objVenta, out result))
            {
                message = string.Join("\n", result.Select(o => o.ErrorMessage));
            }
            else
            {
                message = DataAccessLayer.VentaDAL.insertarVenta(objVenta);
            }


            //regresa el mensaje con o sin errores
            return message;

        }

        public static bool validate<T>(T obj, out ICollection<ValidationResult> results)
        {
            results = new List<ValidationResult>();
            return Validator.TryValidateObject(obj, new ValidationContext(obj), results, true);
        }


        public static string updateVenta(Venta objVenta)
        {
            //Variable para almacenar el mensaje de error en caso de que ocurra alguno
            string message = string.Empty;

            ICollection<ValidationResult> result = null;

            if (!validate(objVenta, out result))
            {
                message = string.Join("\n", result.Select(o => o.ErrorMessage));
            }
            else
            {
                message = DataAccessLayer.VentaDAL.updateVenta(objVenta);
            }

            //regresa el mensaje con o sin errores
            return message;
        }

        public static string removeStudent(int VentaID)
        {
            //Variable para almacenar el mensaje de error en caso de que ocurra alguno
            string message = string.Empty;

            if (VentaID > 0)
            {

                return DataAccessLayer.VentaDAL.removeVenta(VentaID);

            }
            else
            {
                return "Error";
            }

        }
    }
}
