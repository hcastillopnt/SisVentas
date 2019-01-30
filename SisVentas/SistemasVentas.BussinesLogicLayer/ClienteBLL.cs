using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemasVentas.BussinesLogicLayer
{
    public class ClienteBLL
    {

        public static List<Cliente> getClienteByFilter(string Filter, string bandera)
        {
            //Lista para almacenar el objeto a buscar
            List<Cliente> students = new List<Cliente>();

            switch (bandera)
            {
                /*case "FirstMideName":
                    break;
                case "LastName":
                    students = SistemasVentas.DataAccessLayer.ClienteDAL.getStudentsByLastName(Filter);
                    break; */

                case "StudentId":
                    int clienteId = Convert.ToInt32(Filter);
                    students = DataAccessLayer.ClienteDAL.getClienteByID(clienteId);
                    break;

            }
            return students;

        }

        public static List<Cliente> getClienteByID(int ClienteId)
        {
            //Lista para almacenar el objeto a buscar
            List<Cliente> students = new List<Cliente>();

            //Puente entre el DataAccessLayer y el BussinesLogicLayer
            students = DataAccessLayer.ClienteDAL.getClienteByID(ClienteId);

            return students;
        }

        public static List<Cliente> getAllClientes()
        {
            //Lista para almacenar el objeto a buscar
            List<Cliente> students = new List<Cliente>();

            //Puente entre el DataAccessLayer y el BussinesLogicLayer
            students = DataAccessLayer.ClienteDAL.getAllClientes();

            return students;
        }


        //metodo para insertar los Clientes
        public static string insertCliente(Cliente entity)
        {
            //Variable para almacenar el mensaje de error en caso de que ocurra alguno
            string message = string.Empty;

            //primera validacion - Verificar los campos vacios
            if (string.IsNullOrEmpty(entity.Nombre))
            {
                message = "El campo Nombre esta vacio, favor de completarlo";
            }
            else if (string.IsNullOrEmpty(entity.Apellidos))
            {
                message = "El campo Apellido esta vacío, favor de completarlo";
            }
            else if (entity.FechaNacimiento == DateTime.Now)
            {
                message = "La fecha de nacimiento es incorrecto / no pudo nacer hoy";
            }
            else if (string.IsNullOrEmpty(entity.TipoDocumento))
            {
                message = "El campo tipo de documento esta vacío, favor de completarlo";
            }
            else if (string.IsNullOrEmpty(entity.NumeroDocumento))
            {
                message = "El campo numero de documento esta vacío, favor de completarlo";
            }
            else if (string.IsNullOrEmpty(entity.Direccion))
            {
                message = "El campo direccion esta vacío, favor de completarlo";
            }
            else if (string.IsNullOrEmpty(entity.Telefono))
            {
                message = "El campo telefono esta vacío, favor de completarlo";
            }
            else if (string.IsNullOrEmpty(entity.Email))
            {
                message = "El campo email esta vacío, favor de completarlo";
            }
            else
            {
                //Este es el puent entre la capa dde negocios y el acceso a datos
                message = DataAccessLayer.ClienteDAL.insertCliente(entity);
            }

            //regresa el mensaje con o sin errores
            return message;

        }

        public static string updateCliente(Cliente entity)
        {
            //Variable para almacenar el mensaje de error en caso de que ocurra alguno
            string message = string.Empty;

            //primera validacion - Verificar los campos vacios
            if (string.IsNullOrEmpty(entity.Nombre))
            {
                message = "El campo Nombre esta vacio, favor de completarlo";
            }
            else if (string.IsNullOrEmpty(entity.Apellidos))
            {
                message = "El campo Apellido esta vacío, favor de completarlo";
            }
            else if (entity.FechaNacimiento == DateTime.Now)
            {
                message = "La fecha de nacimiento es incorrecto / no pudo nacer hoy";
            }
            else if (string.IsNullOrEmpty(entity.TipoDocumento))
            {
                message = "El campo tipo de documento esta vacío, favor de completarlo";
            }
            else if (string.IsNullOrEmpty(entity.NumeroDocumento))
            {
                message = "El campo numero de documento esta vacío, favor de completarlo";
            }
            else if (string.IsNullOrEmpty(entity.Direccion))
            {
                message = "El campo direccion esta vacío, favor de completarlo";
            }
            else if (string.IsNullOrEmpty(entity.Telefono))
            {
                message = "El campo telefono esta vacío, favor de completarlo";
            }
            else if (string.IsNullOrEmpty(entity.Email))
            {
                message = "El campo email esta vacío, favor de completarlo";
            }
            else
            {
                //Este es el puent entre la capa dde negocios y el acceso a datos
                message = DataAccessLayer.ClienteDAL.updateCliente(entity);
            }

            //regresa el mensaje con o sin errores
            return message;

        }

        public static string removeCliente(int ClienteId)
        {
            //Variable para almacenar el mensaje de error en caso de que ocurra alguno
            string message = string.Empty;

            if (ClienteId > 0)
            {

                return DataAccessLayer.ClienteDAL.removeCliente(ClienteId);

            }
            else
            {
                return "Error";
            }
        }

    }
}

