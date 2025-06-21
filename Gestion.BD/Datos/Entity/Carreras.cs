using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.BD.Datos.Entity
{
    [Index(nameof(NombreC), Name = "NombreCarrera_UQ", IsUnique = true)]
    public class Carreras
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "El campo del nombre de la carrera es obligatorio")]
        public required string NombreC { get; set; }


        //agrego la referencia a la tabla porque es mucho a muchos 
        public List<EstudiantesCarreras> EstudiantesCarreras { get; set; } = new();
    }
}
