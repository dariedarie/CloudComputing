using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlaseService_Data
{
    public class RacunRepository
    {
        private CloudStorageAccount _storageAccount;
        private CloudTable _table;
        public RacunRepository()
        {
            _storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("DataConnectionString"));
            CloudTableClient tableClient = new CloudTableClient(new Uri(_storageAccount.TableEndpoint.AbsoluteUri), _storageAccount.Credentials);
            _table = tableClient.GetTableReference("RacunTable");
            _table.CreateIfNotExists();
        }
        public IQueryable<Racun> RetrieveAllRacun()
        {
            var results = from g in _table.CreateQuery<Racun>()
                          where g.PartitionKey == "Racun"
                          select g;
            return results;
        }
        public void AddRacun(Racun noviRacun)
        {
           
            TableOperation insertOperation = TableOperation.Insert(noviRacun);
            _table.Execute(insertOperation);
        }

        public bool Exists(string id)
        {
            TableOperation retrieveOperation = TableOperation.Retrieve<Racun>("Racun", id);            TableResult retrievedResult = _table.Execute(retrieveOperation);
            
            Racun provera = (Racun)retrievedResult.Result;            if (provera != null)
            {
                return true;
            }            return false;
        }



        public bool DeleteRacun(string RowKey)
        {
            TableOperation retrieveOperation = TableOperation.Retrieve<Racun>("Racun", RowKey);
           
            TableResult retrievedResult = _table.Execute(retrieveOperation);
            
            Racun deleteEntity = (Racun)retrievedResult.Result;
         
            if (deleteEntity != null)
            {
                TableOperation deleteOperation = TableOperation.Delete(deleteEntity);
               
                _table.Execute(deleteOperation);
                return true;
            }

            return false;
        }        public Racun GetRacun(string id)
        {
            return RetrieveAllRacun().Where(p => p.RowKey == id).FirstOrDefault();

        }
        public void UpdateRacun(Racun racun)
        {
            TableOperation updateOperation = TableOperation.InsertOrReplace(racun);
            _table.Execute(updateOperation);
        }



       


    }
}
