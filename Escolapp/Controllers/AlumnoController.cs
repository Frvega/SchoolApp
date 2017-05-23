using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Escolapp.Models;

namespace Escolapp.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        public ActionResult Index()
        {
            using (var contexto = new EscuelaBd())
            {
                List<Alumno> lista = new List<Alumno>();
                var consulta = contexto.sp_ListarAlumno().Where(a => a.status_alumno == "Activo");

                foreach (var alumno in consulta)
                {
                    Alumno a = new Alumno();
                    a.id_alumno = alumno.id_alumno;
                    a.id_semestre = alumno.id_semestre;
                    a.id_especialidad = alumno.id_especialidad;
                    a.nombre_alumno = alumno.nombre_alumno;
                    a.apellido_alumno = alumno.apellido_alumno;
                    a.direccion_alumno = alumno.direccion_alumno;
                    a.edad_alumno = alumno.edad_alumno;
                    a.sexo_alumno = alumno.sexo_alumno;
                    a.telefono_alumno = alumno.telefono_alumno;
                    a.fecha_registro_alumno = alumno.fecha_registro_alumno;
                    a.status_alumno = alumno.status_alumno;

                    lista.Add(a);

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
        public ActionResult Registrar(int id_semestre, int id_especialidad, string nombre_alumno, string apellido_alumno, string direccion_alumno, int edad_alumno, string sexo_alumno, string telefono_alumno, string status_alumno)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                using (var contexto = new EscuelaBd())
                {
                    Alumno a = new Alumno();
                    contexto.sp_InsertarAlumno(a.id_semestre = id_semestre, a.id_especialidad = id_especialidad, a.nombre_alumno = nombre_alumno, a.apellido_alumno = apellido_alumno, a.direccion_alumno = direccion_alumno, a.edad_alumno = edad_alumno, a.sexo_alumno = sexo_alumno, a.telefono_alumno = telefono_alumno, a.status_alumno = status_alumno);
                    return RedirectToAction("index");

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al Registrar el Alumno, Valide los campos", ex);
                return View();
            }
        }

        public string ObtenerNombre(int id)
        {
            using (var contexto = new EscuelaBd()) {
                var nombre = contexto.Alumno.Find(id).nombre_alumno.ToString();
                return nombre;
            }

           
        }
    }
}