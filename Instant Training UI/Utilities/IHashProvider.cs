namespace Instant.Training.UI.Utilities
{
    public interface IHashProvider
    {
        string Hash(byte[] contents);
    }
}