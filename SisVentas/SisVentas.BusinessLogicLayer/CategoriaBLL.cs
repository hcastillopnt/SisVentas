using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace SisVentas.BusinessLogicLayer
{
    public class CategoriaBLL
    {
        public static List<Categoria> getCategoriaByName(string name)
        {
            //Lista para almacenar el objeto a buscar
            List<Categoria> categorias = new List<Categoria>();
            categorias = DataAccessLayer.CategoriaDAL.getCategoriaByName(name);
                    
            return categorias;

        }

        public static List<Categoria> getAllCategoria()
        {
            //Lista para almacenar el objeto a buscar
            List<Categoria> categorias = new List<Categoria>();

            //Puente entre el DataAccessLayer y el BussinesLogicLayer
            categorias = DataAccessLayer.CategoriaDAL.getAllCategoria();

            return categorias;
        }
        
                //metodo para insertar categorias
        public static string insertCategoria(Categoria categoria)
        {
            //Variable para almacenar el mensaje de error en caso de que ocurra alguno
            string message = string.Empty;

            //primera validacion - Verificar los campos vacios
            if (string.IsNullOrEmpty(categoria.nombre))
            {
                message = "El campo Nombre esta vacio, favor de completarlo";
            }
            else
            {
                if (string.IsNullOrEmpty(categoria.descripcion))
                {
                    message = "El campo Descripcion esta vacio, favor de completarlo";
                }
                else
                {
                    //Este es el puent entre la capa dde negocios y el acceso a datos
                    message = DataAccessLayer.CategoriaDAL.insertCategoria(categoria);

                }
            }

            //regresa el mensaje con o sin errores
            return message;

        }
        public static string removeCategoria(string name)
        {
            string message = string.Empty;

            if (!(name.Equals("")))
            {
                return DataAccessLayer.CategoriaDAL.removeCategoria(name);

            }
            else
            {
                return message;
            }
        }

        public static string updateCategoria(Categoria categoria)
        {
            //variable para almacenar el mensaje de error en caso de que ocurra alguno
            string message = string.Empty;
            if (string.IsNullOrEmpty(categoria.nombre))
            {
                message = "El campo nombre esta vacio, favor de completarlo";
            }
            else
            {
                if (string.IsNullOrEmpty(categoria.descripcion))
                {
                    message = "El descripcion Nombre está vacio, favor de completarlo";
                }
                else
                {
                    //Este es el puente entre la Capa de Negocios y el acceso a datos
                    message = DataAccessLayer.CategoriaDAL.updateCategoria(categoria);
                }
            }
            return message;
        }
    }
}
