using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Escolapp.Models
{
    public class ModeloEspecialidad
    {
        [Display(Name = "Id")]
        public int id_especialidad { get; set; }

        [Display(Name = "Carrera")]
        [Required(ErrorMessage = "Nombre Obligatorio")]
        [StringLength(50, ErrorMessage = "No más de 50 caracteres")]
        public string nombre_especialidad { get; set; }

        [Display(Name = "Situación")]
        [Required(ErrorMessage = "Status Obligatorio")]
        [StringLength(10, ErrorMessage = "No más de 50 caracteres")]
        public string status_especialidad { get; set; }
    }

    [MetadataType(typeof(ModeloEspecialidad))]
    public partial class Especialidad
    {

    }
}