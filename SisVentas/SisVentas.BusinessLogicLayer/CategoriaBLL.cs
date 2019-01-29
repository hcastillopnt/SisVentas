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
        public static List<Categoria> getCategoriaByFilter(string Filter, string bandera)
        {
            //Lista para almacenar el objeto a buscar
            List<Categoria> categorias = new List<Categoria>();

            switch (bandera)
            {
                case "nombre":
                    break;
                case "descripcion":
                    categorias = DataAccessLayer.CategoriaDAL.getCategoriaByName(Filter);
                    break;
                

            }
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
        public static string insertCategoria(Categoria entity)
        {
            //Variable para almacenar el mensaje de error en caso de que ocurra alguno
            string message = string.Empty;

            //primera validacion - Verificar los campos vacios
            if (string.IsNullOrEmpty(entity.nombre))
            {
                message = "El campo Nombre esta vacio, favor de completarlo";
            }
            else
            {
                if (string.IsNullOrEmpty(entity.descripcion))
                {
                    message = "El campo Descripcion esta vacio, favor de completarlo";
                }
                else
                {
                  

                    //Este es el puent entre la capa dde negocios y el acceso a datos
                    message = DataAccessLayer.CategoriaDAL.insertCategoria(entity);

                }
            }


            //regresa el mensaje con o sin errores
            return message;

        }
        public static string removeCategoria(int id)
        {
            if (id > 0)
            {
                return DataAccessLayer.CategoriaDAL.removeCategoria(id);
            }
            else
            {
                return "Error";
            }
        }
    }
}
