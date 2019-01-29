using SistemasVentas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
   public class TrabajadorDAL
    {
        public static SistemaDBContext dbCtx = new SistemaDBContext();

        public static List<Trabajador> getTrabajadorByID(int TrabajadorID)
        {
            List<Trabajador> trabajadors = new List<Trabajador>();
            //SELECT * FROM STUDENT WHERE  Id= '____'
            trabajadors = dbCtx.Trabajadors.Where(x => x.Id == TrabajadorID).ToList();

            return trabajadors;
        }

        public static List<Trabajador> getAllTrabajador()
        {
            List<Trabajador> trabajadors = new List<Trabajador>();

            //SELECT * FROM STUDENTS
            trabajadors = dbCtx.Trabajadors.ToList();

            return trabajadors
;
        }

        public static List<Trabajador> getTrabajadorByLastName(string apellidos)
        {
            List<Trabajador> trabajadors = new List<Trabajador>();
            //SELECT * FROM STUDENT WHERE  LastName= '____'
            trabajadors = dbCtx.Trabajadors.Where(x => x.Apellidos == apellidos).ToList();
            return trabajadors;
        }



    }
}
