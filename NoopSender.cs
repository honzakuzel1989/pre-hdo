using prehdo.Entities;
using System.Threading.Tasks;

namespace prehdo
{
    class NoopSender : ISender
    {
        public Task SendAsync(HdoDto hdo)
        {
            return Task.CompletedTask;
        }
    }
}