using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Escolapp.Models;

namespace Escolapp.Views
{
    public class CursoAlumnoesController : Controller
    {
        private EscuelaBd db = new EscuelaBd();

        // GET: CursoAlumnoes
        public ActionResult Index()
        {
            var cursoAlumno = db.CursoAlumno.Include(c => c.Alumno).Include(c => c.Curso);
            return View(cursoAlumno.ToList());
        }

        // GET: CursoAlumnoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CursoAlumno cursoAlumno = db.CursoAlumno.Find(id);
            if (cursoAlumno == null)
            {
                return HttpNotFound();
            }
            return View(cursoAlumno);
        }

        // GET: CursoAlumnoes/Create
        public ActionResult Create()
        {
            ViewBag.id_alumno = new SelectList(db.Alumno, "id_alumno", "nombre_alumno");
            ViewBag.id_curso = new SelectList(db.Curso, "id_curso", "status_curso");
            return View();
        }

        // POST: CursoAlumnoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_cursoalumno,id_curso,id_alumno,status_cursoAlumno")] CursoAlumno cursoAlumno)
        {
            if (ModelState.IsValid)
            {
                db.CursoAlumno.Add(cursoAlumno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_alumno = new SelectList(db.Alumno, "id_alumno", "nombre_alumno", cursoAlumno.id_alumno);
            ViewBag.id_curso = new SelectList(db.Curso, "id_curso", "status_curso", cursoAlumno.id_curso);
            return View(cursoAlumno);
        }

        // GET: CursoAlumnoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CursoAlumno cursoAlumno = db.CursoAlumno.Find(id);
            if (cursoAlumno == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_alumno = new SelectList(db.Alumno, "id_alumno", "nombre_alumno", cursoAlumno.id_alumno);
            ViewBag.id_curso = new SelectList(db.Curso, "id_curso", "status_curso", cursoAlumno.id_curso);
            return View(cursoAlumno);
        }

        // POST: CursoAlumnoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_cursoalumno,id_curso,id_alumno,status_cursoAlumno")] CursoAlumno cursoAlumno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cursoAlumno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_alumno = new SelectList(db.Alumno, "id_alumno", "nombre_alumno", cursoAlumno.id_alumno);
            ViewBag.id_curso = new SelectList(db.Curso, "id_curso", "status_curso", cursoAlumno.id_curso);
            return View(cursoAlumno);
        }

        // GET: CursoAlumnoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CursoAlumno cursoAlumno = db.CursoAlumno.Find(id);
            if (cursoAlumno == null)
            {
                return HttpNotFound();
            }
            return View(cursoAlumno);
        }

        // POST: CursoAlumnoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CursoAlumno cursoAlumno = db.CursoAlumno.Find(id);
            db.CursoAlumno.Remove(cursoAlumno);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
