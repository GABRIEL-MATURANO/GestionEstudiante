using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.BD.Datos.Entity
{
    [Index(nameof(NombreUsuario), Name = "NombreUsuario_UQ", IsUnique = true)]
    
    public class Usuario
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "El campo del nombre de usuario es obligatorio")]
        [MaxLength(30, ErrorMessage = "El nombre de usuario no puede exceder los 30 caracteres")]
        public required string NombreUsuario { get; set; }


        [Required(ErrorMessage = "El campo de la contraseña es obligatorio")]
        [MaxLength(15, ErrorMessage = "La contraseña no puede exceder los 15 caracteres")]
        public required string Contraseña { get; set; }

        public int PersonaId  { get; set; }   
        public Persona? Personas { get; set; }

        public int RolId { get; set; }

        public Rol? Rols { get; set; }

        

    }
}
