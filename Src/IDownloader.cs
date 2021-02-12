using System.Threading.Tasks;

namespace prehdo.Console
{
    internal interface IDownloader
    {
        Task<string> DownloadAsync(int command);
    }
}