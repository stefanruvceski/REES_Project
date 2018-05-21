using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherWorkerRoleData.Classes
{
    public class WeatherRepository
    {
        private CloudStorageAccount _storageAccount;
        private CloudTable _table;

        public WeatherRepository()
        {
            _storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("WeatherDataConnectionString"));
            CloudTableClient tableClient = new CloudTableClient(new Uri(_storageAccount.TableEndpoint.AbsoluteUri), 
                                                                _storageAccount.Credentials);
            _table = tableClient.GetTableReference("WeatherTable");
            _table.CreateIfNotExists();
        }

        public void AddOrReplaceWeather(WeatherBase weather)
        {
            TableOperation add = TableOperation.InsertOrReplace(weather);
            _table.Execute(add);

        }
        public void AddWeather(WeatherBase weather)
        {
            TableOperation add = TableOperation.Insert(weather);
            _table.Execute(add);

        }

        public List<WeatherBase> GetAllWeathers()
        {
            IQueryable<WeatherBase> requests = from g in _table.CreateQuery<WeatherBase>()
                                               where g.PartitionKey == "Weather"
                                               select g;
            return requests.ToList();
        }

        public WeatherBase GetOneWeather(string city)
        {
            IQueryable<WeatherBase> requests = from g in _table.CreateQuery<WeatherBase>()
                                               where g.PartitionKey == "Weather" && g.City == city
                                               select g;

            return requests.ToList()[0];
        }
    }
}
