namespace Instant.Training.UI.Services.Interfaces
{
    public interface IRconService
    {
        void Connect();

        void ToggleModEnabled(bool enabled);

        void TransmitTrainingMap(string trainingMap);
    }
}