using System.ComponentModel.DataAnnotations;

namespace AlmaRosa_Ap1_P1.Models;

public class Prestamo
{
    [Key]
    [Required (ErrorMessage = "Debe de ser mayor que uno")]
    public int PrestamoId { get; set; }

    [Required (ErrorMessage = "Este Campo es obligatorio")]
    public string Deudor { get; set; }

    [Required (ErrorMessage = "Este Campo es obligatorio")]
    public string Concepto { get; set; }

    [Required (ErrorMessage = "Este Campo es obligatorio")]
    public decimal Monto { get; set; }
}
