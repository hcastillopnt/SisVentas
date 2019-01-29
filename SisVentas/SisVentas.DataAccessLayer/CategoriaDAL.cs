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
   public class CategoriaDAL
    {
        public static SisVentasDbContext dbCtx = new SisVentasDbContext();

        public static List<Categoria> getAllCategoria()
        {

            List<Categoria> categorias
                = new List<Categoria>();

            //select*from a la tabla students
            categorias = dbCtx.Categorias.ToList();


            return categorias;
        }
        public static List<Categoria> getCategoriaByLastName(string Name)
        {
            List<Categoria> categorias = new List<Categoria>();

            //select * from students where lastname=´´
            categorias = dbCtx.Categorias.Where(x => x.Nombre == Name)
                .ToList();
            return categorias;
        }
        public static string updateCategoria(Categoria categoria)
        {
            string message = string.Empty;
            bool isUpdate = false;
            //se utiliza un espacio de nombres para utilizar las transacciones 
            using (var dbCtxTran = dbCtx.Database.BeginTransaction())
            {
                try
                {
                    //verifica si la base de datos existe
                    bool isDataBaseExist = Database.Exists(dbCtx.Database.Connection);
                    //siexiste la base de datos
                    if (isDataBaseExist)
                    {
                        //alternativa 1 funcion para modificar en la base de datos por medio de entity
                        //buscamos el objeto a actializar
                        var entity = dbCtx.Categorias.Find(categoria.ID);
                        //validar que el objeto exista
                        if (entity != null)
                        {
                            //damos valores a modificar
                            entity.Descripcion = categoria.Descripcion;
                            entity.Nombre = categoria.Nombre;

                            //se añade la entidad del contexto
                            dbCtx.Entry(entity).State = EntityState.Modified;
                            //se guardan los cambios en el contexto y se verifica si se efectuo el cambio
                            isUpdate = dbCtx.SaveChanges() > 0;
                            //sise realiza la actializacion correctamente
                            if (isUpdate)
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
        public static string removeCategoria(int categoriaid)
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
                        var objStudent = dbCtx.Categorias.Where(x => x.ID == categoriaid)
                            .SingleOrDefault();

                        //consulta para eliminar el objeto
                        dbCtx.Categorias.Remove(objStudent);

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
        public static string insertcategoria(Categoria categoria
            )
        {
            //variable para almacenar mensaje
            string message = string.Empty;

            //variable para almacenar si se regirtro correctamente
            bool isInserted = false;

            using (var dbCtxTran = dbCtx.Database.BeginTransaction())
            {
                try
                {
                    bool isDatabaseExist = Database.Exists(dbCtx.Database.Connection);

                    if (isDatabaseExist)
                    {
                        //Alternativa #1 - Entity Framework
                        //se añade la entidad al contexto
                        dbCtx.Categorias.Add(categoria);

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
    }
}
