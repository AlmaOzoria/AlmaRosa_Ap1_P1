using AlmaRosa_Ap1_P1.DAL;
using AlmaRosa_Ap1_P1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AlmaRosa_Ap1_P1.Services;

public class CobroDetalleServices
{
    private readonly Contexto _contexto;
    public CobroDetalleServices(Contexto contexto)
    {
        _contexto = contexto;
    }

    public async Task<bool> Existe(int DetalleId)
    {
        return await _contexto.CobroDetalles.AnyAsync(c => c.DetalleId == DetalleId);
    }

    private async Task<bool> Insertar(CobroDetalle cobroDetalle)
    {
        _contexto.CobroDetalles.Add(cobroDetalle);
        return await _contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(CobroDetalle cobroDetalle)
    {
        var cobroDetalleExistente = await _contexto.CobroDetalles
       .AsNoTracking()
       .FirstOrDefaultAsync(c => c.DetalleId == cobroDetalle.DetalleId);

        if (cobroDetalleExistente == null)
        {
            return false;
        }
        _contexto.Entry(cobroDetalle).State = EntityState.Modified;

        var modificado = await _contexto.SaveChangesAsync() > 0;

        return modificado;
    }

    public async Task<CobroDetalle?> Buscar(int id)
    {
        return await _contexto.CobroDetalles
        .AsNoTracking()
        .Include(c => c.Prestamo)
        .FirstOrDefaultAsync(c => c.DetalleId == id);
    }

    public async Task<bool> Guardar(CobroDetalle cobroDetalle)
    {
        if (!await Existe(cobroDetalle.DetalleId))
            return await Insertar(cobroDetalle);
        else
            return await Modificar(cobroDetalle);
    }

    public async Task<bool> Eliminar(int id)
    {
        var EliminarCobroDetalle = await _contexto.CobroDetalles
        .Where(c => c.DetalleId == id)
        .ExecuteDeleteAsync();
        return EliminarCobroDetalle > 0;
    }

    public async Task<List<CobroDetalle>> Listar(Expression<Func<CobroDetalle, bool>> criterio)
    {
        return await _contexto.CobroDetalles
        .AsNoTracking()
        .Include(c => c.Cobro)
        .Include(c => c.Prestamo)
        .Where(criterio)
        .ToListAsync();
    }


    public async Task<List<Deudores>> ObtenerDeudores()
    {

        return await _contexto.Deudores.ToListAsync();

    }
    public async Task<List<Prestamo>> ObtenerPrestamo()
    {

        return await _contexto.Prestamos.ToListAsync();

    }
}
