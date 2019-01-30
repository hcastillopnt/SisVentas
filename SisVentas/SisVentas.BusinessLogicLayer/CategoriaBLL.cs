using SisVentas.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisVentas.BusinessLogicLayer
{
    public class CategoriaBLL
    {
        public static string insertCategoria(Categoria Categoria)
        {
            //variable para almacenar mensaje en caso de error
            string message = string.Empty;

            //primer validacion - verificar campos vacios;
            if (string.IsNullOrEmpty(Categoria.Nombre))
            {
                message = "El campo Nombre esta vacio, favor de completarlo";
            }
            else
            {
                if (string.IsNullOrEmpty(Categoria.Descripcion))
                {
                    message = "El campo Descripcion esta vacio, favor de completarlo";
                }
                else
                {
                   
                    //puente entre la capa de negocio y de acceso a datos
                    message = DataAccessLayer.CategoriaDAL.insertcategoria(Categoria);
                }
            }

            //regresa el mensaje con o sin errores
            return message;
        }


        public static string removeCategoria(string nombre)
        {
            if (nombre == "")
            {
                return DataAccessLayer.CategoriaDAL.removeCategoria(nombre);
            }
            else
            {
                return "error";
            }
        }


        public static string updateCategoria(Categoria categoria
            )
        {
            //variable para almacenar mensaje en caso de error
            string message = string.Empty;

            //primer validacion - verificar campos vacios;
            if (string.IsNullOrEmpty(categoria.Nombre))
            {
                message = "El campo Nombre esta vacio, favor de completarlo";
            }
            else
            {
                if (string.IsNullOrEmpty(categoria.Descripcion))
                {
                    message = "El campo Descripcion esta vacio, favor de completarlo";
                }
                else
                {
                    

                    //puente entre la capa de negocio y de acceso a datos
                    message = DataAccessLayer.CategoriaDAL.updateCategoria(categoria);
                }
            }

            //regresa el mensaje con o sin errores
            return message;
        }
        public static List<Categoria> getStudentsByLastName(string Nombre)
        {
            List<Categoria> students = new List<Categoria>();

            //select * from students where lastname=´´
            students = DataAccessLayer.CategoriaDAL.getCategoriaByLastName(Nombre);

            return students;
        }
        public static List<Categoria> getCategorias
            ()
        {

            List<Categoria> categorias = new List<Categoria>();

            //puente entre DAL y el BLL
            categorias = DataAccessLayer.CategoriaDAL.getAllCategoria();


            return categorias;
        }
    }
}
