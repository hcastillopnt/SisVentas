using SisVentas.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;

namespace SisVentas.DataAccessLayer
{
    public class ProveedorDAL
    {
        //Método para insertar un proveedor
        //Entidad del proyecto BusinessEntities (Proveedor) entity
        public static string insertProveedor(Proveedor entity)
        {
            //Variable que sirve para almacenar los errores que tuviera el programa
            string message = string.Empty;

            //Variable que sirve para almacenar la inserción a la base de datos 
            bool isInserted = false;

            //Utilizo el espacio de nombres para poder mandar a llenar la clase DbContext
            //anteriormente creada en el proyecto BusinessEntities, y que nos servirá para
            //realizar las consultas a la BD
            using (SisVentasDbContext dbCtx = new SisVentasDbContext())
            {
                //Utilizo el espacio de nombres para poder llamar a la clase DbContextTransaction
                //la cual nos servirá para realizar las operaciones CRUD de manera mas segura, a excepcion
                //de la parte de lectura (SELECT's)
                using (DbContextTransaction dbCtxTran = dbCtx.Database.BeginTransaction())
                {
                    //Utilizo un try-catch para encapsular el codigo que nos puede generar
                    //problemas en un futuro y por lo tanto nos genere excepciones que podemos controlar
                    try
                    {
                        //Esta linea nos servira para validar la existencia de la base de datos, en 
                        //base a la cadena de conexion creada en app.config lamada sisventasdbcontext
                        bool isDataBaseExists = Database.Exists(dbCtx.Database.Connection);

                        //Si la base de datos existe, se procedera a realizar las operaciones de insercion pero en el
                        //caso de que no fuera asi se enviara una mensaje de error al usuario
                        if (isDataBaseExists)
                        {
                            //Esta linea sirve para rastrear la entidad de la base de datos, con la que estaos trabajando
                            //la cual debera recibir como parametro la entidad que viene desde la 
                            //capa de negocios(validada) y desde la interfaz de usuario(con informacio)
                            dbCtx.Proveedores.Add(entity);

                            //
                            isInserted = dbCtx.SaveChanges() > 0;

                            if (isInserted)
                            {
                                dbCtxTran.Commit();
                            }
                            else
                            {
                                message = "El registro no se efecuó correctamente";
                            }
                        }
                        else
                        {
                            message = "La base de datos a la que intenta acceder no se encuentra disponible, favor de contactar al administrador";
                        }
                    }

                    catch (DbEntityValidationException ex)
                    {
                        var errorMessages = ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors)
                            .Select(x => x.ErrorMessage);
                        var fullErrorMessage = string.Join("; ", errorMessages);
                        var exceptionMessage = string.Concat(ex.Message, "The validation errors are: ",
                            fullErrorMessage);
                        message = exceptionMessage + "\n" + ex.EntityValidationErrors;

                        dbCtxTran.Rollback();
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        var entityobj = ex.Entries.Single().GetDatabaseValues();

                        if (entityobj == null)
                            message = "The entity being updated is already deleted by another user";
                        else
                            message = "The entity being update has already been updated by another user";

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
}
