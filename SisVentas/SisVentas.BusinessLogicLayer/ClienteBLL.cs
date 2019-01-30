using System;
using System.Collections.Generic;
using SisVentas.BusinessEntities;
using SisVentas.DataAccessLayer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisVentas.BusinessLogicLayer
{
    public class ClienteBLL
    {
        public static List<Cliente> getClienteByFilter(string Filter, string bandera)
        {
            List<Cliente> clientes = new List<Cliente>();

            switch (bandera)
            {
                case "Nombre":
                    clientes = DataAccessLayer.ClienteDAL.getClienteByNombre(Filter);
                    break;

                case "Apellidos":
                    clientes = DataAccessLayer.ClienteDAL.getClienteByApellidos(Filter);
                    break;

                case "NumDocumento":
                    clientes = DataAccessLayer.ClienteDAL.getClienteByNumDocumento(Filter);
                    break;

                case "ID":
                    int ID = Convert.ToInt32(Filter);
                    clientes = DataAccessLayer.ClienteDAL.getClienteByID(ID);
                    break;
            }
            return clientes;
        }


        public static List<Cliente> getClienteByID(int ID)
        {
            //Lista para almacenar el objeto a buscar
            List<Cliente> clientes = new List<Cliente>();

            //Crear el puente entre el DAL y la capa de Negoios (BLL)
            clientes = DataAccessLayer.ClienteDAL.getClienteByID(ID);

            return clientes;
        }



        public static List<Cliente> getAllClientes()
        {
            List<Cliente> clientes = new List<Cliente>();

            //Es el puente entre el DataAccessLayer y el BusinessLogicLayer
            clientes = DataAccessLayer.ClienteDAL.getAllClientes();

            return clientes;
        }


        //Metodo para obtener los estudiantes por medio del apellido

        public static List<Cliente> getClienteByNumDocumento(string numdocumento)
        {
            List<Cliente> clientes = new List<Cliente>();

            //SELECT * FROM Students WHERE LastName = '____'
            clientes = DataAccessLayer.ClienteDAL.getClienteByNumDocumento(numdocumento);

            return clientes;
        }


        public static List<Cliente> getClienteByNombre(string nombre)
        {
            List<Cliente> clientes = new List<Cliente>();

            //SELECT * FROM Students WHERE LastName = '____'
            clientes = DataAccessLayer.ClienteDAL.getClienteByNombre(nombre);

            return clientes;
        }


        public static List<Cliente> getClienteByApellidos(string apellidos)
        {
            List<Cliente> clientes = new List<Cliente>();

            //SELECT * FROM Students WHERE LastName = '____'
            clientes = DataAccessLayer.ClienteDAL.getClienteByApellidos(apellidos);

            return clientes;
        }

        public static string insertCliente(Cliente cliente)
        {
            //Variable para almacenar el mensaje de error en caso de que  ocurra alguno
            string message = string.Empty;

            //1era validacion - Verificar los campos vacios
            if (string.IsNullOrEmpty(cliente.Apellidos))
            {
                message = "El campo Apellido esta vacio, favor de completarlo";
            }
            else
            {
                if (string.IsNullOrEmpty(cliente.Nombre))
                {
                    message = "El campo Nombre esta vacio, favor de completarlo";
                }
                else
                {
                    //Definir la fecha de enrolamiento de manera automatica
                    cliente.FechaNacimiento = DateTime.Now;

                    //Este es el puente enrte la capa de negocios y el acceso a datos
                    message = DataAccessLayer.ClienteDAL.insertCliente(cliente);
                }
            }

            //Regresa el mensaje con o sin errores
            return message;
        }


        public static string updateCliente(Cliente cliente)
        {
            //variable para almacenar mensaje en caso de error
            string message = string.Empty;

            //primer validacion - verificar campos vacios;
            if (string.IsNullOrEmpty(cliente.Apellidos))
            {
                message = "El campo Apellido esta vacio, favor de completarlo";
            }
            else
            {
                if (string.IsNullOrEmpty(cliente.Nombre))
                {
                    message = "El campo Nombre esta vacio, favor de completarlo";
                }
                else
                {
                    //Definir la fecha de enrolamiento de manera automatica
                    cliente.FechaNacimiento = DateTime.Now;

                    //puente entre la capa de negocio y de acceso a datos
                    message = DataAccessLayer.ClienteDAL.updateCliente(cliente);
                }
            }

            //regresa el mensaje con o sin errores
            return message;
        }

        public static string removeCliente(int ID)
        {
            if (ID > 0)
            {
                return DataAccessLayer.ClienteDAL.removeCliente(ID);
            }
            else
            {
                return "Error";
            }
        }


    }
}

