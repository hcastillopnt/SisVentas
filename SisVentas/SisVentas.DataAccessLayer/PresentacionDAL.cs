using SisVentas.BusinessEntities;
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
    public class PresentacionDAL
    {
        public static SisVentasDbContext dbCtx = new SisVentasDbContext();
        public static string InsertarPresentacion(Presentacion entity)
        {

            string message = string.Empty;

            bool isInserted = false;

            using (SisVentasDbContext dbCtx = new SisVentasDbContext())
            {
                using (DbContextTransaction dbCtxTran = dbCtx.Database.BeginTransaction())
                {
                    try
                    {
                        bool isDateBaseExists = Database.Exists(dbCtx.Database.Connection);
                        if (isDateBaseExists)
                        {
                            dbCtx.Presentaciones.Add(entity);

                            isInserted = dbCtx.SaveChanges() > 0;

                            if (isInserted)
                            {
                                dbCtxTran.Commit();
                            }
                            else
                            {
                                message = "La presentacion que ha realizado ,no se efectuo correctamente";
                            }
                        }
                        else
                        {
                            message = "La base de datos a la que intentan acceder no se encunetra disonible, Fabor de contactar al administrador";

                        }
                    }
                    catch (DbEntityValidationException ex)
                    {
                        var errorMessages = ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage);
                        var fullErrorMessage = string.Join("; ", errorMessages);
                        var exeptionMessage = string.Concat(ex.Message, "The validation errors are: ", fullErrorMessage);
                        message = exeptionMessage + "\n" + ex.EntityValidationErrors;

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
                        {
                            message = "The entity being updated is already being updated by another user";
                        }

                        dbCtxTran.Rollback();
                    }
                    catch (Exception ex)
                    {
                        message = ex.Message;

                        dbCtxTran.Rollback();
                    }
                }
                return message;
            }
        }
            public static List<Presentacion> getAllPresentaciones()
            {
                List<Presentacion> presentacions = new List<Presentacion>();

                presentacions = dbCtx.Presentaciones.ToList();


                return presentacions;
            }

        public static List<Presentacion> getPresentacionByNom(string PresetacionNom)
        {
            //lista para almacenar el objeto a buscar
            List<Presentacion> presentacions = new List<Presentacion>();

            //buscar
            presentacions = dbCtx.Presentaciones.Where(x => x.Nombre == PresetacionNom).ToList();

            return presentacions;
        }
        public static string updatepresentacion(Presentacion presentacion)
        {
            //variable para almacenar mensaje en caso de error
            string message = string.Empty;

            //variable para almacenar si se regirtro correctamente
            bool isUpdated = false;

            //se usa un espacio de nombres para utilizar las transacciones
            using (var dbCtxTran = dbCtx.Database.BeginTransaction())
            {
                try
                {
                    //se verifica si existe la base de daros
                    bool isDatabaseExist = Database.Exists(dbCtx.Database.Connection);

                    //si existe la base de datos entonces se procede
                    if (isDatabaseExist)
                    {
                        //Alternativa #1 - Entity Framework
                        //buscar objeto a actualizar
                        var entity = dbCtx.Presentaciones.Find(presentacion.ID);

                        //el objeto debe existir  
                        if (entity != null)
                        {
                            //valores a modificar
                            entity.ID = presentacion.ID;
                            entity.Nombre = presentacion.Nombre;
                            entity.Descripcion = presentacion.Descripcion;

                            //se añade al contexto
                            dbCtx.Entry(presentacion).State = EntityState.Modified;

                            isUpdated = dbCtx.SaveChanges() > 0;

                            //si se realizo correctamente procede a ejecutar la transaccion
                            if (isUpdated)
                            {
                                dbCtxTran.Commit();
                            }

                        }
                    }

                }
                catch (DbEntityValidationException ex)
                {
                    var errorMessages = ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage);
                    var fullErrorMessage = string.Join("; ", errorMessages);
                    var exeptionMessage = string.Concat(ex.Message, "The validation errors are: ", fullErrorMessage);
                    message = exeptionMessage + "\n" + ex.EntityValidationErrors;

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
                    {
                        message = "The entity being updated is already being updated by another user";
                    }

                    dbCtxTran.Rollback();
                }
                catch (Exception ex)
                {
                    message = ex.Message;

                    dbCtxTran.Rollback();
                }
            }

            return message;
        }

        public static string deletePresentacion(int PresentacionID)
        {
            //variable para almacenar mensaje en caso de error
            string message = string.Empty;

            //variable para almacenar si se regirtro correctamente
            bool isRemoved = false;

            //se usa un espacio de nombres para utilizar las transacciones
            using (var dbCtxTran = dbCtx.Database.BeginTransaction())
            {
                try
                {
                    //se verifica si existe la base de daros
                    bool isDatabaseExist = Database.Exists(dbCtx.Database.Connection);

                    if (isDatabaseExist)
                    {

                        //consulta para traer ojeto a eliminar
                        //var entity = dbCtx.Students.Find(studentID);
                        var entity = dbCtx.Presentaciones.Where(x => x.ID == PresentacionID).SingleOrDefault();

                        //para eliminar
                        dbCtx.Presentaciones.Remove(entity);

                        isRemoved = dbCtx.SaveChanges() > 0;

                        if (isRemoved)
                        {
                            dbCtxTran.Commit();
                        }
                    }
                }
                catch (DbEntityValidationException ex)
                {
                    var errorMessages = ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage);
                    var fullErrorMessage = string.Join("; ", errorMessages);
                    var exeptionMessage = string.Concat(ex.Message, "The validation errors are: ", fullErrorMessage);
                    message = exeptionMessage + "\n" + ex.EntityValidationErrors;

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
                    {
                        message = "The entity being updated is already being updated by another user";
                    }

                    dbCtxTran.Rollback();
                }
                catch (Exception ex)
                {
                    message = ex.Message;

                    dbCtxTran.Rollback();
                }
            }

            return message;
        }




    }
}