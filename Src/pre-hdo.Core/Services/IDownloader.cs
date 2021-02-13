using System.Threading.Tasks;

namespace prehdo.Core.Services
{
    public interface IDownloader
    {
        Task<string> DownloadAsync();
    }
}