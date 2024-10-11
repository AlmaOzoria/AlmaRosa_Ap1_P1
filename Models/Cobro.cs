using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlmaRosa_Ap1_P1.Models;

public class Cobro
{
    [Key]
    [Required(ErrorMessage = "Debe de ser mayor que uno")]
    public int CobroId { get; set; }

    [Required(ErrorMessage = "Debe de ser mayor que uno")]
    public DateTime Fecha { get; set; }

    [ForeignKey( "deudores")]
    public int DeudorId { get; set; }

    [Required(ErrorMessage = "Debe de ser mayor que uno")]
    public decimal Monto { get; set; }


      public Deudores? deudores { get; set; }

      public ICollection<CobroDetalle>? CobrosDetalles { get; set; }

}
