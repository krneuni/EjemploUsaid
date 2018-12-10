using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ejemplo_con_linq.Models
{
    public class Alumnos
    {
        public int Carnet { get; set; }
        public string Nombre { get; set; }
        public string Materia { get; set; }
        public double Promedio { get; set; }
        public DateTime Fecha { get; set; }


        public List<Alumnos> Lista()

        {
            var estudiante1 = new Alumnos()
            {
                Carnet = 001,
                Nombre = "Karen Martinez",
                Materia = "MVC",
                Promedio = 9,
                Fecha = DateTime.Now

            };
            var estudiante2 = new Alumnos()
            {
                Carnet = 002,
                Nombre = "Eunice Hernández",
                Materia = "MVC",
                Promedio = 8,
                Fecha = DateTime.Now

            };
            var estudiante3 = new Alumnos()
            {
                Carnet = 003,
                Nombre = "Becka",
                Materia = "Xamarin",
                Promedio = 6,
                Fecha = DateTime.Now

            };
            var estudiante4 = new Alumnos()
            {
                Carnet = 004,
                Nombre = "Ivan Pan",
                Materia = "Xamarin",
                Promedio = 7,
                Fecha = DateTime.Now

            };
            return new List<Alumnos>() { estudiante1, estudiante2, estudiante3, estudiante4 };
        }
    }

}