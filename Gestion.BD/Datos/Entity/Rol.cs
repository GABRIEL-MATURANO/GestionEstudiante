using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.BD.Datos.Entity
{
    public class Rol
    {
        public int Id { get; set; }


        public required string Codigo { get; set; }


        [Required(ErrorMessage = "El campo del nombre de rol es obligatorio")]
        public required string NombreRol {  get; set; }

        public List<Usuario> Usuarios { get; set; } = new List<Usuario>();    

    }
}
