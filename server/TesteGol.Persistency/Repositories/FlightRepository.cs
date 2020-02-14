using TesteGol.Model.Entities;
using TesteGol.Model.Repositories;
using TesteGol.Persistency.Context;
using TesteGol.Persistency.Repositories.Base;

namespace TesteGol.Persistency.Repositories
{
    public class FlightRepository : RepositoryBase<Flight, DefaultContext>, IFlightRepository
    {
        public FlightRepository(DefaultContext context) : base(context)
        {
        }
    }
}
