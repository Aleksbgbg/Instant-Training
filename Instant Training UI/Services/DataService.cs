namespace Instant.Training.UI.Services
{
    using System;
    using System.IO;

    using Instant.Training.UI.Services.Interfaces;

    using Newtonsoft.Json;

    public class DataService : IDataService
    {
        private readonly IAppDataService _appDataService;

        public DataService(IAppDataService appDataService)
        {
            _appDataService = appDataService;
        }

        public T Load<T>(string dataName, T emptyData = default)
        {
            return Load(dataName, () => emptyData);
        }

        public T Load<T>(string dataName, Func<T> emptyData)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(_appDataService.GetFile($"Data/{dataName}.json", () => JsonConvert.SerializeObject(emptyData()))));
        }

        public void Save(string dataName, object data)
        {
            File.WriteAllText(_appDataService.GetFile($"Data/{dataName}.json"), JsonConvert.SerializeObject(data));
        }
    }
}