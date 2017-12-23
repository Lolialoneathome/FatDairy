using FatDairy.Domain.Models;
using System.Threading.Tasks;

namespace FatDairy.Domain.Repos
{
    public interface IFattyRepository
    {
        Task AddFatty(Fatty fatty);

        Task<Fatty> GetById(int id);

        Task<Fatty> GetByEmail(string email);
    }
}
