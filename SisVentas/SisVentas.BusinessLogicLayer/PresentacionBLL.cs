using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisVentas.BusinessLogicLayer
{
    public class PresentacionBLL
    {
        public static List<Presentacion> getPresentacionByName(string name)
        {
            //Lista para almacenar el objeto a buscar
            List<Presentacion> presentacions = new List<Presentacion>();
            presentacions = DataAccessLayer.PresentacionDAL.getPresentacionByName(name);

            return presentacions;

        }

        public static List<Presentacion> getAllPresentacion()
        {
            //Lista para almacenar el objeto a buscar
            List<Presentacion> presentacions = new List<Presentacion>();

            //Puente entre el DataAccessLayer y el BussinesLogicLayer
            presentacions = DataAccessLayer.PresentacionDAL.getAllPresentacion();

            return presentacions;
        }

        //metodo para insertar categorias
        public static string insertPresentacion(Presentacion presentacion)
        {
            //Variable para almacenar el mensaje de error en caso de que ocurra alguno
            string message = string.Empty;

            //primera validacion - Verificar los campos vacios
            if (string.IsNullOrEmpty(presentacion.nombre))
            {
                message = "El campo Nombre esta vacio, favor de completarlo";
            }
            else
            {
                if (string.IsNullOrEmpty(presentacion.descripcion))
                {
                    message = "El campo Descripcion esta vacio, favor de completarlo";
                }
                else
                {
                    //Este es el puent entre la capa dde negocios y el acceso a datos
                    message = DataAccessLayer.PresentacionDAL.insertPresentacion(presentacion);

                }
            }

            //regresa el mensaje con o sin errores
            return message;

        }

        public static string removePresentacion(string name)
        {
            string message = string.Empty;

            if (!(name.Equals("")))
            {
                return DataAccessLayer.PresentacionDAL.removePresentacion(name);
                
            }
            else
            {
                return message;
            }
        }

        public static string updatePresentacion(Presentacion presentacion)
        {
            //variable para almacenar el mensaje de error en caso de que ocurra alguno
            string message = string.Empty;
            if (string.IsNullOrEmpty(presentacion.nombre))
            {
                message = "El campo nombre esta vacio, favor de completarlo";
            }
            else
            {
                if (string.IsNullOrEmpty(presentacion.descripcion))
                {
                    message = "El descripcion Nombre está vacio, favor de completarlo";
                }
                else
                {
                    //Este es el puente entre la Capa de Negocios y el acceso a datos
                    message = DataAccessLayer.PresentacionDAL.updatePresentacion(presentacion);
                }
            }
            return message;
        }
    }
}
