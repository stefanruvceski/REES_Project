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
        private static bool created = false;

        public WindMillRepository()
        {
            _storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("WindMillDataConnectionString"));
            CloudTableClient tableClient = new CloudTableClient(new Uri(_storageAccount.TableEndpoint.AbsoluteUri),
                                                                _storageAccount.Credentials);
            _table = tableClient.GetTableReference("WindMillTable");

            if (!created)
            {
                _table.CreateIfNotExists();
                InitWindMills();
            }
        }
        private void InitWindMills()
        {
            TableBatchOperation batchOperation = new TableBatchOperation();

            WindMillBase w1 = new WindMillBase(0.35, 10000000, 45, 18, 10);
            WindMillBase w2 = new WindMillBase(0.25, 10005000, 55, 17, 11);
            WindMillBase w3 = new WindMillBase(0.20, 10000500, 40, 16, 12);
            WindMillBase w4 = new WindMillBase(0.15, 10500000, 60, 15, 13);
            WindMillBase w5 = new WindMillBase(0.4, 10000400, 50, 14, 9);

            batchOperation.InsertOrReplace(w1);
            batchOperation.InsertOrReplace(w2);
            batchOperation.InsertOrReplace(w3);
            batchOperation.InsertOrReplace(w4);
            batchOperation.InsertOrReplace(w5);

            _table.ExecuteBatch(batchOperation);
        }
        public void AddOrReplaceWindGenerator(WindMillBase windGenerator)
        {
            TableOperation add = TableOperation.InsertOrReplace(windGenerator);
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
