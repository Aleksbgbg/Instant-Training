namespace Instant.Training.UI.Utilities
{
    public interface IRegistryProvider
    {
        T GetValueFromKey<T>(string key, string value);
    }
}