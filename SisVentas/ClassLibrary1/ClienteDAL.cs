using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemasVentas.DataAccessLayer

{
    class ClienteDAL
    {
        //se crea una instancia de la clase DbContext para acceder a la DB
        public static SistemaDBContext dbCtx = new SistemaDBContext();


        public static List<Cliente> getClienteByID(int StudentID)
        {
            List<Cliente> clientes = new List<Cliente>();

            //SELECT * FROM STUDENT WHERE  Id= '____'
            clientes = dbCtx.Clientes.Where(x => x.Id == StudentID).ToList();

            return clientes;
        }

        //Metodo para obtener todos los cientes registrados en pocas palabras select * from
        public static List<Cliente> getAllClientes()
        {
            List<Cliente> clientes = new List<Cliente>();

            //SELECT * FROM STUDENTS
            clientes = dbCtx.Clientes.ToList();

            return clientes;
        }




    }
}
