using Escolapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Escolapp.Controllers
{
    public class CursoAlumnoController : Controller
    {
        // GET: CursoAlumno
        public ActionResult Index()
        {
            using (var contexto = new EscuelaBd())
            {
                List<CursoAlumno> lista = new List<CursoAlumno>();
                var consulta = contexto.sp_ListarCursosAlumno().Where(ca => ca.status_cursoAlumno == "Activo");

                foreach (var cursoalumno in consulta)
                {
                    CursoAlumno ca = new CursoAlumno();
                    ca.id_cursoalumno = cursoalumno.id_cursoalumno;
                    
                    ca.id_alumno = cursoalumno.id_alumno;
                    ca.id_curso = cursoalumno.id_curso;
                    ca.status_cursoAlumno = cursoalumno.status_cursoAlumno;
                    //maestro m = new maestro();
                    //m.id_maestro = cursoalumno.;
                    //m.nombre_maestro = cursoalumno.nombre_maestro;
                    //m.apellido_maestro = cursoalumno.apellido_maestro;
                    //m.direccion_maestro = cursoalumno.direccion_maestro;
                    //m.edad_maestro = cursoalumno.edad_maestro;
                    //m.sexo_maestro = cursoalumno.sexo_maestro;
                    //m.telefono_maestro = cursoalumno.telefono_maestro;
                    //m.fecha_registro_maestro = cursoalumno.fecha_registro_maestro;
                    //m.status_maestro = cursoalumno.status_maestro;

                    lista.Add(ca);

                }
                return View(lista);
            }

            
        }

        [HttpGet]
        public ActionResult Registrar()
        {
            var context = new EscuelaBd();
            ViewBag.id_alumno = new SelectList(context.Alumno, "id_alumno", "nombre_alumno");
            ViewBag.id_curso = new SelectList(context.Curso, "id_curso", "status_curso");
            //context.Dispose();
            return View();
        }
            
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registrar(int id_curso,int id_alumno,string status_cursoalumno)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                using(var contexto = new EscuelaBd())
                {
                    try
                    {
                    CursoAlumno ca = new CursoAlumno();
                    contexto.sp_CrearCursoAlumno(ca.id_curso = id_curso, ca.id_alumno = id_alumno, ca.status_cursoAlumno = status_cursoalumno);
                    ViewBag.id_alumno = new SelectList(contexto.Alumno, "id_alumno", "nombre_alumno");
                    ViewBag.id_curso = new SelectList(contexto.Curso, "id_curso", "status_curso");
                    return RedirectToAction("Index");
                    }catch(Exception ex)
                    {
                        return View();
                    }
                    
                }
            }catch(Exception ex)
            {
                ModelState.AddModelError("Error al Registar al Maestro, Valide los campos", ex);
                return View();
            }
            //return null;
            
        }
    }
}