using System.ComponentModel.DataAnnotations;

namespace Parcial1DanielPinciroli
{
    public class CantidadRegistrados
    {
        [Key]
        public int IDRegistrados { get; set; }
        [Required]
        public string? NombreDisciplina { get; set; }
        public int Cantidad { get; set; }
    }
}
