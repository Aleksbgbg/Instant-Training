namespace Instant.Training.UI.Utilities
{
    using System.Windows;

    public class ResourceLocator : IResourceLocator
    {
        public object LocateResource(string name)
        {
            return Application.Current.FindResource(name);
        }
    }
}