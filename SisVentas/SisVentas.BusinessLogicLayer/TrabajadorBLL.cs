using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


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

            ICollection<ValidationResult> results = null;
            if(!Validate(trabajador,out results))
            {
                message = String.Join("\n ", results.Select(o => o.ErrorMessage));

            }
            else
            {
                try
                {
                    string isInserted = DataAccessLayer.TrabajadorDAL.insertTrabajador(trabajador);
                    if (string.IsNullOrEmpty(isInserted))
                    {
                        isInserted = "The employee has been registed with success";
                    }
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                }
            }

            //regresa el mensaje con o sin errores
            return message;

        }
        private static bool Validate<T>(T obj, out ICollection<ValidationResult> results)
        {
            results = new List<ValidationResult>();
            return Validator.TryValidateObject(obj, new ValidationContext(obj), results, true);
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
                    message = "El descripcion Nombre está vacio, favor de completarlo";
                }
                else
                {
                    //Este es el puente entre la Capa de Negocios y el acceso a datos
                    message = DataAccessLayer.TrabajadorDAL.updateTrabajador(trabajador);
                }
            }
            return message;
        }
    }
}
