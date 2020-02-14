using System.Threading.Tasks;

namespace TesteGol.Model.Services
{
    public interface IAutheticationService
    {
        Task<object> Authenticate(string login, string password);
    }
}
