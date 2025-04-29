using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Parcial1DanielPinciroli
{
    public class Participantes
    {
        [Key]
        public int IDParticipante { get; set; }
        [Required]
        public string? Nombre { get; set; }
        [Required]
        public int IDDisciplina { get; set; }
        [Range(0, int.MaxValue, ErrorMessage ="La edad debe ser mayor o igual a 0")]
        public int Edad {  get; set; }
        [Required]
        [DisplayName("Ciudad de Residencia")]
        public string? CiudadResidencia { get; set; }

        public Disciplinas? disciplinas { get; set; }
    }
}
