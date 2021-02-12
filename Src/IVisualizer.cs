using prehdo.Console.Entities;
using System.Threading.Tasks;

namespace prehdo.Console
{
    public interface IVisualizer
    {
        Task VizualizeAsync(Hdo hdo);
    }
}