using prehdo.Entities;
using System.Threading.Tasks;

namespace prehdo
{
    class NoopSender : ISender
    {
        public Task SendAsync(Hdo hdo)
        {
            return Task.CompletedTask;
        }
    }
}