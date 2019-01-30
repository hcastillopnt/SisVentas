using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemasVentas;

namespace SistemasVentas.BussinesLogicLayer
{
   public class ProveedorBLL
    {
        public static List<Proveedor> getProveedorByFilter(string Filter, string bandera)
        {
            //almacenar el objeto a buscar
            List<Proveedor> Proveedors = new List<Proveedor>();
            return Proveedors;

        }

        public static List<Proveedor> getProveedorByID(int ProveedorID)
        {
            //Lista para almacenar el objeto a buscar
            List<Proveedor> Proveedors = new List<Proveedor>();

            //Puente entre el DataAccessLayer y el BussinesLogicLayer
            Proveedors = SistemasVentas.DataAccessLayer.ProveedoresDAL.getProveedorByID(ProveedorID);

            return Proveedors;


        }

        public static List<Proveedor> getAllProveedors()
        {
            //Lista para almacenar el objeto a buscar
            List<Proveedor> Proveedors = new List<Proveedor>();

            //Puente entre el DataAccessLayer y el BussinesLogicLayer
            Proveedors = SistemasVentas.DataAccessLayer.ProveedoresDAL.getAllProveedor();

            return Proveedors;
        }
   
       public static string insertProveedor(Proveedor objProveedor)
        {
            //Variable para almacenar el mensaje de error en caso de que ocurra alguno
            string message = string.Empty;

            ICollection<ValidationResult> result = null;

            if(!validate(objProveedor,out result))
            {
                message = string.Join("\n", result.Select(o => o.ErrorMessage));
            }
            else
            {
                message = SistemasVentas.DataAccessLayer.ProveedoresDAL.insertProveedor(objProveedor);
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
                message = SistemasVentas.DataAccessLayer.ProveedoresDAL.updateProveedor(objProveedor);
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

                return SistemasVentas.DataAccessLayer.ProveedoresDAL.removeProveedor(ProveedorID);

            }
            else
            {
                return "Error";
            }

        }
    }
}
