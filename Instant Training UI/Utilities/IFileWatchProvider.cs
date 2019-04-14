namespace Instant.Training.UI.Utilities
{
    using System.Threading.Tasks;

    public interface IFileWatchProvider
    {
        Task DirectoryCreated(string path);
    }
}