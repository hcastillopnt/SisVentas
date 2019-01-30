using SistemasVentas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogicLayer
{
  public  class TrabajadorBLL
    {
        public static List<Trabajador> getTrabajadorByFilter(string Filter, string bandera)
        {
            //Lista para almacenar el objeto a buscar
            List<Trabajador> trabajadors = new List<Trabajador>();

            switch (bandera)
            {
                case "Nombre":
                    break;
                case "Apellido":
                    trabajadors = DataAccessLayer.TrabajadorDAL.getTrabajadorByApellido(Filter);
                    break;
                case "StudentId":
                    int StudentID = Convert.ToInt32(Filter);
                    trabajadors = DataAccessLayer.TrabajadorDAL.getTrabajadorByID(StudentID);
                    break;

            }
            return trabajadors;

        }

        public static List<Trabajador> getTrabajadorByID(int TrabajadorID)
        {
            //Lista para almacenar el objeto a buscar
            List<Trabajador> trabajadors = new List<Trabajador>();

            //Puente entre el DataAccessLayer y el BussinesLogicLayer
           trabajadors = DataAccessLayer.TrabajadorDAL.getTrabajadorByID(TrabajadorID);

            return trabajadors;


        }

        public static List<Trabajador> getAllTrabajador()
        {
            //Lista para almacenar el objeto a buscar
            List<Trabajador> trabajadors = new List<Trabajador>();

            //Puente entre el DataAccessLayer y el BussinesLogicLayer
            trabajadors = DataAccessLayer.TrabajadorDAL.getAllTrabajadores();

            return trabajadors;
        }


        //metodo para obtener los estudiantes por medio del apellido
        public static List<Trabajador> getTrabajadorbyApellido(string apellido)
        {
            List<Trabajador> trabajadors = new List<Trabajador>();
            //SELECT * FROM STUDENT WHERE  LastName= '____'
            trabajadors = DataAccessLayer.TrabajadorDAL.getTrabajadorByApellido(apellido);
            return trabajadors;
        }

        //metodo para insertar los estudiantes
        public static string insertTrabajador(Trabajador objTrabajador)

        {//Variable para almacenar el mensaje de error en caso de que ocurra alguno
            string message = string.Empty;

            ICollection<ValidationResult> result = null;

            if (!validate(objTrabajador, out result))
            {
                message = string.Join("\n", result.Select(o => o.ErrorMessage));
            }
            else
            {
                message = DataAccessLayer.TrabajadorDAL.insertarTrabajador(objTrabajador);
            }


            //regresa el mensaje con o sin errores
            return message;

        }

        public static bool validate<T>(T obj, out ICollection<ValidationResult> results)
        {
            results = new List<ValidationResult>();
            return Validator.TryValidateObject(obj, new ValidationContext(obj), results, true);
        }

            

        public static string updateTrabajador(Trabajador objTrabajador)
        {
            //Variable para almacenar el mensaje de error en caso de que ocurra alguno
            string message = string.Empty;

            ICollection<ValidationResult> result = null;

            if (!validate(objTrabajador, out result))
            {
                message = string.Join("\n", result.Select(o => o.ErrorMessage));
            }
            else
            {
                message = DataAccessLayer.TrabajadorDAL.updateTrabajador(objTrabajador);
            }

            //regresa el mensaje con o sin errores
            return message;
        }

        public static string removeStudent(int TrabajadorID)
        {
            //Variable para almacenar el mensaje de error en caso de que ocurra alguno
            string message = string.Empty;
           
            if( TrabajadorID > 0)
            {

                return DataAccessLayer.TrabajadorDAL.removeTrabajador(TrabajadorID);

            }
            else
            {
                return "Error";
            }

        }

    }
}
