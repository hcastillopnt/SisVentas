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
    public class TrabajadorDAL
    {
        private static SisVentasDbContext dbCtx = new SisVentasDbContext();

        #region INSERTAR

        public static string insertTrabajador(Trabajador trabajador)
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
                        dbCtx.Trabajadors.Add(trabajador);

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

        public static string updateTrabajador(Trabajador trabajador)
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
                        var entity = dbCtx.Trabajadors.Find(trabajador.Id);

                        //Validad que el objeto exsita
                        if (entity != null)
                        {
                            //Damos los valores a modificar
                            entity.nombre = trabajador.nombre;
                            entity.apellido = trabajador.apellido;
                            entity.sexo = trabajador.sexo;
                            entity.fecha_nacimiento = trabajador.fecha_nacimiento;
                            entity.num_documento = trabajador.num_documento;
                            entity.direccion = trabajador.direccion;
                            entity.telefono = trabajador.telefono;
                            entity.acceso = trabajador.acceso;
                            entity.usuario = trabajador.usuario;
                            entity.password = trabajador.password;

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

        public static string removeTrabajador(string apellido)
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
                        var objTrabajador = dbCtx.Trabajadors.Where(x => x.apellido == apellido).SingleOrDefault();//Puede ser esta también para que elimine

                        //Consulta para eliminar el objeto
                        dbCtx.Trabajadors.Remove(objTrabajador);

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

        public static List<Trabajador> getAllTrabajador()
        {
            List<Trabajador> trabajadors = new List<Trabajador>();//se crea la instacia de la lista de estudiantes

            //SELECT * FROM Students
            trabajadors = dbCtx.Trabajadors.ToList();

            return trabajadors;//retorna lista de estudiantes
        }

        #endregion

        #region APELLIDO
        public static List<Trabajador> getTrabajadorByLastName(string lastname)
        {
            List<Trabajador> trabajadors = new List<Trabajador>();

            //SELECT * FROM .... WHERE firstmidname = '_____'
            trabajadors = dbCtx.Trabajadors.Where(x => x.apellido == lastname).ToList();

            return trabajadors;
        }

        #endregion

        public static List<Trabajador> getTrabajadorByDocument(string documento)
        {
            List<Trabajador> trabajadors = new List<Trabajador>();

            //SELECT * FROM .... WHERE firstmidname = '_____'
            trabajadors = dbCtx.Trabajadors.Where(x => x.num_documento== documento).ToList();

            return trabajadors;
        }


        #endregion
    }
}
