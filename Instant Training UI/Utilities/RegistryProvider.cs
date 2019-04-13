namespace Instant.Training.UI.Utilities
{
    using Microsoft.Win32;

    public class RegistryProvider : IRegistryProvider
    {
        public T GetValueFromKey<T>(string key, string value)
        {
            return (T)Registry.GetValue(key, value, defaultValue: default);
        }
    }
}