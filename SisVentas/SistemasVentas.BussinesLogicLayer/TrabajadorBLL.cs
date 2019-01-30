﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemasVentas;

namespace SistemasVentas.BussinesLogicLayer
{
   public class TrabajadorBLL
    {
        public static List<Trabajador> getTrabajadorByFilter(string Filter, string bandera)
        {
            //Lista para almacenar el objeto a buscar
            List<Trabajador> Trabajadors = new List<Trabajador>();
        
            switch (bandera)
            {
                case "TrabajadorId":
                    int TrabajadorID = Convert.ToInt32(Filter);
                    Trabajadors = SistemasVentas.DataAccessLayer.TrabajadorDAL.getTrabajadorByID(TrabajadorID);
                    break;
            }
            return Trabajadors;

        }

        public static List<Trabajador> getTrabajadorByID(int TrabajadorID)
        {
            //Lista para almacenar el objeto a buscar
            List<Trabajador> Trabajadors = new List<Trabajador>();

            //Puente entre el DataAccessLayer y el BussinesLogicLayer
            Trabajadors = SistemasVentas.DataAccessLayer.TrabajadorDAL.getTrabajadorByID(TrabajadorID);

            return Trabajadors;


        }

        public static List<Trabajador> getAllTrabajador()
        {
            //Lista para almacenar el objeto a buscar
            List<Trabajador> Trabajadors = new List<Trabajador>();

            //Puente entre el DataAccessLayer y el BussinesLogicLayer
            Trabajadors = SistemasVentas.DataAccessLayer.TrabajadorDAL.getAllTrabajador();

            return Trabajadors;
        }
   
       public static string insertTrabajador(Trabajador objTrabajador)
        {
            //Variable para almacenar el mensaje de error en caso de que ocurra alguno
            string message = string.Empty;

            ICollection<ValidationResult> result = null;

            if(!validate(objTrabajador,out result))
            {
                message = string.Join("\n", result.Select(o => o.ErrorMessage));
            }
            else
            {
                message = SistemasVentas.DataAccessLayer.TrabajadorDAL.insertTrabajador(objTrabajador);
            }


            //regresa el mensaje con o sin errores
            return message;

        }

        public static bool validate<T>(T obj, out ICollection<ValidationResult> results)
        {
            results = new List<ValidationResult>();
            return Validator.TryValidateObject(obj, new ValidationContext(obj), results, true);
        }

        public static string updateTrabajador(Trabajador objTrabajador)
        {
            //Variable para almacenar el mensaje de error en caso de que ocurra alguno
            string message = string.Empty;

            ICollection<ValidationResult> result = null;

            if (!validate(objTrabajador, out result))
            {
                message = string.Join("\n", result.Select(o => o.ErrorMessage));
            }
            else
            {
                message = SistemasVentas.DataAccessLayer.TrabajadorDAL.updateTrabajador(objTrabajador);
            }
       
            //regresa el mensaje con o sin errores
            return message;
        }

        public static string removeTrabajador(int TrabajadorID)
        {
            //Variable para almacenar el mensaje de error en caso de que ocurra alguno
            string message = string.Empty;

            if (TrabajadorID > 0)
            {

                return SistemasVentas.DataAccessLayer.TrabajadorDAL.removeTrabajador(TrabajadorID);

            }
            else
            {
                return "Error";
            }

        }
    }
}