﻿///////////////////////////////////////////////////////////
//  WeatherRepository.cs
//  Implementation of the Class WeatherRepository
//  Generated by Enterprise Architect
//  Created on:      16-maj-2018 10.31.48
//  Original author: Stefan
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.Azure;
using System.Linq;
using WeatherCommon.Classes;

namespace WeatherWorkerRoleData.Classes
{
    public class WindGeneratorRepository
    {

        private CloudStorageAccount _storageAccount;
        private CloudTable _table;
        private static bool isCreated = false;

        public WindGeneratorRepository()
        {
            _storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("WindGeneratorDataConnectionString"));
            CloudTableClient tableClient = new CloudTableClient(new
           Uri(_storageAccount.TableEndpoint.AbsoluteUri), _storageAccount.Credentials);
            _table = tableClient.GetTableReference("WindGeneratorTable");
            if (!isCreated)
            {
                _table.CreateIfNotExists();
                InitWindGenerators();
                isCreated = true;
            }
        }

        private void InitWindGenerators()
        {
            TableBatchOperation batchOperation = new TableBatchOperation();

            WindGeneratorBase w1 = new WindGeneratorBase("Novi Sad", "2", 20, "5");

            batchOperation.InsertOrReplace(w1);

            _table.ExecuteBatch(batchOperation);
        }


        public void AddOrReplaceWindGenerator(WindGeneratorBase windGenerator)
        {
            TableOperation add = TableOperation.InsertOrReplace(windGenerator);
            _table.Execute(add);

        }

        public List<WindGeneratorBase> GetAllWindGenerators()
        {
            IQueryable<WindGeneratorBase> requests = from g in _table.CreateQuery<WindGeneratorBase>()
                                                     where g.PartitionKey == "WindGenerator"
                                                     select g;
            return requests.ToList();
        }

        public WindGeneratorBase GetOneWindGenerator(string city)
        {
            IQueryable<WindGeneratorBase> requests = from g in _table.CreateQuery<WindGeneratorBase>()
                                                     where g.PartitionKey == "WindGenerator" && g.RowKey == city
                                                     select g;

            return requests.ToList()[0];
        }

    }//end WeatherRepository

}//end namespace WeatherWorkerRoleData