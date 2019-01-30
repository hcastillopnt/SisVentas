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
        public static SisVentasDbContext dbCtx = new SisVentasDbContext();

        public static List<Proveedor> getProveedorByID(int ProveedorID)
        {
            List<Proveedor> proveedores = new List<Proveedor>();
            //SELECT * FROM WHERE Id = ?
            proveedores = dbCtx.Proveedores.Where(x => x.ID == ProveedorID).ToList();
            return proveedores;
        }

        //Método para consultar todos los estudiantes (Select * From Students), retorna lista de estudiantes registrados
        public static List<Proveedor> getAllProveedores()
        {
            List<Proveedor> proveedores = new List<Proveedor>();

            //SELECT * FROM Students
            proveedores = dbCtx.Proveedores.ToList();

            return proveedores;
        }

        //Método para traer un registro especifico
        public static List<Proveedor> getProveedorByNumDocumento(string NumDocumento)
        {
            List<Proveedor> proveedores = new List<Proveedor>();

            //SELECT * FROM Students WHERE LastName = '_____'
            proveedores = dbCtx.Proveedores.Where(x => x.NumDocumento == NumDocumento).ToList();

            return proveedores;

        }
        public static List<Proveedor> getProveedorByRazonSocial(string RazonSocial)
        {
            List<Proveedor> proveedores = new List<Proveedor>();


            proveedores = dbCtx.Proveedores.Where(x => x.RazonSocial == RazonSocial).ToList();

            return proveedores;

        }

        #region Método para insertar
        //Metodo para insertar en la tabla student
        public static string insertProveedor(Proveedor entity)
        {
            // Variable para almacenar el mensaje de error en caso de que ocurra alguno
            string message = string.Empty;
            //Variable para almacenar si se insertó correctamente el registro
            bool isInserted = false;

            //Se utiliza un espacio de nombre para utilizar las transacciones
            using (var dbCtxTran = dbCtx.Database.BeginTransaction())
            {

                try
                {
                    // Se verifica si la base de datos existe 
                    bool isDataBaseExist = Database.Exists(dbCtx.Database.Connection);

                    //Si existe la base de datos se procede a insertar el registro
                    if (isDataBaseExist)
                    {
                        // Seañade la entidad al contexto
                        dbCtx.Proveedores.Add(entity);

                        //Se guardan los cambios en el contesto y se verifia si se efectuó de manera correcta
                        isInserted = dbCtx.SaveChanges() > 0;

                        //Si se realizó correctamente la inserción se procede a ejecutar la transacción
                        if (isInserted)
                        {
                            //Se hace commit a la transacción
                            dbCtxTran.Commit();
                        }
                        #endregion

                       
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
       

        #region Método para ACTUALIZAR
        //Metodo para ACTUALIZAR en la tabla student
        public static string updateProveedor(Proveedor entity)
        {
            // Variable para almacenar el mensaje de error en caso de que ocurra alguno
            string message = string.Empty;
            //Variable para almacenar si se insertó correctamente el registro
            bool isUpdated = false;

            //Se utiliza un espacio de nombre para utilizar las transacciones
            using (var dbCtxTran = dbCtx.Database.BeginTransaction())
            {
                try
                {
                    // Se verifica si la base de datos existe 
                    bool isDataBaseExist = Database.Exists(dbCtx.Database.Connection);

                    //Si existe la base de datos se procede a insertar el registro
                    if (isDataBaseExist)
                    {
                        //Alternativa #1 Actualizando con Entity Framework
                        //Buscamos el objeto a actualizar
                        var proveedor = dbCtx.Proveedores.Find(entity.ID);

                        //Validar que el objeto exista
                        if (proveedor != null)
                        {
                            //Damos los valores a modificar
                            proveedor.RazonSocial = entity.RazonSocial;
                            proveedor.SectorComercial = entity.SectorComercial;
                            proveedor.TipoDocumento = entity.TipoDocumento;
                            proveedor.NumDocumento = entity.NumDocumento;
                            proveedor.Direccion = entity.Direccion;
                            proveedor.Telefono = entity.Telefono;
                            proveedor.Email = entity.Email;
                            proveedor.URL = entity.URL;
                            
                            //Se añade la entidad al contexto
                            dbCtx.Entry(proveedor).State = EntityState.Modified;

                            //Se guardan los cambios en el contexto, y se verifica si se efectuo de manera correcta
                            isUpdated = dbCtx.SaveChanges() > 0;

                            //Si se realizó correctamente la actualización se procede a ejecutar la transacción
                            if (isUpdated)
                            {
                                dbCtxTran.Commit();
                            }
                        }
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
        #endregion
        public static string removeProveedor(int ProveedorID)
        {
            //Almacena los errores del método
            string message = string.Empty;
            //Almacena el estatus del método
            bool isRemoved = false;

            using (var dbCtxTran = dbCtx.Database.BeginTransaction())
            {
                try
                {
                    bool isDataBaseExist = Database.Exists(dbCtx.Database.Connection);

                    if (isDataBaseExist)
                    {
                        //Consulta para obtener el objeto a eliminar
                        var objProveedor = dbCtx.Proveedores.Where(x => x.ID == ProveedorID)
                            .SingleOrDefault();

                        //Consulta para eliminar el objeto
                        dbCtx.Proveedores.Remove(objProveedor);

                        //Guardar el estatus del borrado
                        isRemoved = dbCtx.SaveChanges() > 0;

                        //Si se eliminó correctamente hago el commit
                        if (isRemoved)
                        {
                            dbCtxTran.Commit();
                        }
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
