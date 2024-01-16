using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    public class Task
    {
        [Display(Name = "Número")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Descripción")]
        public string? Descripcion { get; set; }
        
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        
        [Display(Name = "Fecha de Creación")]
        public DateTime? FechaCreacion { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string? Estado { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int? Prioridad { get; set; }
    }
}
