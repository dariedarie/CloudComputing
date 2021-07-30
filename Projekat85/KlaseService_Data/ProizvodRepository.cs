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
    public class ProizvodRepository
    {
        private CloudStorageAccount _storageAccount;
        private CloudTable _table;
        public ProizvodRepository()
        {
            _storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("DataConnectionString"));
            CloudTableClient tableClient = new CloudTableClient(new Uri(_storageAccount.TableEndpoint.AbsoluteUri), _storageAccount.Credentials);
            _table = tableClient.GetTableReference("ProizvodTable");
            _table.CreateIfNotExists();
        }
        public IQueryable<Proizvod> RetrieveAllProizvod()
        {
            var results = from g in _table.CreateQuery<Proizvod>()
                          where g.PartitionKey == "Proizvod"
                          select g;
            return results;
        }
        public void AddProizvod(Proizvod noviProizvod)
        {
           
            TableOperation insertOperation = TableOperation.Insert(noviProizvod);
            _table.Execute(insertOperation);
        }

        public bool Exists(string id)
        {
            TableOperation retrieveOperation = TableOperation.Retrieve<Proizvod>("Proizvod", id);            TableResult retrievedResult = _table.Execute(retrieveOperation);
            
            Proizvod provera = (Proizvod)retrievedResult.Result;            if (provera != null)
            {
                return true;
            }            return false;
        }



        public bool DeleteProizvod(string id)
        {
            TableOperation retrieveOperation = TableOperation.Retrieve<Proizvod>("Proizvod", id);
            
            TableResult retrievedResult = _table.Execute(retrieveOperation);
           
            Proizvod deleteEntity = (Proizvod)retrievedResult.Result;
           
            if (deleteEntity != null)
            {
                TableOperation deleteOperation = TableOperation.Delete(deleteEntity);
               
                _table.Execute(deleteOperation);
                return true;
            }

            return false;
        }        public Proizvod GetProizvod(string id)
        {
            return RetrieveAllProizvod().Where(p => p.RowKey == id).FirstOrDefault();

        }
        public void UpdateProizvod(Proizvod proizvod)
        {
            TableOperation updateOperation = TableOperation.InsertOrReplace(proizvod);
            _table.Execute(updateOperation);
        }

    }
}
