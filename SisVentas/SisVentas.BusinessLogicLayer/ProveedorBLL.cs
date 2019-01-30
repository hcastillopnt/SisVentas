using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisVentas.BusinessEntities;

namespace SisVentas.BusinessLogicLayer
{
    public class ProveedorBLL
    {
        public static List<Proveedor> getProveedorByFilter(string Filter, string bandera)
        {
            List<Proveedor> proveedores = new List<Proveedor>();

            switch (bandera)
            {
                case "NumDocumento":
                    proveedores = DataAccessLayer.ProveedorDAL.getProveedorByNumDocumento(Filter);
                    break;

                case "RazonSocial":
                    proveedores = DataAccessLayer.ProveedorDAL.getProveedorByRazonSocial(Filter);
                    break;       
            }
            return proveedores;
        }

        //Buscar por ID
        public static List<Proveedor> getProveedorByID(int ProveedorID)
        {
            //Lista para almacenar el objeto a buscar
            List<Proveedor> proveedores = new List<Proveedor>();
            //Crear el puente entre el DAL y la capa de Negocios(BLL)
            proveedores = DataAccessLayer.ProveedorDAL.getProveedorByID(ProveedorID);
            return proveedores;
        }

        //Todos los registros
        public static List<Proveedor> getAllProveedores()
        {
            List<Proveedor> proveedores = new List<Proveedor>();

            //SELECT * FROM Students //puente entre el dataAccessLayer y el BusinessLogicLayer
            proveedores = DataAccessLayer.ProveedorDAL.getAllProveedores();

            return proveedores;
        }

        //Método para traer un registro especifico
        public static List<Proveedor> getStudentByNumDocumento(string numDocumento)
        {
            List<Proveedor> proveedores = new List<Proveedor>();
            
            proveedores = DataAccessLayer.ProveedorDAL.getProveedorByNumDocumento(numDocumento);

            return proveedores;

        }

        public static List<Proveedor> getProveedorByRazonSocial(string razonSocial)
        {
            List<Proveedor> proveedores = new List<Proveedor>();
            
            proveedores = DataAccessLayer.ProveedorDAL.getProveedorByRazonSocial(razonSocial);

            return proveedores;

        }



        //Metodo para insertar en la tabla
        public static string insertProveedor(Proveedor entity)
        {
            // Variable para almacenar el mensaje de error en caso de que ocurra alguno
            string message = string.Empty;

            //Primera validación - Verificar los campos vacíos
            if (string.IsNullOrEmpty(entity.NumDocumento))
            {
                message = "El campo Numero de Documento está vacío, favor de llenarlo";
            }
            else
            {
                    if (string.IsNullOrEmpty(entity.RazonSocial))
                    {
                        message = "El campo Razón Social está vacío, favor de llenarlo";
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(entity.Direccion))
                        {
                            message = "El campo Dirección está vacío, favor de llenarlo";

                        }
                        else
                        {
                            if (string.IsNullOrEmpty(entity.Telefono))
                            {
                                message = "El campo Teléfono está vacío, favor de llenarlo";

                            }
                            else
                            {
                                if (string.IsNullOrEmpty(entity.Email))
                                {
                                    message = "El campo E-Mail está vacío, favor de llenarlo";

                                }
                                else
                                {
                                    if (string.IsNullOrEmpty(entity.URL))
                                    {
                                        message = "El campo URL está vacío, favor de llenarlo";

                                    }
                                    else
                                    {
                                    if (string.IsNullOrEmpty(entity.TipoDocumento))
                                    {
                                        message = "El campo tipo documento está vacío, favor de llenarlo";

                                    }
                                    else
                                    {
                                        if (string.IsNullOrEmpty(entity.SectorComercial))
                                        {
                                            message = "El campo sectorComercial está vacío, favor de llenarlo";

                                        }
                                        else
                                        {
                                            //Este es el puete entre la capa de negocios y el acceso de datos
                                            message = DataAccessLayer.ProveedorDAL.insertProveedor(entity);

                                        }


                                    }
                                }
                                }
                            }
                        }
                    }
            }
            //Regresa el mensaje con o sin erores 
            return message;
        }
        public static string updateProveedor(Proveedor entity)
        {
            // Variable para almacenar el mensaje de error en caso de que ocurra alguno
            string message = string.Empty;

            //Primera validación - Verificar los campos vacíos
            if (string.IsNullOrEmpty(entity.NumDocumento))
            {
                message = "El campo Numero de Documento está vacío, favor de llenarlo";
            }
            else
            {
                    if (string.IsNullOrEmpty(entity.RazonSocial))
                    {
                        message = "El campo Razón Social está vacío, favor de llenarlo";
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(entity.Direccion))
                        {
                            message = "El campo Dirección está vacío, favor de llenarlo";

                        }
                        else
                        {
                            if (string.IsNullOrEmpty(entity.Telefono))
                            {
                                message = "El campo Teléfono está vacío, favor de llenarlo";

                            }
                            else
                            {
                                if (string.IsNullOrEmpty(entity.Email))
                                {
                                    message = "El campo E-Mail está vacío, favor de llenarlo";

                                }
                                else
                                {
                                    if (string.IsNullOrEmpty(entity.URL))
                                    {
                                        message = "El campo URL está vacío, favor de llenarlo";

                                    }
                                    else
                                    {

                                        //Este es el puete entre la capa de negocios y el acceso de datos
                                        message = DataAccessLayer.ProveedorDAL.updateProveedor(entity);
                                    }
                                }
                            }
                        }
                    }
            }
            //Regresa el mensaje con o sin erores 
            return message;
        }
        public static string removeProveedor(int ProveedorID)
        {
            if (ProveedorID > 0)
            {
                return DataAccessLayer.ProveedorDAL.removeProveedor(ProveedorID);
            }
            else
            {
                return "Error";
            }
        }
    }
}

