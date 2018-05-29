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

        public AggregateRepository()
        {
            _storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("AggregateDataConnectionString"));
            CloudTableClient tableClient = new CloudTableClient(new Uri(_storageAccount.TableEndpoint.AbsoluteUri),
                                                                _storageAccount.Credentials);
            _table = tableClient.GetTableReference("AggregateTable");

            if (_table.CreateIfNotExists())
            {       
                InitAggregates();     
            }
        }

        private void InitAggregates()
        {
            TableBatchOperation batchOperation = new TableBatchOperation();

            AggregateBase a1 = new AggregateBase(90, 1000, false);
            AggregateBase a2 = new AggregateBase(117, 1300, false);
            AggregateBase a3 = new AggregateBase(166.5, 1850, false);
            AggregateBase a4 = new AggregateBase(396, 4400, false);
            AggregateBase a5 = new AggregateBase(765, 8500, false);
            AggregateBase a6 = new AggregateBase(1800, 20000, false);

            batchOperation.InsertOrReplace(a1);
            batchOperation.InsertOrReplace(a2);
            batchOperation.InsertOrReplace(a3);
            batchOperation.InsertOrReplace(a4);
            batchOperation.InsertOrReplace(a5);
            batchOperation.InsertOrReplace(a6);

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
