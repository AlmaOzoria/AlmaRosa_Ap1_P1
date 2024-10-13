using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlmaRosa_Ap1_P1.Models
{
    public class CobroDetalle
    {
        [Key]
        [Required(ErrorMessage = "Debe de ser mayor que uno")]
        public int DetalleId { get; set; }

        [ForeignKey("cobro")]
        public int CobroId { get; set; }

        [ForeignKey("prestamo")]
        public int PrestamoId { get; set; }

        [Required(ErrorMessage = "Debe de ser mayor que uno")]
        public decimal ValorCobrado { get; set; }

            
            public Cobro? Cobro { get; set; }
            public Prestamo? Prestamo { get; set; }

    }
}
