using AlmaRosa_Ap1_P1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;

namespace AlmaRosa_Ap1_P1.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public DbSet<Registro> Registros { get; set; }
}
