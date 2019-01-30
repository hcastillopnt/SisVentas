using SistemasVentas.BussinesLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SistemasVentas.BussinesLogicLayer
{
     public class VentasBILL
    {
        public static List<Venta> getVentasByFilter(string Filter, string bandera)
        {
            //Lista para almacenar el objeto a buscar
            List<Venta> ventas = new List<Venta>();

         
            return ventas;

        }
        public static List<Venta> getVentaByID(int VentasId)
        {
            //Lista para almacenar el objeto a buscar
            List<Venta> ventas
                = new List<Venta>();

            //Puente entre el DataAccessLayer y el BussinesLogicLayer
            ventas = DataAccessLayer.VentasDAL.getVentaByID(VentasId);

            return ventas;


        }
        public static List<Venta> getAllVentas()
        {
            //Lista para almacenar el objeto a buscar
            List<Venta> ventas = new List<Venta>();

            //Puente entre el DataAccessLayer y el BussinesLogicLayer
            ventas = DataAccessLayer.VentasDAL.getAllVentas();

            return ventas;
        }
        // Se tiene que buscar por fecha 
        /* //metodo para obtener los estudiantes por medio del apellido
         public static List<Venta> getStudentsByLastName(string lastname)
         {
             List<Student> students = new List<Student>();
             //SELECT * FROM STUDENT WHERE  LastName= '____'
             students = DataAccessLayer.StudentDAL.getStudentsByLastName(lastname);
             return students;
         }*/

        //metodo para insertar los estudiantes
        public static string insertVentas(Venta entity)
        {
            //Variable para almacenar el mensaje de error en caso de que ocurra alguno
            string message = string.Empty;

            //primera validacion - Verificar los campos vacios
            if (string.IsNullOrEmpty(entity.TipoComporbante))
            {


                message = "El campo tipo esta vacio, favor de completarlo";

            }

            else {  
        
            
               
                


                    //Este es el puent entre la capa dde negocios y el acceso a datos
                    message = DataAccessLayer.VentasDAL.insertVentas(entity);

                
            }

            //regresa el mensaje con o sin errores
            return message;
        }
        public static string updateVentas(Venta entity)
        {
            //Variable para almacenar el mensaje de error en caso de que ocurra alguno
            string message = string.Empty;

            //primera validacion - Verificar los campos vacios
            if (string.IsNullOrEmpty(entity.Serie))
            {
                message = "El campo serie esta vacio, favor de completarlo";
            }
            else
            {
                if (string.IsNullOrEmpty(entity.Correlativo))
                {
                    message = "El campo correlativo esta vacio, favor de completarlo";
                }
                else
                {


                    //Este es el puent entre la capa dde negocios y el acceso a datos
                    message = DataAccessLayer.VentasDAL.updateVenta
                        (entity);


                }
            }


            //regresa el mensaje con o sin errores
            return message;
        }
        public static string removeVenta(int VentaId)
        {
            //Variable para almacenar el mensaje de error en caso de que ocurra alguno
            string message = string.Empty;

            if (VentaId
                > 0)
            {

                return DataAccessLayer.VentasDAL.removeVenta (VentaId);

            }
            else
            {
                return "Error";
            }

        }
    }
}

        

