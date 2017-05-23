using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Escolapp.Models
{
    public class ModeloCursoAlumno
    {
        public int id_cursoalumno { get; set; }
        public int id_curso { get; set; }
        public int id_alumno { get; set; }
        public string status_cursoAlumno { get; set; }

        public virtual Alumno Alumno { get; set; }
        public virtual Curso Curso { get; set; }
    }
}