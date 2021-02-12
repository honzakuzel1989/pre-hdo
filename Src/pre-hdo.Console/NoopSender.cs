using prehdo.Console.Entities;
using System.Threading.Tasks;

namespace prehdo.Console
{
    class NoopSender : ISender
    {
        public Task SendAsync(Hdo hdo)
        {
            return Task.CompletedTask;
        }
    }
}