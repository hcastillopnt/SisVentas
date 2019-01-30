using SistemasVentas;
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
    public class ClienteDAL
    {
        //se crea una instancia de la clase DbContext para acceder a la DB
        public static SistemaDBContext dbCtx = new SistemaDBContext();

        //comentario de prueb
    
        public static List<Cliente> getClienteByID(int ClienteID)
        {
            List<Cliente> clientes = new List<Cliente>();
            //SELECT * FROM STUDENT WHERE  Id= '____'
            clientes = dbCtx.Clientes.Where(x => x.Id == ClienteID).ToList();

            return clientes;
        }
        public static List<Cliente> getClientebyApellidos(string apellidos)
        {
            List<Cliente> clientes = new List<Cliente>();
            //SELECT * FROM STUDENT WHERE  LastName= '____'
            clientes = dbCtx.Clientes.Where(x => x.Apellidos == apellidos ).ToList();
            return clientes;
        }

        //Metodo para obtener todos los estudiantes registrados en pocas palabras select * from
        public static List<Cliente> getAllCliente()
        {
            List<Cliente> clientes  = new List<Cliente>();

            //SELECT * FROM STUDENTS
            clientes = dbCtx.Clientes.ToList();

            return clientes;
        }

        public static string insertarCliente(Cliente entity)
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
                        dbCtx.Clientes.Add(entity);

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

        public static string updateCliente(Cliente original)
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
                        var nuevo = dbCtx.Clientes.Find(original.Id);

                        //validar que el objeto exista
                        if (nuevo != null)
                        {

                            //damos valores a modificar
                            nuevo.Apellidos = original.Apellidos;
                            nuevo.Direccion = original.Direccion;
                            nuevo.Email = original.Email;
                            nuevo.FechaNacimiento = original.FechaNacimiento;
                            nuevo.Nombre = original.Nombre;
                            nuevo.NumeroDocumento = original.NumeroDocumento;
                            nuevo.Sexo = original.Sexo;
                            nuevo.Telefono = original.Telefono;
                            nuevo.TipoDocumento = original.TipoDocumento;

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

        public static string removeCliente(int ClienteID)
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
                        var objStudent = dbCtx.Clientes.Where(x => x.Id == ClienteID).SingleOrDefault();

                        //Consulta para eliminar el objeto
                        dbCtx.Clientes.Remove(objStudent);

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
