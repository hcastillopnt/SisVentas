using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisVentas.BusinessLogicLayer
{
    public class ClienteBLL
    {
        public static List<Cliente> getClienteByFilter(string Filter, string bandera)
        {
            //Lista para almacenar el objeto a buscar
            List<Cliente> clientes = new List<Cliente>();

            switch (bandera)
            {
                case "documento":
                    clientes = DataAccessLayer.ClienteDAL.getClienteByDocument(Filter);
                    break;
                case "apellido":
                     clientes = DataAccessLayer.ClienteDAL.getClienteByLastName(Filter);
                    break;
            }
            return clientes;

        }

        public static List<Cliente> getAllClientes()
        {
            //Lista para almacenar el objeto a buscar
            List<Cliente> clientes = new List<Cliente>();

            //Puente entre el DataAccessLayer y el BussinesLogicLayer
            clientes = DataAccessLayer.ClienteDAL.getAllCliente();

            return clientes;
        }

        //metodo para insertar trabajadores
        public static string insertCliente(Cliente cliente)
        {
            //Variable para almacenar el mensaje de error en caso de que ocurra alguno
            string message = string.Empty;

            //primera validacion - Verificar los campos vacios
            if (string.IsNullOrEmpty(cliente.nombre))
            {
                message = "El campo nombre esta vacio, favor de completarlo";
            }
            else
            {
                if (string.IsNullOrEmpty(cliente.apellido))
                {
                    message = "El apellido Nombre está vacio, favor de completarlo";
                }
                else
                {
                    if (string.IsNullOrEmpty(cliente.num_documento))
                    {
                        message = "El DNI está vacio, favor de completarlo";
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(cliente.direccion))
                        {
                            message = "La direccion está vacia, favor de completarla";
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(cliente.telefono))
                            {
                                message = "El teléfono está vacio, favor de completarla";
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(cliente.email))
                                {
                                    message = "El email está vacio, favor de completarlo";
                                }
                                else
                                {                                            
                                    //Este es el puente entre la Capa de Negocios y el acceso a datos
                                            message = DataAccessLayer.ClienteDAL.insertCliente(cliente);
                                }
                            }
                        }
                    }
                }
            }

            //regresa el mensaje con o sin errores
            return message;

        }

        public static string removeCliente(int id)
        {
            string message = string.Empty;

            if (id > 0)
            {
                return DataAccessLayer.ClienteDAL.removeCliente(id);
            }
            else
            {
                return message;
            }
        }

        public static string updateCliente(Cliente cliente)
        {
            //variable para almacenar el mensaje de error en caso de que ocurra alguno
            string message = string.Empty;
            if (string.IsNullOrEmpty(cliente.nombre))
            {
                message = "El campo nombre esta vacio, favor de completarlo";
            }
            else
            {
                if (string.IsNullOrEmpty(cliente.apellido))
                {
                    message = "El apellido Nombre está vacio, favor de completarlo";
                }
                else
                {
                    if (string.IsNullOrEmpty(cliente.num_documento))
                    {
                        message = "El DNI está vacio, favor de completarlo";
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(cliente.direccion))
                        {
                            message = "La direccion está vacia, favor de completarla";
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(cliente.telefono))
                            {
                                message = "El teléfono está vacio, favor de completarla";
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(cliente.email))
                                {
                                    message = "El email está vacio, favor de completarlo";
                                }
                                else
                                {
                                    
                                                //Este es el puente entre la Capa de Negocios y el acceso a datos
                                                message = DataAccessLayer.ClienteDAL.updateCliente(cliente);
                                         
                                }
                            }
                        }
                    }
                }
            }
            return message;
        }
    }
}
