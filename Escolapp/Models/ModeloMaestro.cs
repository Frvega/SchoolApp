using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Escolapp.Models
{
    public class ModeloMaestro
    {
        [Display(Name = "Id")]
        public int id_maestro { get; set; }

        [Display(Name = "Nombres")]
        [Required(ErrorMessage = "Nombre Obligatorio")]
        [StringLength(50, ErrorMessage = "No más de 50 caracteres")]
        public string nombre_maestro { get; set; }

        [Display(Name = "Apellidos")]
        [Required(ErrorMessage = "Apellidos Obligatorios")]
        [StringLength(50, ErrorMessage = "No más de 50 caracteres")]
        public string apellido_maestro { get; set; }

        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "Dirección Obligatorio")]
        [StringLength(50, ErrorMessage = "No más de 100 caracteres")]
        public string direccion_maestro { get; set; }

        [Display(Name = "Edad")]
        [Required(ErrorMessage = "Edad Obligatoria")]
        public int edad_maestro { get; set; }

        [Display(Name = "Sexo")]
        [Required(ErrorMessage = "Sexo Obligatorio")]
        [StringLength(50, ErrorMessage = "No más de 10 caracteres")]
        public string sexo_maestro { get; set; }

        [Display(Name = "Teléfono")]
        [Required(ErrorMessage = "Teléfono Obligatorio")]
        [StringLength(50, ErrorMessage = "No más de 10 caracteres")]
        public string telefono_maestro { get; set; }

        [Display(Name = "Registro")]
        public System.DateTime fecha_registro_maestro { get; set; }

        [Display(Name = "Situación")]
        public string status_maestro { get; set; }

    }
    [MetadataType(typeof(ModeloMaestro))]
    public partial class Maestro
    {

    }
}