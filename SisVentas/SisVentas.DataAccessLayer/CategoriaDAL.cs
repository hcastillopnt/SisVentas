using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisVentas.DataAccessLayer
{
    public class CategoriaDAL
    {
        private static SisVentasDbContext dbCtx = new SisVentasDbContext();

        #region INSERTAR

        public static string insertCategoria(Categoria categoria)
        {
            //variable para almacenar el mensaje de error en caso de que ocurra alguno
            string message = string.Empty;

            //Variable para almacenar si se inserto correctamente el registro
            bool isInserted = false;

            //Se utiliza un espacio de nombres para utilizar las transacciones
            using (var dbCtxTran = dbCtx.Database.BeginTransaction())
            {
                try
                {
                    //se verifica si la base de dstos existe
                    bool isDataBaseExist = Database.Exists(dbCtx.Database.Connection);

                    //Si existe la base de datos se procede a insertar el registro
                    if (isDataBaseExist)
                    {
                        #region Alternativa con ENTITY FRAMEWORK
                        //Se añade la entidad al contexto
                        dbCtx.Categorias.Add(categoria);

                        //se guardan los cambios en el contexto y se verifica si se efectuo de manera correcta
                        isInserted = dbCtx.SaveChanges() > 0;

                        //Si se realizó correctamente la insercion se procede a ejecutar la transaccion
                        if (isInserted)
                        {
                            dbCtxTran.Commit();
                        }
                        #endregion
                    }
                }//fin de try
                catch (DbEntityValidationException ex)
                {
                    var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);
                    var fullErrorMessage = string.Join("; ", errorMessages);
                    var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ",
                        fullErrorMessage);
                    message = exceptionMessage + "\n" + ex.EntityValidationErrors;

                    dbCtxTran.Rollback();
                }//Fin de DbEntityValidationException
                catch (DbUpdateConcurrencyException ex)
                {
                    var entityObj = ex.Entries.Single().GetDatabaseValues();

                    if (entityObj == null)

                        message = "The entity being updated is already deleted by another user";
                    else
                        message = "The entity being updated has already been updated by another user";

                    dbCtxTran.Rollback();
                } // Fin de DbUpdateConcurrencyException

                catch (Exception ex)
                {
                    message = ex.Message;

                    dbCtxTran.Rollback();
                } // fin de Exception
            }// fin transaccion

            //Retorna el mensaje de error, en caso de ocurrir alguno de lo contrario regresa vacio
            return message;
        }
        #endregion

        #region ACTUALIZAR

        public static string updateStudent(Categoria categoria)
        {
            //variable para almacenar el mensaje de error en caso de que ocurra alguno
            string message = string.Empty;

            //Variable para almacenar si se inserto correctamente el registro
            bool isUpdated = false;

            //Se utiliza un espacio de nombres para utilizar las transacciones
            using (var dbCtxTran = dbCtx.Database.BeginTransaction())
            {
                try
                {
                    //se verifica si la base de dstos existe
                    bool isDataBaseExist = Database.Exists(dbCtx.Database.Connection);

                    //Si existe la base de datos se procede a insertar el registro
                    if (isDataBaseExist)
                    {
                        #region Alternativa #1 - Actualizando con Entity Framework
                        //buscamos el objeto a actualizar
                        var entity = dbCtx.Categorias.Find(categoria.id);

                        //Validad que el objeto exsita
                        if (entity != null)
                        {
                            //Damos los valores a modificar
                            entity.nombre = categoria.nombre;
                            entity.descripcion = categoria.descripcion;

                            //Se añade la entidad al contexto
                            dbCtx.Entry(entity).State = EntityState.Modified;

                            //Se guardan los cambios en el contexto y se verifica si se efectuo de manera correcta
                            isUpdated = dbCtx.SaveChanges() > 0;

                            if (isUpdated)
                            {
                                dbCtxTran.Commit();
                            }//Fin de la validacion isUpdated == true
                        }//Fin de la validacion entity != null
                        #endregion
                    }//fin de la validacion de DataBaseExist
                }//fin de try
                catch (DbEntityValidationException ex)
                {
                    var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);
                    var fullErrorMessage = string.Join("; ", errorMessages);
                    var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ",
                        fullErrorMessage);
                    message = exceptionMessage + "\n" + ex.EntityValidationErrors;

                    dbCtxTran.Rollback();
                }//Fin de DbEntityValidationException
                catch (DbUpdateConcurrencyException ex)
                {
                    var entityObj = ex.Entries.Single().GetDatabaseValues();

                    if (entityObj == null)

                        message = "The entity being updated is already deleted by another user";
                    else
                        message = "The entity being updated has already been updated by another user";

                    dbCtxTran.Rollback();
                } // Fin de DbUpdateConcurrencyException

                catch (Exception ex)
                {
                    message = ex.Message;

                    dbCtxTran.Rollback();
                } // fin de Exception
            }// fin transaccion

            //Retorna el mensaje de error, en caso de ocurrir alguno de lo contrario regress vcio
            return message;
        }
        #endregion

        #region ELIMINAR

        public static string removeCategoria(int Id)
        {
            //variable para almacenar el mensaje de error en caso de que ocurra alguno
            string message = string.Empty;

            //Variable para almacenar el status del metodo
            bool isRemoved = false;

            //Se utiliza un espacio de nombres para utilizar las transacciones
            using (var dbCtxTran = dbCtx.Database.BeginTransaction())
            {
                try
                {
                    //se verifica si la base de dstos existe
                    bool isDataBaseExist = Database.Exists(dbCtx.Database.Connection);

                    //Si existe la base de datos se procede a insertar el registro
                    if (isDataBaseExist)
                    {
                        #region Alternativa #1 - Eliminando con Entity Framework
                        //Consultar para obtener el objeto a eliminar
                        //var objStudent = dbCtx.Students.Find(Id);
                        var objCategoria = dbCtx.Categorias.Where(x => x.id == Id).SingleOrDefault();//Puede ser esta también para que elimine

                        //Consulta para eliminar el objeto
                        dbCtx.Categorias.Remove(objCategoria);

                        //Guardar el status del borrado
                        isRemoved = dbCtx.SaveChanges() > 0;

                        //Si se elimino correctamente se hace el commit
                        if (isRemoved)
                        {
                            dbCtxTran.Commit();
                        }
                        #endregion
                    }
                }//fin de try
                catch (DbEntityValidationException ex)
                {
                    var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);
                    var fullErrorMessage = string.Join("; ", errorMessages);
                    var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ",
                        fullErrorMessage);
                    message = exceptionMessage + "\n" + ex.EntityValidationErrors;

                    dbCtxTran.Rollback();
                }//Fin de DbEntityValidationException
                catch (DbUpdateConcurrencyException ex)
                {
                    var entityObj = ex.Entries.Single().GetDatabaseValues();

                    if (entityObj == null)

                        message = "The entity being updated is already deleted by another user";
                    else
                        message = "The entity being updated has already been updated by another user";

                    dbCtxTran.Rollback();
                } // Fin de DbUpdateConcurrencyException

                catch (Exception ex)
                {
                    message = ex.Message;

                    dbCtxTran.Rollback();
                } // fin de Exception
            }// fin transaccion

            //Retorna el mensaje de error, en caso de ocurrir alguno de lo contrario regress vcio
            return message;
        }
        #endregion

        #region BUSCAR

        #region TODOS

        public static List<Categoria> getAllCategoria()
        {
            List<Categoria> categorias = new List<Categoria>();//se crea la instacia de la lista de estudiantes

            //SELECT * FROM Students
            categorias = dbCtx.Categorias.ToList();

            return categorias;//retorna lista de estudiantes
        }

        #endregion

        #region NOMBRE
        public static List<Categoria> getCategoriaByName(string name)
        {
            List<Categoria> categorias = new List<Categoria>();

            //SELECT * FROM .... WHERE firstmidname = '_____'
            categorias = dbCtx.Categorias.Where(x => x.nombre == name).ToList();

            return categorias;
        }

        #endregion


        #endregion
    }
}