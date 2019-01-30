using SisVentas.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;


namespace SisVentas.DataAccessLayer
{
    public class ClienteDAL
    {
        //Se crea una instancia de la clase DBContext para acceder a la BD
        public static SisVentasDbContext dbCtx = new SisVentasDbContext();

        public static List<Cliente> getClienteByID(int ID)
        {

            List<Cliente> cliente = new List<Cliente>();

            //SELECT * FROM WHERE Id = ?
            cliente = dbCtx.Clientes.Where(x => x.ID == ID).ToList();

            return cliente;
        }


        //Metodo para obtener todos los estudiantes registrados, en pocas palabras un SELECT * FROM
        /// <returns>Lista Estudiantes</returns>

        public static List<Cliente> getAllClientes()
        {
            List<Cliente> clientes = new List<Cliente>();

            //SELECT * FROM Students
            clientes = dbCtx.Clientes.ToList();

            return clientes;
        }

        //Metodo para obtener los estudiantes por medio del apellido

        public static List<Cliente> getClienteByNumDocumento(string numdocumento)
        {
            List<Cliente> clientes = new List<Cliente>();

            //SELECT * FROM Students WHERE LastName = '____'
            clientes = dbCtx.Clientes
                .Where(x => x.NumDocumento == numdocumento)
                .ToList();

            return clientes;
        }

        public static List<Cliente> getClienteByNombre(string nombre)
        {
            List<Cliente> clientes = new List<Cliente>();

            //SELECT * FROM Students WHERE LastName = '____'
            clientes = dbCtx.Clientes
                .Where(x => x.Nombre == nombre)
                .ToList();

            return clientes;
        }

        public static List<Cliente> getClienteByApellidos(string apellidos)
        {
            List<Cliente> clientes = new List<Cliente>();

            //SELECT * FROM Students WHERE LastName = '____'
            clientes = dbCtx.Clientes
                .Where(x => x.Apellidos == apellidos)
                .ToList();

            return clientes;
        }



        public static string insertCliente(Cliente cliente)
        {
            //Variable que srive almacenar los posibles errores
            string message = string.Empty;

            //Varialbe que sirve para almacenar el estatus de la insercion a la bd
            bool isInserted = false;

            //Utilizo el espacio de
            using (SisVentasDbContext dbCtx = new SisVentasDbContext())
            {
                //Utilizo el espacio de nombres para poder llamar a la clase DbContextTransaction
                using (DbContextTransaction dbCtxTran = dbCtx.Database.BeginTransaction())
                {
                    //Utilizo un Try-Catch para encapsular el codigo que nos puede generar problemas en un fututo
                    //y por lo tanto nos genere expeciones que podemos controlar
                    try
                    {
                        //Esta linea nos servira para validar la existencia de la base de datos, en base a la cadena
                        //de conexion creada en el archivo app.config
                        bool isDataBaseExists = Database.Exists(dbCtx.Database.Connection);

                        if (isDataBaseExists)
                        {
                            //Esta lina sirve para rastrear
                            dbCtx.Clientes.Add(cliente);

                            //Esta linea sirve para guardar
                            isInserted = dbCtx.SaveChanges() > 0;

                            //Si la insercion fue realizada correctamente, se procedera a realizar el commit
                            if (isInserted)
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
                        var fullErrorMessage = string.Join("; ", errorMessages);
                        var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ",
                            fullErrorMessage);
                        message = exceptionMessage + "/n" + ex.EntityValidationErrors;

                        dbCtxTran.Rollback();
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        var entityObj = ex.Entries.Single().GetDatabaseValues();

                        if (entityObj == null)
                            message = "The entity being updated is already deleted by another user";
                        else
                            message = "The entity being updated has already been updated by another user";
                        dbCtxTran.Rollback();
                    }//Fin de DbUpdateConcurrencyException
                    catch (Exception ex)
                    {
                        message = ex.Message;

                        dbCtxTran.Rollback();
                    }//Fin de Exception
                }

                //Retorna el valor obtenido en la variable message
                return message;
            }//Fin del metodo insert
        }



