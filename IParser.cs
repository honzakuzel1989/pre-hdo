using prehdo.Entities;
using System.Threading.Tasks;

namespace prehdo
{
    internal interface IParser
    {
        Task<Hdo> ParseAsync(string page);
    }
}