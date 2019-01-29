using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemasVentas;

namespace SistemasVentas.BussinesLogicLayer
{
   public class TrabajadorBLL
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
                    trabajadors =SistemasVentas.DataAccessLayer.TrabajadorDAL.getTrabajadorByLastName(Filter);
                    break;
                case "TrbajadorId":
                    int TrabajadorID = Convert.ToInt32(Filter);
                    trabajadors = SistemasVentas.DataAccessLayer.TrabajadorDAL.getTrabajadorByID(TrabajadorID);
                    break;

            }
            return trabajadors;

        }

        public static List<Trabajador> getTrabajadorByID(int TrabajadorID)
        {
            //Lista para almacenar el objeto a buscar
            List<Trabajador> trabajadors = new List<Trabajador>();

            //Puente entre el DataAccessLayer y el BussinesLogicLayer
            trabajadors = SistemasVentas.DataAccessLayer.TrabajadorDAL.getTrabajadorByID(TrabajadorID);

            return trabajadors;


        }

        public static List<Trabajador> getAllTrabajador()
        {
            //Lista para almacenar el objeto a buscar
            List<Trabajador> trabajadors = new List<Trabajador>();

            //Puente entre el DataAccessLayer y el BussinesLogicLayer
            trabajadors = SistemasVentas.DataAccessLayer.TrabajadorDAL.getAllTrabajador();

            return trabajadors;
        }


        //metodo para obtener los estudiantes por medio del apellido
        public static List<Trabajador> getTrabajadorByLastName(string apellidos)
        {
            List<Trabajador> trabajadors= new List<Trabajador>();
            //SELECT * FROM STUDENT WHERE  LastName= '____'
            trabajadors = SistemasVentas.DataAccessLayer.TrabajadorDAL.getTrabajadorByLastName(apellidos);
            return trabajadors;
        }

        //chuy

        //metodo para insertar los estudiantes
    /*    public static string insertTrabajador(Trabajador entity)
        {
            //Variable para almacenar el mensaje de error en caso de que ocurra alguno
            string message = string.Empty;

            //primera validacion - Verificar los campos vacios
            if (string.IsNullOrEmpty(entity.Acceso))
            {
                message = "El campo Acceso esta vacio, favor de completarlo";
            }
            else
            {
                if (string.IsNullOrEmpty(entity.Apellidos))
                {
                    message = "El campo Apellidos esta vacio, favor de completarlo";
                }
                else
                {
                    if (string.IsNullOrEmpty(entity.Direccion))
                    {
                        message = "El campo Direccion esta vacio, favor de completarlo";
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(entity.Email))
                        {
                            message = "El campo Email esta vacio, favor de completarlo";
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(entity.Nombre))
                            {
                                message = "El campo Nombre esta vacio, favor de completarlo";
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(entity.NumeroDocumento))
                                {
                                    message = "El campo Numero de Documento esta vacio, favor de completarlo";
                                }
                                else
                                {
                                    if (string.IsNullOrEmpty(entity.Password))
                                    {
                                        message = "El campo Password esta vacio, favor de completarlo";
                                    }
                                    else
                                    {
                                        if (string.IsNullOrEmpty(entity.Sexo))
                                        {
                                            message = "El campo Nombre esta vacio, favor de completarlo";
                                        }
                                        else
                                        {
                                            if (string.IsNullOrEmpty(entity.Telefono))
                                            {
                                                message = "El campo Nombre esta vacio, favor de completarlo";
                                            }
                                            else
                                            {
                                                if (string.IsNullOrEmpty(entity.Usuario))
                                                {
                                                    message = "El campo Nombre esta vacio, favor de completarlo";
                                                }
















                                                else
                {
                    //Definir la fecha de enrolamiento de manera automatica
                    entity.EnrollementDate = DateTime.Now;

                    //Este es el puent entre la capa dde negocios y el acceso a datos
                    message = DataAccessLayer.StudentDAL.insertStudent(entity);

                }
            }


            //regresa el mensaje con o sin errores
            return message;

        }

        public static string updateStudent(Student entity)
        {
            //Variable para almacenar el mensaje de error en caso de que ocurra alguno
            string message = string.Empty;

            //primera validacion - Verificar los campos vacios
            if (string.IsNullOrEmpty(entity.LastName))
            {
                message = "El campo Apellido esta vacio, favor de completarlo";
            }
            else
            {
                if (string.IsNullOrEmpty(entity.FirstMideName))
                {
                    message = "El campo Nombre esta vacio, favor de completarlo";
                }
                else
                {
                    //Definir la fecha de enrolamiento de manera automatica
                    entity.EnrollementDate = DateTime.Now;

                    //Este es el puent entre la capa dde negocios y el acceso a datos
                    message = DataAccessLayer.StudentDAL.updateStudent
(entity);

                }
            }


            //regresa el mensaje con o sin errores
            return message;
        }

        public static string removeStudent(int StudentID)
        {
            //Variable para almacenar el mensaje de error en caso de que ocurra alguno
            string message = string.Empty;

            if (StudentID > 0)
            {

                return DataAccessLayer.StudentDAL.removeStudent(StudentID);

            }
            else
            {
                return "Error";
            }

        }*/
    }
}
