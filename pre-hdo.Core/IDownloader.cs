using System.Threading.Tasks;

namespace prehdo.Console
{
    public interface IDownloader
    {
        Task<string> DownloadAsync();
    }
}