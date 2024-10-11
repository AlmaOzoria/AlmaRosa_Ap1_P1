using AlmaRosa_Ap1_P1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;

namespace AlmaRosa_Ap1_P1.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public DbSet<Prestamo> Prestamos { get; set; }
    public DbSet<Deudores> Deudores { get; set; }
    public DbSet<Cobro> Cobros { get; set; }
    public DbSet<CobroDetalle> CobroDetalles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Deudores>().HasData(
            new Deudores
            {
                DeudorId = 1,
                Nombres = "Deudor A"
            },
            new Deudores
            {
                DeudorId = 2,
                Nombres = "Deudor B"
            }
        );

        modelBuilder.Entity<Prestamo>().HasData(
            new Prestamo
            {
                PrestamoId = 1,
                DeudorId = 1, 
                Concepto = "Carro",
                Monto = 5000m,
                Balance = 3000m
            },
            new Prestamo
            {
                PrestamoId = 2,
                DeudorId = 2,
                Concepto = "Carro",
                Monto = 7000m,
                Balance = 5000m
            }
        );

        modelBuilder.Entity<Cobro>().HasData(
            new Cobro
            {
                CobroId = 1,
                Fecha = new DateTime(2024, 10, 11),
                DeudorId = 1,  
                Monto = 2000m
            },
            new Cobro
            {
                CobroId = 2,
                Fecha = new DateTime(2023, 10, 5),
                DeudorId = 2,  
                Monto = 3000m
            }
        );

        modelBuilder.Entity<CobroDetalle>().HasData(
            new CobroDetalle
            {
                DetalleId = 1,
                CobroId = 1,  
                PrestamoId = 1,  
                ValorCobrado = 1000m
            },
            new CobroDetalle
            {
                DetalleId = 2,
                CobroId = 2,  
                PrestamoId = 2,  
                ValorCobrado = 2000m
            }
        );
    }
}
