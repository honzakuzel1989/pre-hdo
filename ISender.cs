using prehdo.Entities;
using System.Threading.Tasks;

namespace prehdo
{
    internal interface ISender
    {
        Task SendAsync(HdoDto hdo);
    }
}