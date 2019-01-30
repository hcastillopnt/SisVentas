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
            //Lista para almacenar el objeto a buscar
            List<Proveedor> Proveedors = new List<Proveedor>();
        
            switch (bandera)
            {
                case "ProveedorId":
                    int ProveedorID = Convert.ToInt32(Filter);
                    Proveedors = SistemasVentas.DataAccessLayer.ProveedorDAL.getProveedorByID(ProveedorID);
                    break;
            }
            return Proveedors;

        }

        public static List<Proveedor> getProveedorByID(int ProveedorID)
        {
            //Lista para almacenar el objeto a buscar
            List<Proveedor> Proveedors = new List<Proveedor>();

            //Puente entre el DataAccessLayer y el BussinesLogicLayer
            Proveedors = SistemasVentas.DataAccessLayer.ProveedorDAL.getProveedorByID(ProveedorID);

            return Proveedors;


        }

        public static List<Proveedor> getAllProveedor()
        {
            //Lista para almacenar el objeto a buscar
            List<Proveedor> Proveedors = new List<Proveedor>();

            //Puente entre el DataAccessLayer y el BussinesLogicLayer
            Proveedors = SistemasVentas.DataAccessLayer.ProveedorDAL.getAllProveedor();

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
                message = SistemasVentas.DataAccessLayer.ProveedorDAL.insertProveedor(objProveedor);
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
                message = SistemasVentas.DataAccessLayer.ProveedorDAL.updateProveedor(objProveedor);
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

                return SistemasVentas.DataAccessLayer.ProveedorDAL.removeProveedor(ProveedorID);

            }
            else
            {
                return "Error";
            }

        }
    }
}
