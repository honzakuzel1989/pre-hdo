using prehdo.Console.Entities;
using System.Threading.Tasks;

namespace prehdo.Console
{
    internal interface IParser
    {
        Task<Hdo> ParseAsync(string page);
    }
}