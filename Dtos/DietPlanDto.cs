using System.ComponentModel.DataAnnotations;

namespace AgendaNutricionistaApi.Dtos
{
    public class DietPlanDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El título del plan es obligatorio.")]
        [StringLength(150, ErrorMessage = "El título no puede exceder los 150 caracteres.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debe especificar el ID del paciente.")]
        public int PatientId { get; set; }
    }
}
