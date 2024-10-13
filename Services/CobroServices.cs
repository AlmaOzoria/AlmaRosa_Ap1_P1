using AlmaRosa_Ap1_P1.DAL;
using AlmaRosa_Ap1_P1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AlmaRosa_Ap1_P1.Services;

public class CobroServices
{
   

        private readonly Contexto _contexto;
        public CobroServices(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> Existe(int CobroId)
        {
            return await _contexto.Cobros.AnyAsync(c => c.CobroId == CobroId);
        }

        private async Task<bool> Insertar(Cobro cobro)
        {
            _contexto.Cobros.Add(cobro);
            return await _contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Cobro cobro)
        {
            var cobroExistente = await _contexto.Cobros
           .AsNoTracking()
           .FirstOrDefaultAsync(c => c.CobroId == cobro.CobroId);

            if (cobroExistente == null)
            {
                return false;
            }
            _contexto.Entry(cobro).State = EntityState.Modified;

            var modificado = await _contexto.SaveChangesAsync() > 0;

            return modificado;
        }

        public async Task<Cobro?> Buscar(int id)
        {
            return await _contexto.Cobros
            .Include(p => p.deudores)
            .Include(p => p.CobrosDetalles)
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.CobroId == id);
        }

        public async Task<bool> Guardar(Cobro cobro)
        {
            if (!await Existe(cobro.CobroId))
                return await Insertar(cobro);
            else
                return await Modificar(cobro);
        }

        public async Task<bool> Eliminar(int id)
        {
            var EliminarCobro = await _contexto.Cobros
            .Where(c => c.CobroId == id)
            .ExecuteDeleteAsync();
            return EliminarCobro > 0;
        }

        public async Task<List<Cobro>> Listar(Expression<Func<Cobro, bool>> criterio)
        {
            return await _contexto.Cobros
            .AsNoTracking()
            .Include(p => p.deudores)
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



