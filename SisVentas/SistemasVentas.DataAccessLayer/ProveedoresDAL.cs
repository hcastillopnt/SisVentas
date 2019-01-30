﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProveedorDAL
{
    public class ProveedorDAL
    {
        //se crea una instancia de la clase DbContext para acceder a la DB
        public static SistemaDBContext dbCtx = new SistemaDBContext();


        public static List<Proveedor> getProveedorsByID(int ProveedorID)
        {
            List<Proveedor> Proveedors = new List<Proveedor>();
            //SELECT * FROM Proveedor WHERE  Id= '____'
            Proveedors = dbCtx.Proveedors.Where(x => x.Id == ProveedorID).ToList();

            return Proveedors;
        }

        //Metodo para obtener todos los Proveedores registrados en pocas palabras select * from
        public static List<Proveedor> getAllProveedors()
        {
            List<Proveedor> Proveedors = new List<Proveedor>();

            //SELECT * FROM Proveedors
            Proveedors = dbCtx.Proveedors.ToList();

            return Proveedors;
        }


        //metodo para obtener los Proveedores por medio del apellido
        public static List<Proveedor> getProveedorsByLastName(string lastname)
        {
            List<Proveedor> Proveedors = new List<Proveedor>();
            //SELECT * FROM Proveedor WHERE  LastName= '____'
            Proveedors = dbCtx.Proveedors.Where(x => x.LastName == lastname).ToList();
            return Proveedors;
        }

        public static string insertProveedor(Proveedor entity)
        {
            #region //insertar
            //Variable para almacenar el mensaje de error en caso de que ocurra alguno
            string message = string.Empty;

            //varaible para almacenar si se inserto correctamente el registro
            bool isInserted = false;

            //se utiliza un espacio de nombres para utilizar las transacciones
            using (var dbCtxTran = dbCtx.Database.BeginTransaction())
            {
                try
                {
                    //se verifica si la base de datos existe
                    bool isDatabaseExist = Database.Exists(dbCtx.Database.Connection);

                    //Si existe la base de datos se procede a insertar el registro
                    if (isDatabaseExist)
                    {

                        #region //Alternativa #1 - Funcion para insertar en la base de datos por medio de Entity Framework

                        //se añade la entidad al contexto
                        dbCtx.Proveedors.Add(entity);

                        //Se guardan los cambios en el contexto y se verifica si se efectuo de manera correcta
                        isInserted = dbCtx.SaveChanges() > 0;

                        //Si se realizo correctamente la inserccion se procede a ejecutar la transaccion
                        if (isInserted)
                        {
                            //Se hace commit a la transaccion
                            dbCtxTran.Commit();
                        }
                        #endregion



                        #region //Alternativa #2 - Funcion para insertar en la base de datos por medio ADO.NET con Query Parametrizada

                        ////Se obtiene la cadena de conexon desde el archivo app.config
                        //string connectionString = ConfigurationManager.ConnectionStrings["SistemaDBContext"].ConnectionString;

                        ////Se utiliza un namespace para utilizar el objeto connection, pasando como parametro la cadena de conexion
                        //using (MySqlConnection mySqlConn = new MySqlConnection(connectionString))
                        //{
                        //    //Se construye el query con el que se trabajara
                        //    string QueryToADO_NET = "INSERT INTO Proveedor(LastName, FirstMideName, EnrollementDate)" +
                        //        "VALUES(@lastname, @firstmidename, @enrollementdate);";

                        //    //Se abre la conexion
                        //    mySqlConn.Open();

                        //    //Se utiliza un namespace para utilizar el objeto command, pasando como parametros
                        //    //el query y el objeto connection
                        //    using (MySqlCommand mySqlCmd = new MySqlCommand(QueryToADO_NET, mySqlConn))
                        //    {
                        //        //Se añaden los parametros del query anteriormente creado
                        //        mySqlCmd.Parameters.AddWithValue("@lastname", entity.LastName);
                        //        mySqlCmd.Parameters.AddWithValue("@firstmidename", entity.FirstMideName);
                        //        mySqlCmd.Parameters.AddWithValue("@enrollementdate", entity.EnrollementDate);

                        //        //Se ejecuta el query, y se verifica si se efectuo de manera correcta
                        //        isInserted = mySqlCmd.ExecuteNonQuery() > 0;

                        //        //Se cierra la conexion
                        //        mySqlConn.Close();

                        //        //Si se realizo correctamente la inserccion se procede a ejecutar la transaccion
                        //        if (isInserted)
                        //        {
                        //            //Se hace commit a la transaccion
                        //            dbCtxTran.Commit();
                        //        }

                        //    }
                        //}

                        #endregion

                        #region //Alternativa #3 - Funcion para insertar en la base de datos por medio de Entity Framework

                        ////Se crea el query con que se trabajara
                        //string QueryToEF = "INSERT INTO Proveedor(LastName, FirstMideName, EnrollementDate)" +
                        //        "VALUES(@lastname, @firstmidename, @enrollementdate);";



                        ////Se ejecuta el query parametrizado y se verifica si se efectuo de manera correcta
                        //isInserted = dbCtx.Database.ExecuteSqlCommand(QueryToEF,
                        // new MySqlParameter("@lastname", entity.LastName),
                        // new MySqlParameter("@firstmidename", entity.FirstMideName),
                        // new MySqlParameter("@enrollementdate", entity.EnrollementDate)) > 0;

                        ////Si se realizo correctamente la insercion se procede a ejecutar la transaccion
                        //if (isInserted)
                        //{
                        //    //Se me hace commit a la transaccion
                        //    dbCtxTran.Commit();
                        //}

                        #endregion



                        #region //Alternativa #4 - Funcion para insertar en la base de datos por medio Entity Framework con Stored Procedure

                        ////Se ejecuta el query parametrizado y se verifica si se efectuo de manera correcta
                        //isInserted = dbCtx.Database.ExecuteSqlCommand("procInsertProveedor @lastname, @firstmidename, @enrollementdate",
                        //                new MySqlParameter("@lastname", entity.LastName),
                        //                new MySqlParameter("@firstmidename", entity.FirstMideName),
                        //                new MySqlParameter("@enrollementdate", entity.EnrollementDate)) > 0;

                        ////Si se realizo correctamente la inserccion se procede a ejecutar la transaccion
                        //if (isInserted)
                        //{
                        //    //Se hace commit a la transaccion
                        //    dbCtxTran.Commit();
                        //}

                        #endregion


                        #region //Alternativa #5 - Funcion para insertar en la base de datos por medio de ADO.NET

                        // //Se obtiene la cadena de conexion desde el archivo app.config
                        // //string conectionString=
                        // //ConfigurationManager.ConectionStrings["SistemaDBContext"].ConnectionString;

                        // //Se utiliza un namespace para utilizar el objeto connection, pasando como parametro
                        ////la cadena de conexion
                        //  using(MySqlConnection mySqlConn = new MySqlConnection(connectionString))
                        // {
                        //     //se construye el query con que se trabajara
                        //     //string procedureName = "procInsertProveedor";

                        //     //se abre la conexion
                        //     mySqlConn.Open();

                        //     //se utiliza un namaspace para utilizar el objeto command, pasando como parametros
                        //     //el nombre del procedimiento almacenado y el objeto connection
                        //     using(MySqlCommand mySqlCmd = new MySqlCommand(procedureName, mySqlConn))
                        //     {
                        //         //se añaden los parametros del query anteriormente creado
                        //         mySqlCmd.Parameters.AddWithValue("@lastname", entity.LastName);
                        //         mySqlCmd.Parameters.AddWithValue("@firstmidename", entity.FirstMideName);
                        //         mySqlCmd.Parameters.AddWithValue("@enrollmentdate", entity.EnrollementDate);

                        //         //se ejecuta el query y se verifica si se efectuo de namera correcta
                        //         isInserted = mySqlCmd.ExecuteNonQuery() > 0;

                        //         //se cierra la conexion 
                        //         mySqlConn.Close();

                        //         //si se realizo correctamente la insercion se procede a ejecutar la transaccion
                        //         if (isInserted)
                        //         {
                        //             //se hace commit a la transaccion
                        //             dbCtxTran.Commit();
                        //         }


                        //     }
                        // }


                        #endregion */

                    }

                }
                catch (DbEntityValidationException ex)
                {
                    var errorMessages = ex.EntityValidationErrors
                         .SelectMany(x => x.ValidationErrors)
                         .Select(x => x.ErrorMessage);
                    var fullErrorMessage = string.Join(";", errorMessages);
                    var exceptionMessage = string.Concat(ex.Message, "The validation erros are: ",
                        fullErrorMessage);
                    message = exceptionMessage + "\n" + ex.EntityValidationErrors;

                    dbCtxTran.Rollback();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    var entityObj = ex.Entries.Single().GetDatabaseValues();
                    if (entityObj == null)
                    {
                        message = "The entity being updated is already deleted by another user";
                    }
                    else
                        message = "The entity being updated has already been updated by another user";

                    dbCtxTran.Rollback();
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                    dbCtxTran.Rollback();
                }

            }

            //retorna el mensaje de error, en caso de ocurrir alguno de lo contrario regresa vacio
            return message;
            #endregion
        }

        public static string updateProveedor(Proveedor entity)
        {
            #region //modificar
            //Variable para almacenar el mensaje de error en caso de que ocurra alguno
            string message = string.Empty;

            //varaible para almacenar si se inserto correctamente el registro
            bool isInserted = false;

            //se utiliza un espacio de nombres para utilizar las transacciones
            using (var dbCtxTran = dbCtx.Database.BeginTransaction())
            {
                try
                {
                    //se verifica si la base de datos existe
                    bool isDatabaseExist = Database.Exists(dbCtx.Database.Connection);

                    //Si existe la base de datos se procede a insertar el registro
                    if (isDatabaseExist)
                    {
                        //alternativa #1 - Actualizando con Entity Framework
                        dbCtx.Entry(entity).State = EntityState.Modified;
                        isInserted = dbCtx.SaveChanges() > 0;
                        if (isInserted)
                        {
                            //para confimar que si se realizo el cambio
                            dbCtxTran.Commit();
                        }

                    }

                }
                catch (DbEntityValidationException ex)
                {
                    var errorMessages = ex.EntityValidationErrors
                         .SelectMany(x => x.ValidationErrors)
                         .Select(x => x.ErrorMessage);
                    var fullErrorMessage = string.Join(";", errorMessages);
                    var exceptionMessage = string.Concat(ex.Message, "The validation erros are: ",
                        fullErrorMessage);
                    message = exceptionMessage + "\n" + ex.EntityValidationErrors;

                    dbCtxTran.Rollback();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    var entityObj = ex.Entries.Single().GetDatabaseValues();
                    if (entityObj == null)
                    {
                        message = "The entity being updated is already deleted by another user";
                    }
                    else
                        message = "The entity being updated has already been updated by another user";

                    dbCtxTran.Rollback();
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                    dbCtxTran.Rollback();
                }

            }

            //retorna el mensaje de error, en caso de ocurrir alguno de lo contrario regresa vacio
            return message;
            #endregion
        }

        public static string removeProveedor(int ProveedorID)
        {
            #region //Eliminar
            //Variable para almacenar el mensaje de error en caso de que ocurra alguno
            string message = string.Empty;

            //varaible para almacenar si se inserto correctamente el registro
            bool isRemoved = false;

            //se utiliza un espacio de nombres para utilizar las transacciones
            using (var dbCtxTran = dbCtx.Database.BeginTransaction())
            {
                try
                {
                    //saber si la BD existe
                    bool isDatabaseExist = Database.Exists(dbCtx.Database.Connection);

                    if (isDatabaseExist)
                    {
                        //consultar para obtener el objeto a eliminar
                        var objProveedor = dbCtx.Proveedors
                            .Where(x => x.Id == ProveedorID)
                            .SingleOrDefault();

                        //consultar para eliminar el objeto
                        dbCtx.Proveedors.Remove(objProveedor);

                        //guardar el status del borradoor
                        isRemoved = dbCtx.SaveChanges() > 0;

                        //si se elimino correctamente hago el commit
                        if (isRemoved)
                        {
                            dbCtxTran.Commit();
                        }
                    }
                }
                catch (DbEntityValidationException ex)
                {
                    var errorMessages = ex.EntityValidationErrors
                         .SelectMany(x => x.ValidationErrors)
                         .Select(x => x.ErrorMessage);
                    var fullErrorMessage = string.Join(";", errorMessages);
                    var exceptionMessage = string.Concat(ex.Message, "The validation erros are: ",
                        fullErrorMessage);
                    message = exceptionMessage + "\n" + ex.EntityValidationErrors;

                    dbCtxTran.Rollback();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    var entityObj = ex.Entries.Single().GetDatabaseValues();
                    if (entityObj == null)
                    {
                        message = "The entity being updated is already deleted by another user";
                    }
                    else
                        message = "The entity being updated has already been updated by another user";

                    dbCtxTran.Rollback();
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                    dbCtxTran.Rollback();
                }
            }
            //retorna el mensaje de error, en caso de ocurrir alguno de lo contrario regresa vacio
            return message;
            #endregion
        }
    }
}