using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//agregadas
using MySql.Data.MySqlClient;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using SisVentas.BusinessEntities;

namespace SisVentas.DataAccessLayer
{

    public class TrabajadorDAL
    {

        public static SisVentasDbContext dbCtx = new SisVentasDbContext();

        public static string insertTrabajador(Trabajador trabajador)
        {
            //variable para almacenar mensaje
            string message = string.Empty;

            //variable para almacenar si se regirtro correctamente
            bool isInserted = false;
            
            using(var dbCtxTran = dbCtx.Database.BeginTransaction())
            {
                try
                {
                    bool isDatabaseExist = Database.Exists(dbCtx.Database.Connection);

                    if (isDatabaseExist)
                    {
                        //Alternativa #1 - Entity Framework
                        //se añade la entidad al contexto
                        dbCtx.Trabajadores.Add(trabajador);

                        //se guardan los cambios en el contexto y se verifica que se efectuo de manera correcta
                        isInserted = dbCtx.SaveChanges() > 0;

                        //si se realizo correctamente procede a ejecutar la transaccion
                        if (isInserted)
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

        public static List<Trabajador> getAllTrabajadores()
        {
            List<Trabajador> trabajadores = new List<Trabajador>();

            trabajadores = dbCtx.Trabajadores.ToList();


            return trabajadores;
        }

        public static List<Trabajador> getTrabajadorByNumDocumento(string trabajadorNumDocumento)
        {
            //lista para almacenar el objeto a buscar
            List<Trabajador> trabajadores = new List<Trabajador>();

            //buscar
            trabajadores = dbCtx.Trabajadores.Where(x => x.NumDocumento == trabajadorNumDocumento).ToList();

            return trabajadores;
        }

        public static List<Trabajador> getTrabajadorByApellido(string trabajadorApellido)
        {
            //lista para almacenar el objeto a buscar
            List<Trabajador> trabajadores = new List<Trabajador>();

            //buscar
            trabajadores = dbCtx.Trabajadores.Where(x => x.Apellidos == trabajadorApellido).ToList();

            return trabajadores;
        }

        public static string updateTrabajador(Trabajador trabajador)
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
                        var entity = dbCtx.Trabajadores.Find(trabajador.ID);

                        //el objeto debe existir  
                        if (entity != null)
                        {
                            //valores a modificar
                            entity.Nombre = trabajador.Nombre;
                            entity.Apellidos = trabajador.Apellidos;
                            entity.Sexo = trabajador.Sexo;
                            entity.FechaNacimiento = trabajador.FechaNacimiento;
                            entity.NumDocumento = trabajador.NumDocumento;
                            entity.Direccion = trabajador.Direccion;
                            entity.Telefono = trabajador.Telefono;
                            entity.Email = trabajador.Email;
                            entity.Usuario = trabajador.Usuario;
                            entity.Contraseña = trabajador.Contraseña;

                            //se añade al contexto
                            dbCtx.Entry(entity).State = EntityState.Modified;

                            isUpdated = dbCtx.SaveChanges() > 0;

                            //si se realizo correctamente procede a ejecutar la transaccion
                            if (isUpdated)
                            {
                                dbCtxTran.Commit();
                            }

                        }
                        else
                        {
                            message = "no existe";
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

        public static string deleteTrabajador(int trabajadorID)
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
                        var entity = dbCtx.Trabajadores.Where(x => x.ID == trabajadorID).SingleOrDefault();

                        //para eliminar
                        dbCtx.Trabajadores.Remove(entity);

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
