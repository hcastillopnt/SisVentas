using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace SisVentas.BusinessLogicLayer
{
    public class TrabajadorBLL
    {
        public static List<Trabajador> getTrabajadorByFilter(string Filter, string bandera)
        {
            //Lista para almacenar el objeto a buscar
            List<Trabajador> trabajador = new List<Trabajador>();

            switch (bandera)
            {
                case "documento":
                    trabajador = DataAccessLayer.TrabajadorDAL.getTrabajadorByDocument(Filter);
                    break;
                case "apellido":
                    trabajador = DataAccessLayer.TrabajadorDAL.getTrabajadorByLastName(Filter);
                    break;
            }
            return trabajador;

        }

        public static List<Trabajador> getAllTrabajador()
        {
            //Lista para almacenar el objeto a buscar
            List<Trabajador> trabajadors = new List<Trabajador>();

            //Puente entre el DataAccessLayer y el BussinesLogicLayer
            trabajadors = DataAccessLayer.TrabajadorDAL.getAllTrabajador();

            return trabajadors;
        }

        //metodo para insertar trabajadores
        public static string insertTrabajador(Trabajador trabajador)
        {
            //Variable para almacenar el mensaje de error en caso de que ocurra alguno
            string message = string.Empty;

            //primera validacion - Verificar los campos vacios
            if (string.IsNullOrEmpty(trabajador.nombre))
            {
                message = "El campo nombre esta vacio, favor de completarlo";
            }
            else
            {
                if (string.IsNullOrEmpty(trabajador.apellido))
                {
                    message = "El apellido Nombre está vacio, favor de completarlo";
                }
                else
                {
                    if (string.IsNullOrEmpty(trabajador.num_documento))
                    {
                        message = "El DNI está vacio, favor de completarlo";
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(trabajador.direccion))
                        {
                            message = "La direccion está vacia, favor de completarla";
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(trabajador.telefono))
                            {
                                message = "El teléfono está vacio, favor de completarla";
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(trabajador.email))
                                {
                                    message = "El email está vacio, favor de completarlo";
                                }
                                else
                                {
                                    
                                        if (string.IsNullOrEmpty(trabajador.usuario))
                                        {
                                            message = "El usuario está vacio, favor de completarlo";
                                        }
                                        else
                                        {
                                            if (string.IsNullOrEmpty(trabajador.password))
                                            {
                                                message = "El password está vacio, favor de completarlo";
                                            }
                                            else
                                            {
                                            //Este es el puente entre la Capa de Negocios y el acceso a datos
                                            message = DataAccessLayer.TrabajadorDAL.insertTrabajador(trabajador);                                          }
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

        public static string removeTrabajador(int id)
        {
            string message = string.Empty;

            if (id > 0)
            {
                return DataAccessLayer.TrabajadorDAL.removeTrabajador(id);
            }
            else
            {
                return message;
            }
        }

        public static string updateTrabajador(Trabajador trabajador)
        {
            //variable para almacenar el mensaje de error en caso de que ocurra alguno
            string message = string.Empty;
            if (string.IsNullOrEmpty(trabajador.nombre))
            {
                message = "El campo nombre esta vacio, favor de completarlo";
            }
            else
            {
                if (string.IsNullOrEmpty(trabajador.apellido))
                {
                    message = "El apellido Nombre está vacio, favor de completarlo";
                }
                else
                {
                    if (string.IsNullOrEmpty(trabajador.num_documento))
                    {
                        message = "El DNI está vacio, favor de completarlo";
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(trabajador.direccion))
                        {
                            message = "La direccion está vacia, favor de completarla";
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(trabajador.telefono))
                            {
                                message = "El teléfono está vacio, favor de completarla";
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(trabajador.email))
                                {
                                    message = "El email está vacio, favor de completarlo";
                                }
                                else
                                {
                                    if (string.IsNullOrEmpty(trabajador.acceso))
                                    {
                                        message = "No se ha escogido";
                                    }
                                    else
                                    {
                                        if (string.IsNullOrEmpty(trabajador.usuario))
                                        {
                                            message = "El usuario está vacio, favor de completarlo";
                                        }
                                        else
                                        {
                                            if (string.IsNullOrEmpty(trabajador.password))
                                            {
                                                message = "El password está vacio, favor de completarlo";
                                            }
                                            else
                                            {
                                                //Este es el puente entre la Capa de Negocios y el acceso a datos
                                                message = DataAccessLayer.TrabajadorDAL.updateTrabajador(trabajador);
                                            }
                                        }
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