        public static string updateCliente(Cliente cliente)
        {
            //Variable para almacenar el mensaje de error en caso de que  ocurra alguno
            string message = string.Empty;

            //Variable para almacenar si se inserto correctamente el registro
            bool isUpdated = false;

            //Se utiliza un espacio de nombres para utilizar las transacciones
            using (var dbCtxTran = dbCtx.Database.BeginTransaction())
            {

                try
                {
                    //Se verifica si la base de datos existe
                    bool isDataBaseExist = Database.Exists(dbCtx.Database.Connection);

                    //Si existe la base de datos se procede a insertar el registro
                    if (isDataBaseExist)
                    {
                        //Alternativa #1 - Funcion para modificar en la base de datos por medio de Entity Framework

                        //Buscamos el objeto a actualizar
                        var entity = dbCtx.Clientes.Find(cliente);

                        //Validar que el objeto exista
                        if (entity != null)
                        {
                            //Damos los valores a modificar
                            entity.ID = cliente.ID;
                            entity.Nombre = cliente.Nombre;
                            entity.Apellidos = cliente.Apellidos;
                            entity.Sexo = cliente.Sexo;
                            entity.FechaNacimiento = cliente.FechaNacimiento;
                            entity.TipoDocumento = cliente.TipoDocumento;
                            entity.NumDocumento = cliente.NumDocumento;
                            entity.Direccion = cliente.Direccion;
                            entity.Telefono = cliente.Telefono;
                            entity.Email = cliente.Email;

                            //Se añade la entidad al contexto
                            dbCtx.Entry(entity).State = EntityState.Modified;

                            //Se guardan los cambios en el contexto, y se verifica si se efectuo de mano
                            isUpdated = dbCtx.SaveChanges() > 0;

                            //Si se realizo correctamente la actualizacion se procede a ejecutar ka transaccion
                            if (isUpdated)
                            {
                                //Se hace commit a la transaccion
                                dbCtxTran.Commit();
                            }//Fin de la validacion isUpdate == true

                        }//Fin de la validacion entity != null
                    }//Fin de validacion de DataBaseExist


                }//Fin de try
                catch (DbEntityValidationException ex)
                {
                    var errorMessages = ex.EntityValidationErrors
                            .SelectMany(x => x.ValidationErrors)
                            .Select(x => x.ErrorMessage);
                    var fullErrorMessage = string.Join("; ", errorMessages);
                    var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ",
                        fullErrorMessage);
                    message = exceptionMessage + "/n" + ex.EntityValidationErrors;

                    dbCtxTran.Rollback();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    var entityObj = ex.Entries.Single().GetDatabaseValues();

                    if (entityObj == null)
                        message = "The entity being updated is already deleted by another user";
                    else
                        message = "The entity being updated has already been updated by another user";
                    dbCtxTran.Rollback();
                }//Fin de DbUpdateConcurrencyException
                catch (Exception ex)
                {
                    message = ex.Message;

                    dbCtxTran.Rollback();
                }//Fin de Exception

            }

            //Retorna el mensaje de error, en caso de ocurrir alguno, de lo contrario regresara
            return message;
        }


        public static string removeCliente(int cliente)
        {
            //variable para almacnar los errores del metodo
            string message = string.Empty;
            //esta varianble para almacenar estatud de metodo
            bool isRemoved = false;

            using (var dbCtxTran = dbCtx.Database.BeginTransaction())
            {
                try
                {
                    bool isDataBaseExists = Database.Exists(dbCtx.Database.Connection);

                    if (isDataBaseExists)
                    {
                        //traer una consulta para obtener el obhjeto a eliminar
                        var objCliente = dbCtx.Clientes.Where(x => x.ID == cliente)
                            .SingleOrDefault();

                        //consulta para eliminar el objeto
                        dbCtx.Clientes.Remove(objCliente);

                        //guardo el estatud del borrado
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
