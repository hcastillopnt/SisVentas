using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemasVentas;

namespace SistemasVentas.BussinesLogicLayer
{
    public class ProveedorBLL
    {
        public static List<Proveedor> getProveedorByFilter(string Filter, string bandera)
        {
            //Lista para almacenar el objeto a buscar
            List<Proveedor> Proveedors = new List<Proveedor>();

            switch (bandera)
            {
                case "Nombre":
                    break;
                case "Apellido":
                    Proveedors = SistemasVentas.DataAccessLayer.ProveedorDAL.getProveedorByLastName(Filter);
                    break;
                case "TrbajadorId":
                    int ProveedorID = Convert.ToInt32(Filter);
                    Proveedors = SistemasVentas.DataAccessLayer.ProveedorDAL.getProveedorByID(ProveedorID);
                    break;

            }
            return Proveedors;

        }

        public static List<Proveedor> getProveedorByID(int ProveedorID)
        {
            //Lista para almacenar el objeto a buscar
            List<Proveedor> Proveedors = new List<Proveedor>();

            //Puente entre el DataAccessLayer y el BussinesLogicLayer
            Proveedors = SistemasVentas.DataAccessLayer.ProveedorDAL.getProveedorByID(ProveedorID);

            return Proveedors;


        }

        public static List<Proveedor> getAllProveedor()
        {
            //Lista para almacenar el objeto a buscar
            List<Proveedor> Proveedors = new List<Proveedor>();

            //Puente entre el DataAccessLayer y el BussinesLogicLayer
            Proveedors = SistemasVentas.DataAccessLayer.ProveedorDAL.getAllProveedor();

            return Proveedors;
        }


        //metodo para obtener los estudiantes por medio del apellido
        public static List<Proveedor> getProveedorByLastName(string apellidos)
        {
            List<Proveedor> Proveedors = new List<Proveedor>();
            //SELECT * FROM STUDENT WHERE  LastName= '____'
            Proveedors = SistemasVentas.DataAccessLayer.ProveedorDAL.getProveedorByLastName(apellidos);
            return Proveedors;
        }

        //chuy

        //metodo para insertar los estudiantes
        /*    public static string insertProveedor(Proveedor entity)
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
