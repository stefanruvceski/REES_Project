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
    public class WindMillRepository
    {
        private CloudStorageAccount _storageAccount;
        private CloudTable _table;

        public WindMillRepository()
        {
            _storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("WindMillDataConnectionString"));
            CloudTableClient tableClient = new CloudTableClient(new Uri(_storageAccount.TableEndpoint.AbsoluteUri),
                                                                _storageAccount.Credentials);
            _table = tableClient.GetTableReference("WindMillTable");

            if (_table.CreateIfNotExists())
            {
                InitWindMills();
            }
        }
        private void InitWindMills()
        {
            TableBatchOperation batchOperation = new TableBatchOperation();

            WindMillBase w1 = new WindMillBase(0.30, 2000, 30, 5, 10);          // Model 1
            WindMillBase w2 = new WindMillBase(0.40, 2600, 40, 5, 10);          // Model 2
            WindMillBase w3 = new WindMillBase(0.30, 3700, 30, 8, 10);          // Model 3
            WindMillBase w4 = new WindMillBase(0.40, 8800, 40, 8, 10);          // Model 4
            WindMillBase w5 = new WindMillBase(0.30, 17000, 30, 10, 10);        // Model 5
            WindMillBase w6 = new WindMillBase(0.40, 40000, 40, 10, 10);        // Model 6
            WindMillBase w7 = new WindMillBase(0.30, 17000, 30, 18, 10);        // Model 7
            WindMillBase w8 = new WindMillBase(0.40, 40000, 40, 10, 10);        // Model 8

            batchOperation.InsertOrReplace(w1);
            batchOperation.InsertOrReplace(w2);
            batchOperation.InsertOrReplace(w3);
            batchOperation.InsertOrReplace(w4);
            batchOperation.InsertOrReplace(w5);
            batchOperation.InsertOrReplace(w6);
            batchOperation.InsertOrReplace(w7);
            batchOperation.InsertOrReplace(w8);

            _table.ExecuteBatch(batchOperation);
        }
        public void AddOrReplaceWindMill(WindMillBase windMill)
        {
            TableOperation add = TableOperation.InsertOrReplace(windMill);
            _table.Execute(add);

        }

        public List<WindMillBase> GetAllWindMills()
        {
            IQueryable<WindMillBase> requests = from g in _table.CreateQuery<WindMillBase>()
                                                where g.PartitionKey == "WindMill"
                                                select g;
            return requests.ToList();
        }

        public WindMillBase GetOneWindMill(string id)
        {
            IQueryable<WindMillBase> requests = from g in _table.CreateQuery<WindMillBase>()
                                                where g.PartitionKey == "WindMill" && g.RowKey == id
                                                select g;

            return requests.ToList()[0];
        }
    }
}
