using MvcNetCoreEFMultiplesBBDD.Models;
using System.Threading.Tasks;

namespace MvcNetCoreEFMultiplesBBDD.Repositories
{
    public interface IRepositoryEmpleados
    {
        Task<List<EmpleadoView>> GetEmpleadosAsync();
        Task<EmpleadoView> FindEmpleadoAsync(int idEmpleado);
    }
}
