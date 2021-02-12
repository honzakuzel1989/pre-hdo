using System.Threading.Tasks;

namespace prehdo
{
    internal interface IDownloader
    {
        Task<string> DownloadAsync(int command);
    }
}