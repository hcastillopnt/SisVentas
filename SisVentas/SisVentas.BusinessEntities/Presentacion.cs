﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SisVentas.BusinessEntities
{
    public class Presentacion
    {
        public int ID { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }
    }
}
