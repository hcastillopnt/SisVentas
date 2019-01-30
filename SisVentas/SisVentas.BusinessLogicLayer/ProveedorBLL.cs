using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisVentas.BusinessLogicLayer
{
    public class ProveedorBLL
    {
        public static List<Proveedor> getProveedorByFilter(string Filter, string bandera)
        {
            //Lista para almacenar el objeto a buscar
            List<Proveedor> proveedors = new List<Proveedor>();

            switch (bandera)
            {
                case "Documento":
                    proveedors = DataAccessLayer.ProveedorDAL.getProveedorByDocument(Filter);
                    break;
                case "RazonSocial":
                    proveedors = DataAccessLayer.ProveedorDAL.getProveedorByRazonSocial(Filter);
                    break;
            }
            return proveedors;

        }

        public static List<Proveedor> getAllProveedor()
        {
            //Lista para almacenar el objeto a buscar
            List<Proveedor> proveedors = new List<Proveedor>();

            //Puente entre el DataAccessLayer y el BussinesLogicLayer
            proveedors = DataAccessLayer.ProveedorDAL.getAllProveedor();

            return proveedors;
        }

        //metodo para insertar trabajadores
        public static string insertProveedor(Proveedor proveedor)
        {
            //Variable para almacenar el mensaje de error en caso de que ocurra alguno
            string message = string.Empty;

            //primera validacion - Verificar los campos vacios
            if (string.IsNullOrEmpty(proveedor.razon_Social))
            {
                message = "El campo razon social esta vacio, favor de completarlo";
            }
            else
            {
                if (string.IsNullOrEmpty(proveedor.sector_Comercial))
                {
                    message = "El sector social está vacio, favor de completarlo";
                }
                else
                {
                    if (string.IsNullOrEmpty(proveedor.num_Documento))
                    {
                        message = "El numero de documento está vacio, favor de completarlo";
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(proveedor.direccion))
                        {
                            message = "La direccion está vacia, favor de completarla";
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(proveedor.telefono))
                            {
                                message = "El teléfono está vacio, favor de completarla";
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(proveedor.email))
                                {
                                    message = "El email está vacio, favor de completarlo";
                                }
                                else
                                {
                                    if (string.IsNullOrEmpty(proveedor.url))
                                    {
                                        message = "El url está vacio, favor de completarlo";
                                    }
                                    else
                                    {
                                        //Este es el puente entre la Capa de Negocios y el acceso a datos
                                        message = DataAccessLayer.ProveedorDAL.insertProveedor(proveedor);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            //regresa el mensaje con o sin errores
            return message;

        }

        public static string removeProveedor(string razon)
        {
            string message = string.Empty;

            if (!(razon.Equals("")))
            {
                return DataAccessLayer.ProveedorDAL.removeProveedor(razon);

            }
            else
            {
                return message;
            }
        }

        public static string updateProveedor(Proveedor proveedor)
        {
            //variable para almacenar el mensaje de error en caso de que ocurra alguno
            string message = string.Empty;
            if (string.IsNullOrEmpty(proveedor.razon_Social))
            {
                message = "El campo razon social esta vacio, favor de completarlo";
            }
            else
            {
                if (string.IsNullOrEmpty(proveedor.sector_Comercial))
                {
                    message = "El sector comercial está vacio, favor de completarlo";
                }
                else
                {
                    if (string.IsNullOrEmpty(proveedor.num_Documento))
                    {
                        message = "El DNI está vacio, favor de completarlo";
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(proveedor.direccion))
                        {
                            message = "La direccion está vacia, favor de completarla";
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(proveedor.telefono))
                            {
                                message = "El teléfono está vacio, favor de completarla";
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(proveedor.email))
                                {
                                    message = "El email está vacio, favor de completarlo";
                                }
                                else
                                {
                                    if(string.IsNullOrEmpty(proveedor.url))
                                    {
                                        message = "El url está vacio, favor de completarlo";
                                    }
                                    else{
                                        //Este es el puente entre la Capa de Negocios y el acceso a datos
                                        message = DataAccessLayer.ProveedorDAL.updateProveedor(proveedor);
                                    }
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
