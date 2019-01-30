﻿using SistemasVentas;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
   public class VentaDAL
    {
        //se crea una instancia de la clase DbContext para acceder a la DB
        public static SistemaDBContext dbCtx = new SistemaDBContext();


        public static List<Venta> getVentaByFecha(DateTime VentaFecha)
        {
            List<Venta> ventas= new List<Venta>();
            //SELECT * FROM STUDENT WHERE  Id= '____'
            ventas= dbCtx.Ventas.Where(x => x.Fecha == VentaFecha).ToList();

            return ventas;
        }
       
        //Metodo para obtener todos los estudiantes registrados en pocas palabras select * from
        public static List<Venta> getAllVentas()
        {
            List<Venta> ventas= new List<Venta>();

            //SELECT * FROM STUDENTS
            ventas = dbCtx.Ventas.ToList();

            return ventas;
        }

        public static string insertarVenta(Venta entity)
        {
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


                        //se añade la entidad al contexto
                        dbCtx.Ventas.Add(entity);

                        //Se guardan los cambios en el contexto y se verifica si se efectuo de manera correcta
                        isInserted = dbCtx.SaveChanges() > 0;

                        //Si se realizo correctamente la inserccion se procede a ejecutar la transaccion
                        if (isInserted)
                        {
                            //Se hace commit a la transaccion
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


        }

        public static string updateVenta(Venta original)
        {
            //Variable para almacenar el mensaje de error en caso de que ocurra alguno
            string message = string.Empty;

            //varaible para almacenar si se inserto correctamente el registro
            bool isUpdated = false;

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
                        //Funcion para modificar en la base de datos por medio de entity framework

                        //Buscamos el objeto a actualizar
                        var nuevo = dbCtx.Ventas.Find(original.Id);

                        //validar que el objeto exista
                        if (nuevo != null)
                        {

                            //damos valores a modificar
                            nuevo.Correlativo = original.Correlativo;
                            nuevo.Fecha = original.Fecha;
                            nuevo.Igv = original.Igv;
                            nuevo.Serie = original.Serie;
                            nuevo.TipoComporbante = original.TipoComporbante;
                            

                            //se añade la entidad al contexto
                            dbCtx.Entry(nuevo).State = EntityState.Modified;

                            //se guardan los cambios en el contexto y se verifica si se efectuo de manera correcta
                            isUpdated = dbCtx.SaveChanges() > 0;

                            //si se realizo correctamente la actualizacion se procede a ejecutar la transaccion
                            if (isUpdated)
                            {
                                //Se hace commit a la transaccion
                                dbCtxTran.Commit();

                            }

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


        }

        public static string removeVenta(int VentaID)
        {
            //Esta variable para almacenar los errores del metodo
            string message = string.Empty;

            //Esta variable para almacenar el estatus del metodo
            bool isRemoved = false;


            using (var dbCtxTran = dbCtx.Database.BeginTransaction())
            {
                try
                {
                    //Saber si la base de datos existe
                    bool isDatabaseExist = Database.Exists(dbCtx.Database.Connection);

                    if (isDatabaseExist)
                    {
                        //consulta para traer el objeto a eliminar
                        var objStudent = dbCtx.Ventas.Where(x => x.Id == VentaID).SingleOrDefault();

                        //Consulta para eliminar el objeto
                        dbCtx.Ventas.Remove(objStudent);

                        //Guardo el estatus del borrado
                        isRemoved = dbCtx.SaveChanges() > 0;

                        //Si se elimino correctamente hago el commit
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

        }
    }
}
