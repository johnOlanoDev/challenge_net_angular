using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientesApi.Repositories
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> SearchAsync(string? query);
        Task<Cliente?> GetByIdAsync(long id);
        Task<Cliente> CreateAsync(Cliente cliente);
        Task UpdateAsync(Cliente cliente);
        Task DeleteAsync(long id);
        Task<IEnumerable<Cliente>> TestQueryAsync();
    }
}