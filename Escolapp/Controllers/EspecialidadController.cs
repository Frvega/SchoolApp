using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Escolapp.Models;

namespace Escolapp.Controllers
{
    public class EspecialidadController : Controller
    {
        // GET: Especialidad
        public ActionResult Index()
        {
            using (var contexto = new EscuelaBd())
            {
                List<Especialidad> lista = new List<Especialidad>();
                var consulta = contexto.sp_ListarEspecialidades().Where(es => es.status_especialidad == "Activo");

                foreach (var especialidad in consulta)
                {
                    Especialidad e = new Especialidad();
                    e.id_especialidad = especialidad.id_especialidad;
                    e.nombre_especialidad = especialidad.nombre_especialidad;
                    e.status_especialidad = especialidad.status_especialidad;

                    lista.Add(e);

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
        public ActionResult Registrar(string nombre_especialidad, string status_especialidad)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                using (var contexto = new EscuelaBd())
                {
                    Especialidad e = new Especialidad();
                    contexto.sp_InsertarEspecialidad(e.nombre_especialidad = nombre_especialidad, e.status_especialidad = status_especialidad);
                    return RedirectToAction("index");

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al Registrar la Especialidad, Valide los campos", ex);
                return View();
            }
        }


        public ActionResult Detalles(int id)
        {
            try
            {
                using (var contexto = new EscuelaBd())
                {
                    Especialidad e = contexto.Especialidad.Find(id);
                    return View(e);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public ActionResult Baja(int id)
        {
            try
            {
                using (var contexto = new EscuelaBd())
                {
                    Especialidad e = contexto.Especialidad.Find(id);
                    contexto.sp_BajaEspecialidad(e.id_especialidad);
                    contexto.SaveChanges();
                    return RedirectToAction("index");
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public ActionResult Alta(int id)
        {
            try
            {
                using (var contexto = new EscuelaBd())
                {
                    Especialidad e = contexto.Especialidad.Find(id);
                    contexto.sp_AltaEspecialidad(e.id_especialidad);
                    contexto.SaveChanges();
                    return RedirectToAction("index");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }



        public ActionResult Inhabilitado()
        {

            using (var contexto = new EscuelaBd())
            {
                List<Especialidad> lista = new List<Especialidad>();
                var consulta = contexto.sp_ListarEspecialidades().Where(es => es.status_especialidad == "Inactivo");

                foreach (var especialidad in consulta)
                {
                    Especialidad e = new Especialidad();
                    e.id_especialidad = especialidad.id_especialidad;
                    e.nombre_especialidad = especialidad.nombre_especialidad;
                    e.status_especialidad = especialidad.status_especialidad;

                    lista.Add(e);

                }

                return View(lista);
            }
        }


        [HttpGet]
        public ActionResult Editar(int id)
        {
            try
            {
                using (var contexto = new EscuelaBd())
                {
                    Especialidad e = contexto.Especialidad.Find(id);
                    return View(e);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Especialidad especialidad, int id_especialidad, string nombre_especialidad, string estado_especialidad)
        {
            try
            {
                using (var contexto = new EscuelaBd())
                {
                    Especialidad e = contexto.Especialidad.Find(especialidad.id_especialidad);
                    contexto.sp_EditarEspecialidad(e.id_especialidad = id_especialidad, e.nombre_especialidad = nombre_especialidad);
                    contexto.SaveChanges();
                    return RedirectToAction("index");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }



    }
}