using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.BD.Datos.Entity
{
    [Index(nameof(Legajo), Name = "Legajo_UQ", IsUnique = true)]
    public class Estudiante
    {
        public int Id { get; set; }

        public int PersonaId { get; set; }
        public Persona? Personas { get; set; } 


        [Required(ErrorMessage = "El campo del legajo es obligatorio")]
        public required int Legajo { get; set; }


        //agrego la referencia a la tabla porque es mucho a muchos 
        public List<EstudianteCarrera> EstudiantesCarreras { get; set; } = new();
    }
}
