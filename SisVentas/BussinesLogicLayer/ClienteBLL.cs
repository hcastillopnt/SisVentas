using SistemasVentas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogicLayer
{
    public class ClienteBLL
    {
        public static List<Cliente> getClienteByID(int ClienteID)
        {
            //Lista para almacenar el objeto a buscar
            List<Cliente> clientes = new List<Cliente>();

            //Puente entre el DataAccessLayer y el BussinesLogicLayer
            clientes = DataAccessLayer.ClienteDAL.getClienteByID(ClienteID);

            return clientes;

        }
        public static List<Cliente> getClienteByApellido(string Apellido)
        {
            //Lista para almacenar el objeto a buscar
            List<Cliente> clientes = new List<Cliente>();

            //Puente entre el DataAccessLayer y el BussinesLogicLayer
            clientes = DataAccessLayer.ClienteDAL.getClientebyApellidos(Apellido);

            return clientes;

        }



        public static List<Cliente> getAllCliente()
        {
            //Lista para almacenar el objeto a buscar
            List<Cliente> clientes = new List<Cliente>();

            //Puente entre el DataAccessLayer y el BussinesLogicLayer
           clientes = DataAccessLayer.ClienteDAL.getAllCliente();

            return clientes;
        }

        //metodo para insertar los estudiantes
        public static string insertCliente(Cliente objCliente)

        {//Variable para almacenar el mensaje de error en caso de que ocurra alguno
            string message = string.Empty;

            ICollection<ValidationResult> result = null;

            if (!validate(objCliente, out result))
            {
                message = string.Join("\n", result.Select(o => o.ErrorMessage));
            }
            else
            {
                message = DataAccessLayer.ClienteDAL.insertarCliente(objCliente);
            }


            //regresa el mensaje con o sin errores
            return message;

        }

        public static bool validate<T>(T obj, out ICollection<ValidationResult> results)
        {
            results = new List<ValidationResult>();
            return Validator.TryValidateObject(obj, new ValidationContext(obj), results, true);
        }


        public static string updatecliente(Cliente objCliente)
        {
            //Variable para almacenar el mensaje de error en caso de que ocurra alguno
            string message = string.Empty;

            ICollection<ValidationResult> result = null;

            if (!validate(objCliente, out result))
            {
                message = string.Join("\n", result.Select(o => o.ErrorMessage));
            }
            else
            {
                message = DataAccessLayer.ClienteDAL.updateCliente(objCliente);
            }

            //regresa el mensaje con o sin errores
            return message;
        }

        public static string removeCliente(int ClienteID)
        {
            //Variable para almacenar el mensaje de error en caso de que ocurra alguno
            string message = string.Empty;

            if (ClienteID > 0)
            {

                return DataAccessLayer.ClienteDAL.removeCliente(ClienteID);

            }
            else
            {
                return "Error";
            }

        }
    }
}
