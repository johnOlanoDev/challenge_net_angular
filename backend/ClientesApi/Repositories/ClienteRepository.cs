using ClientesApi.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientesApi.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ClientesDbContext _context;

        public ClienteRepository(ClientesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> SearchAsync(string? query)
        {
            var q = _context.Clientes.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query))
            {
                var filter = query.ToUpper();

                q = q.Where(c =>
                    (c.Ruc != null && c.Ruc.ToUpper().Contains(filter)) ||
                    (c.RazonSocial != null && c.RazonSocial.ToUpper().Contains(filter))
                );
            }

            return await q.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Cliente>> TestQueryAsync()
        {
            return await _context.Clientes
                .FromSqlRaw("SELECT ID, RUC, RAZON_SOCIAL, TELEFONO_CONTACTO, CORREO_CONTACTO, DIRECCION FROM CLIENTES")
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Cliente?> GetByIdAsync(long id) => await _context.Clientes.FindAsync(id);

        public async Task<Cliente> CreateAsync(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task UpdateAsync(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var c = await _context.Clientes.FindAsync(id);
            if (c != null)
            {
                _context.Clientes.Remove(c);
                await _context.SaveChangesAsync();
            }
        }
    }
}