using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//agregados
using SisVentas.BusinessEntities;
using SisVentas.DataAccessLayer;

namespace SisVentas.BusinessLogicLayer
{
    class TrabajadorBLL
    {
        public static string insertTrabajador(Trabajador trabajador)
        {
            //variable para almacenar mensaje en caso de error
            string message = string.Empty;

            //primer validacion - verificar campos vacios;
            if (string.IsNullOrEmpty(trabajador.Nombre))
            {
                message = "El campo NOMBRE esta vacio, favor de completarlo";
            }
            else
            {
                if (string.IsNullOrEmpty(trabajador.Apellidos))
                {
                    message = "El campo APELLIDOS esta vacio, favor de completarlo";
                }
                else
                {
                    if (string.IsNullOrEmpty(trabajador.NumDocumento))
                    {
                        message = "El campo NUMERO DE DOCUMENTO (DNI) esta vacio, favor de completarlo";
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(trabajador.Usuario))
                        {
                            message = "El campo USUARIO esta vacio, favor de completarlo";
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(trabajador.Contraseña))
                            {
                                message = "El campo CONTRASEÑA esta vacio, favor de completarlo";
                            }
                            else
                            {
                                //puente
                                message = SisVentas.DataAccessLayer.TrabajadorDAL.insertTrabajador(trabajador);
                            }
                        }
                    }
                }
            }

            //regresa el mensaje con o sin errores
            return message;
        }

        public static List<Trabajador> getAllTrabajadores()
        {
            List<Trabajador> trabajadores = new List<Trabajador>();

            //es el puente entre el dal y el bll
            trabajadores = DataAccessLayer.TrabajadorDAL.getAllTrabajadores();

            return trabajadores;
        }

        public static List<Trabajador> getTrabajadorByNumDocumento(string trabajadorNumDocumento)
        {
            //lista para almacenar el objeto a buscar
            List<Trabajador> trabajadores = new List<Trabajador>();

            //puente entre DAL y BLL
            trabajadores = DataAccessLayer.TrabajadorDAL.getTrabajadorByNumDocumento(trabajadorNumDocumento);

            return trabajadores;
        }

        public static string updateTrabajador(Trabajador trabajador)
        {
            //variable para almacenar mensaje en caso de error
            string message = string.Empty;

            //primer validacion - verificar campos vacios;
            if (string.IsNullOrEmpty(trabajador.Nombre))
            {
                message = "El campo NOMBRE esta vacio, favor de completarlo";
            }
            else
            {
                if (string.IsNullOrEmpty(trabajador.Apellidos))
                {
                    message = "El campo APELLIDOS esta vacio, favor de completarlo";
                }
                else
                {
                    if (string.IsNullOrEmpty(trabajador.NumDocumento))
                    {
                        message = "El campo NUMERO DE DOCUMENTO (DNI) esta vacio, favor de completarlo";
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(trabajador.Usuario))
                        {
                            message = "El campo USUARIO esta vacio, favor de completarlo";
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(trabajador.Contraseña))
                            {
                                message = "El campo CONTRASEÑA esta vacio, favor de completarlo";
                            }
                            else
                            {
                                //puente
                                message = SisVentas.DataAccessLayer.TrabajadorDAL.updateTrabajador(trabajador);
                            }
                        }
                    }
                }
            }

            //regresa el mensaje con o sin errores
            return message;
        }

        public static string deleteTrabajador(int trabajadorID)
        {
            if (trabajadorID > 0)
            {
                return DataAccessLayer.TrabajadorDAL.deleteTrabajador(trabajadorID);
            }
            else
            {
                return "Error";
            }
        }
    }
}
