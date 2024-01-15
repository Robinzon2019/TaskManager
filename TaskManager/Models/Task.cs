using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    public class Task
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string? Descripcion { get; set; }
        
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateTime? FechaCreacion { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string? Estado { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int Prioridad { get; set; }
    }
}
