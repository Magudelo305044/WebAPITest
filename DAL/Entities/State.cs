using System.ComponentModel.DataAnnotations;

namespace WebAPITest.DAL.Entities
{
    public class State : AuditBase
    {

        [Display(Name = "Estado/Departamento")] //para identificar el nombre mas facil
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres")] //Longitud máxima
        [Required(ErrorMessage = " El campo {0} es obligatorio")] //Campo obligatorio
        public string Name { get; set; }

        //Asi es como relaciono dos tablas con EF Core
        [Display(Name = "Pais")] //para identificar el nombre mas facil
        public Country? Country { get; set; }

        //FK
        [Display(Name = "Id Pais")] //para identificar el nombre mas facil
        public Guid CountryId { get; set; }

    }
}
