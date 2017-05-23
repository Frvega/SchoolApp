using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Escolapp.Models
{
    public class ModeloAlumno
    {

        [Display(Name = "Matrícula")]
        public int id_alumno { get; set; }

        [Display(Name = "Semestre")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        [StringLength(50, ErrorMessage = "No más de 1 caracter")]
        public int id_semestre { get; set; }

        [Display(Name = "Especialidad")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        [StringLength(50, ErrorMessage = "No más de 1 caracter")]
        public int id_especialidad { get; set; }

        [Display(Name = "Nombres")]
        [Required(ErrorMessage = "Nombre Obligatorio")]
        [StringLength(50, ErrorMessage = "No más de 50 caracteres")]
        public string nombre_alumno { get; set; }

        [Display(Name = "Apellidos")]
        [Required(ErrorMessage = "Apellidos Obligatorio")]
        [StringLength(50, ErrorMessage = "No más de 50 caracteres")]
        public string apellido_alumno { get; set; }

        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "Dirección Obligatoria")]
        [StringLength(50, ErrorMessage = "No más de 100 caracteres")]
        public string direccion_alumno { get; set; }

        [Display(Name = "Edad")]
        [Required(ErrorMessage = "Edad Obligatoria")]
        public int edad_alumno { get; set; }

        [Display(Name = "Sexo")]
        [Required(ErrorMessage = "Sexo Obligatorio")]
        [StringLength(50, ErrorMessage = "No más de 10 caracteres")]
        public string sexo_alumno { get; set; }

        [Display(Name = "Telefono")]
        [Required(ErrorMessage = "Telefono Obligatorio")]
        [StringLength(50, ErrorMessage = "No más de 10 caracteres")]
        public string telefono_alumno { get; set; }

        [Display(Name = "Registro")]
        public System.DateTime fecha_registro_alumno { get; set; }

        [Display(Name = "Situación")]
        public string status_alumno { get; set; }

    }

    [MetadataType(typeof(ModeloAlumno))]
    public partial class Alumno
    {

    }
}