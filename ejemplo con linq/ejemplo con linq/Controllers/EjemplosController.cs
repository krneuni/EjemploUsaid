using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ejemplo_con_linq.Models;

namespace ejemplo_con_linq.Controllers
{
    public class EjemplosController : Controller
    {
        Alumnos c = new Alumnos();
        // GET: Ejemplos
        public ActionResult Index()
        {
            //int[] numeros = { 2, -4, 100, 150, 25, -8,200, 20, 30 };
            //var query1 = from n in numeros
            //                 //where n == 100
            //                 /* where (n % 1).Equals(0) //esta sustituye a los dos ==    numeros pares*/

            //            // orderby n ascending //numeros  ascendentes
            //            orderby n descending

            //             select n;
            //ViewBag.resultado = query1;


            // segundo array

            //    List<string> materias = new List<string>()
            //    { "matematica","algoritmia ", "Mvc basico","histori del internet","use tools", "Linq"};

            //    var query = from n in materias
            //                where n.EndsWith("t")
            //                select n;
            //    return View(query.ToList());
            //}
            var listado = c.Lista();
            return View(listado.ToList());
            
        }

        [HttpPost]
        public ActionResult Index(string txtbuscar,string Opciones, string rd )
        {
            var listado = c.Lista();
            var query = from tbl in c.Lista() select tbl;
            //validacion para que la caja no traiga datos vacios
            string formato = txtbuscar.Trim();
            #region usandoSelect
            if (formato != "")
            {
                if(Opciones=="Selected")
                {                
                    if (Opciones == "Carnet")
                    {
                            int id = Convert.ToInt32(txtbuscar);
                            query = from carnet in c.Lista() where carnet.Carnet == id select carnet;                    
                    }

                    if (Opciones == "Nombre")
                    {
                           query = (from nom in c.Lista() where nom.Nombre.Contains(txtbuscar) select nom);
                    }

                   if (Opciones == "Materia")
                   {
                            query = (from m in c.Lista() where m.Materia.Contains(txtbuscar) select m);
                   }

                    if (Opciones == "Promedio")
                    {
                        double prom = Convert.ToDouble(txtbuscar);
                        query = (from pm in c.Lista() where pm.Promedio == prom select pm);
                    }
                }        

            }

            #endregion
            #region usandoRadio
                        
                if (rd == "1")
                {
                    int carn = Convert.ToInt32(txtbuscar);
                    query = from carnet in c.Lista() where carnet.Carnet == carn select carnet;
                }
                if (rd == "2")
                {
                    query = (from nomb in c.Lista() where nomb.Nombre.Contains(txtbuscar) select nomb);
                }
                if (rd == "3")
                {
                    query = (from mater in c.Lista() where mater.Materia.Contains(txtbuscar) select mater);
                }
                if (rd == "4")
                {
                    double prom = Convert.ToDouble(txtbuscar);
                    query = (from proMedio in c.Lista() where proMedio.Promedio == prom select proMedio);

                }
            #endregion



            ////funcional 2 metodo que se puede aplicar////

            //switch (Opciones)
            //{
            //    case "Carnet":
            //        int carn = Convert.ToInt32(txtbuscar);
            //    var query1 = from carnet in c.Lista() where carnet.Carnet== carn select carnet;
            //    return View(query1.ToList());

            //    case "Nombre":
            //        var query2 = (from nomb in c.Lista() where nomb.Nombre.Contains(txtbuscar) select nomb);
            //        return View(query2.ToList());

            //    case "Materia":
            //        var query3 = (from mater in c.Lista() where mater.Materia.Contains(txtbuscar) select mater);
            //        return View(query3.ToList());

            //    case "Promedio":
            //        double prom = Convert.ToDouble(txtbuscar);
            //        var query4 = (from proMedio in c.Lista() where proMedio.Promedio == prom select proMedio);
            //        return View(query4.ToList());
            //}

            return View(query.ToList());
                       
        }
    }
}