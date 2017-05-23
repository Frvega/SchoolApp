using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Escolapp.Models;

namespace Escolapp.Controllers
{
    public class MaestroController : Controller
    {
        // GET: Maestro
        public ActionResult Index()
        {
            using (var contexto = new EscuelaBd())
            {
                List<Maestro> lista = new List<Maestro>();
                var consulta = contexto.sp_ListarMaestro().Where(m => m.status_maestro == "Activo");

                foreach (var maestro in consulta)
                {
                    Maestro m = new Maestro();
                    m.id_maestro = maestro.id_maestro;
                    m.nombre_maestro = maestro.nombre_maestro;
                    m.apellido_maestro = maestro.apellido_maestro;
                    m.direccion_maestro = maestro.direccion_maestro;
                    m.edad_maestro = maestro.edad_maestro;
                    m.sexo_maestro = maestro.sexo_maestro;
                    m.telefono_maestro = maestro.telefono_maestro;
                    m.fecha_registro_maestro = maestro.fecha_registro_maestro;
                    m.status_maestro = maestro.status_maestro;

                    lista.Add(m);

                }
                return View(lista);
            }
        }



        [HttpGet]
        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registrar(string nombre_maestro, string apellido_maestro, string direccion_maestro, int edad_maestro, string sexo_maestro, string telefono_maestro, string status_maestro)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                using (var contexto = new EscuelaBd())
                {
                    Maestro m = new Maestro();
                    contexto.sp_InsertarMaestro(m.nombre_maestro = nombre_maestro, m.apellido_maestro = apellido_maestro, m.direccion_maestro = direccion_maestro, m.edad_maestro = edad_maestro, m.sexo_maestro = sexo_maestro, m.telefono_maestro = telefono_maestro, m.status_maestro = status_maestro);
                    return RedirectToAction("index");

                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("Error al Registar al Maestro, Valide los campos", ex);
                return View();

            }
        }


        public ActionResult Detalles(int id)
        {
            try
            {
                using (var contexto = new EscuelaBd())
                {
                    Maestro m = contexto.Maestro.Find(id);
                    return View(m);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }



    }
}