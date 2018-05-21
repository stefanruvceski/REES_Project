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
    public class AggregateRepository
    {
        private CloudStorageAccount _storageAccount;
        private CloudTable _table;
        private static bool isCreated = false;

        public AggregateRepository()
        {
            _storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("AggregateDataConnectionString"));
            CloudTableClient tableClient = new CloudTableClient(new Uri(_storageAccount.TableEndpoint.AbsoluteUri),
                                                                _storageAccount.Credentials);
            _table = tableClient.GetTableReference("AggregateTable");
            if(!isCreated)
            {
                _table.CreateIfNotExists();
                InitAggregates();
            }        
        }

        private void InitAggregates()
        {
            TableBatchOperation batchOperation = new TableBatchOperation();

            AggregateBase a1 = new AggregateBase(100, 300000, false);
            AggregateBase a2 = new AggregateBase(120, 320000, false);
            AggregateBase a3 = new AggregateBase(130, 330000, false);
            AggregateBase a4 = new AggregateBase(80, 240000, false);
            AggregateBase a5 = new AggregateBase(150, 370000, false);

            batchOperation.InsertOrReplace(a1);
            batchOperation.InsertOrReplace(a2);
            batchOperation.InsertOrReplace(a3);
            batchOperation.InsertOrReplace(a4);
            batchOperation.InsertOrReplace(a5);

            _table.ExecuteBatch(batchOperation);
        }

        public void AddOrReplaceAggregate(AggregateBase aggregate)
        {
            TableOperation add = TableOperation.InsertOrReplace(aggregate);
            _table.Execute(add);

        }

        public List<AggregateBase> GetAllAggregates()
        {
            IQueryable<AggregateBase> requests = from g in _table.CreateQuery<AggregateBase>()
                                                 where g.PartitionKey == "Aggregate"
                                                 select g;
            return requests.ToList();
        }

        public AggregateBase GetOneAggregate(string id)
        {
            IQueryable<AggregateBase> requests = from g in _table.CreateQuery<AggregateBase>()
                                                 where g.PartitionKey == "Aggregate" && g.RowKey == id
                                                 select g;

            return requests.ToList()[0];
        }
    }
}
