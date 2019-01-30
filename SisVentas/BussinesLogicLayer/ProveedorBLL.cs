using SistemasVentas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogicLayer
{
    public class ProveedorBLL
    {
        public static List<Proveedor> getProveedorByID(int ProveedorID)
        {
            //Lista para almacenar el objeto a buscar
            List<Proveedor> proveedors = new List<Proveedor>();

            //Puente entre el DataAccessLayer y el BussinesLogicLayer
            proveedors = DataAccessLayer.ProveedoresDAL.getProveedorByID(ProveedorID);

            return proveedors;

        }

        public static List<Proveedor> getAllProveedor()
        {
            //Lista para almacenar el objeto a buscar
            List<Proveedor> proveedors = new List<Proveedor>();

            //Puente entre el DataAccessLayer y el BussinesLogicLayer
            proveedors = DataAccessLayer.ProveedoresDAL.getAllProveedor();

            return proveedors ;
        }

        //metodo para insertar los estudiantes
        public static string insertProveedor(Proveedor objProveedor)

        {//Variable para almacenar el mensaje de error en caso de que ocurra alguno
            string message = string.Empty;

            ICollection<ValidationResult> result = null;

            if (!validate(objProveedor, out result))
            {
                message = string.Join("\n", result.Select(o => o.ErrorMessage));
            }
            else
            {
                message = DataAccessLayer.ProveedoresDAL.insertarProveedor(objProveedor);
            }


            //regresa el mensaje con o sin errores
            return message;

        }

        public static bool validate<T>(T obj, out ICollection<ValidationResult> results)
        {
            results = new List<ValidationResult>();
            return Validator.TryValidateObject(obj, new ValidationContext(obj), results, true);
        }


        public static string updateProveedor(Proveedor objProveedor)
        {
            //Variable para almacenar el mensaje de error en caso de que ocurra alguno
            string message = string.Empty;

            ICollection<ValidationResult> result = null;

            if (!validate(objProveedor, out result))
            {
                message = string.Join("\n", result.Select(o => o.ErrorMessage));
            }
            else
            {
                message = DataAccessLayer.ProveedoresDAL.updateProveedor(objProveedor);
            }

            //regresa el mensaje con o sin errores
            return message;
        }

        public static string removeProveedor(int ProveedorID)
        {
            //Variable para almacenar el mensaje de error en caso de que ocurra alguno
            string message = string.Empty;

            if (ProveedorID > 0)
            {

                return DataAccessLayer.ProveedoresDAL.removeProveedor(ProveedorID);

            }
            else
            {
                return "Error";
            }

        }
    }
}
