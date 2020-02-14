using System;
using System.Linq;
using System.Threading.Tasks;
using TesteGol.Model.Entities;

namespace TesteGol.Model.Repositories
{
    public interface IFlightRepository
    {
        Task Create(Flight flight);
        Task Update(Guid id, Flight flight);
        Task Delete(Guid id);
        Task<IQueryable<Flight>> GetAll();
        Task<Flight> GetById(Guid id);
    }
}
