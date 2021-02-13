using prehdo.Console.Entities;
using System.Threading.Tasks;

namespace prehdo.Core.Services
{
    public interface IParser
    {
        Task<Hdo> ParseAsync(string page);
    }
}