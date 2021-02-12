using prehdo.Console.Entities;
using System.Threading.Tasks;

namespace prehdo.Console
{
    internal interface ISender
    {
        Task SendAsync(Hdo hdo);
    }
}