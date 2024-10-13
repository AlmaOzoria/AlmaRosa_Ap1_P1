using AlmaRosa_Ap1_P1.DAL;
using AlmaRosa_Ap1_P1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AlmaRosa_Ap1_P1.Services
{
    public class PrestamoServices
    {

        private readonly Contexto _contexto;
        public PrestamoServices(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> Existe(int prestamoId)
        {
            return await _contexto.Prestamos.AnyAsync(p => p.PrestamoId == prestamoId);
        }

        private async Task<bool> Insertar(Prestamo prestamo)
        {
            _contexto.Prestamos.Add(prestamo);
            return await _contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Prestamo prestamo)
        {
                var prestamoExistente = await _contexto.Prestamos
           .AsNoTracking()
           .FirstOrDefaultAsync(p => p.PrestamoId == prestamo.PrestamoId);

            if (prestamoExistente == null)
            {
                return false;
            }
            _contexto.Entry(prestamo).State = EntityState.Modified;

            var modificado = await _contexto.SaveChangesAsync() > 0;

            return modificado;
        }

        public async Task<Prestamo?> Buscar(int id)
        {
            return await _contexto.Prestamos
            .Include(p => p.deudores)
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.PrestamoId == id);
        }

        public async Task<bool> Guardar(Prestamo prestamo)
        {
            if (!await Existe(prestamo.PrestamoId))
                return await Insertar(prestamo);
            else
                return await Modificar(prestamo);
        }

        public async Task<bool> Eliminar(int id)
        {
            var EliminarPrestamo = await _contexto.Prestamos
            .Where(p => p.PrestamoId == id)
            .ExecuteDeleteAsync();
            return EliminarPrestamo > 0;
        }

        public async Task<List<Prestamo>> Listar(Expression<Func<Prestamo, bool>> criterio)
        {
            return await _contexto.Prestamos
            .AsNoTracking()
            .Include(p => p.deudores)
            .Where(criterio)
            .ToListAsync();
        }

        public async Task<List<Deudores>> ObtenerDeudores()
        {
            return await _contexto.Deudores.ToListAsync();
        }

    }
}
