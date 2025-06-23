using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.BD.Datos.Entity
{
    [Index(nameof(DNI), Name = "DNI_UQ", IsUnique = true)]
    [Index(nameof(Telefono), Name = "Telefono_UQ", IsUnique = true)]
    [Index(nameof(CorreoElec), Name = "CorreoElectronico_UQ", IsUnique = true)]
    public class Persona

    {
        public int Id {  get; set; }
 

        [Required(ErrorMessage = "El campo del nombre es obligatorio")]
        [MaxLength(30, ErrorMessage = "El nombre no puede exceder los 30 caracteres")]
        public required string Nombre { get; set; }


        [Required(ErrorMessage = "El campo del apellido es obligatorio")]
        [MaxLength(30, ErrorMessage = "El apellido no puede exceder los 30 caracteres")]
        public required string Apellido { get; set; }


        [Required(ErrorMessage = "El campo del DNI es obligatorio")]
        public int DNI { get; set; }


        [Required(ErrorMessage = "El campo de la fecha de nacimiento es obligatorio")]
        public DateTime FechaNac {  get; set; }


        [Required(ErrorMessage = "El campo del correo electronico es obligatorio")]
        [MaxLength(30, ErrorMessage = "El correo electronico no puede exceder los 30 caracteres")]
        public required string CorreoElec { get; set; }


        [Required(ErrorMessage = "El campo del sexo es obligatorio")]
        [MaxLength(10, ErrorMessage = "El sexo no puede exceder los 10 caracteres")]
        public required string Sexo {  get; set; }


        [Required(ErrorMessage = "El campo del telefono es obligatorio")]
        [MaxLength(30, ErrorMessage = "El telefono no puede exceder los 30 caracteres")]
        public required string Telefono { get; set; }

        public int UsuarioId { get; set; }
        public Usuario? Usuarios { get; set; } // Relación con Usuario

        

        public int EstudianteId { get; set; }
        public Estudiante? Estudiantes { get; set; } // Relación con Estudiante


    }
}
