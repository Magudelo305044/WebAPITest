﻿using System.ComponentModel.DataAnnotations;

namespace WebAPITest.DAL.Entities
{
    public class Country : AuditBase
    {
        [Display(Name = "Pais")] //para identificar el nombre mas facil
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres")] //Longitud máxima
        [Required(ErrorMessage = " El campo {0} es obligatorio")] //Campo obligatorio
        public string Name { get; set; }

        public ICollection<Country> Countries { get; set; }
        public List<State> States { get; internal set; }
    }
}
