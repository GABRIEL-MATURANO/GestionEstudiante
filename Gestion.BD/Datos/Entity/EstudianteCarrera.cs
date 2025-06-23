using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.BD.Datos.Entity
{
    public class EstudianteCarrera
    {
        public int EstudiantesID { get; set; }
        public required Estudiante Estudiantes { get; set; }

        public int CarrerasId { get; set; } 
        public required Carrera Carreras { get; set; }

    }
}
