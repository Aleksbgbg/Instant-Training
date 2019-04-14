namespace Instant.Training.UI.Utilities
{
    using System.IO;
    using System.Threading.Tasks;

    public class FileWatchProvider : IFileWatchProvider
    {
        public Task DirectoryCreated(string path)
        {
            string directory = Path.GetDirectoryName(path);

            FileSystemWatcher fileSystemWatcher = new FileSystemWatcher(directory)
            {
                EnableRaisingEvents = true
            };

            TaskCompletionSource<object> taskCompletionSource = new TaskCompletionSource<object>();

            fileSystemWatcher.Created += (sender, e) => taskCompletionSource.SetResult(null);

            return taskCompletionSource.Task;
        }
    }
}