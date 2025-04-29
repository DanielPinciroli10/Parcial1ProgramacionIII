using System.ComponentModel.DataAnnotations;

namespace Parcial1DanielPinciroli
{
    public class Disciplinas
    {
        [Key]
        public int IDDisciplina { get; set; }
        [Required]
        public string? Nombre { get; set; }
    }
}
