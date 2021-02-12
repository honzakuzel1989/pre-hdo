using prehdo.Entities;
using System.Threading.Tasks;

namespace prehdo
{
    public interface IVisualizer
    {
        Task VizualizeAsync(HdoDto hdo);
    }
}