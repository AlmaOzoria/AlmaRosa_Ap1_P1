using System.ComponentModel.DataAnnotations;

namespace AlmaRosa_Ap1_P1.Models
{
    public class Deudores
    {
        [Key]
        [Required(ErrorMessage = "Debe de ser mayor que uno")]
        public int DeudorId { get; set; }

        [Required(ErrorMessage = "Debe de ser mayor que uno")]
        public string Nombres { get; set; }

        public ICollection<Prestamo> Prestamos { get; set; }

    }
}
