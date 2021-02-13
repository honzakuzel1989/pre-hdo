using prehdo.Console.Entities;
using System.Threading.Tasks;

namespace prehdo.Console
{
    public interface IParser
    {
        Task<Hdo> ParseAsync(string page);
    }
}