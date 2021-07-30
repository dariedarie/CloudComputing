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
    public class RegistrovaniKupacRepository
    {
        private CloudStorageAccount _storageAccount;
        private CloudTable _table;
        public RegistrovaniKupacRepository()
        {
            _storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("DataConnectionString"));
            CloudTableClient tableClient = new CloudTableClient(new Uri(_storageAccount.TableEndpoint.AbsoluteUri), _storageAccount.Credentials);
            _table = tableClient.GetTableReference("RegistrovaniKupacTable");
            _table.CreateIfNotExists();
        }
        public IQueryable<RegistrovaniKupac> RetrieveAllRegistrovaniKupac()
        {
            var results = from g in _table.CreateQuery<RegistrovaniKupac>()
                          where g.PartitionKey == "RegistrovaniKupac"
                          select g;
            return results;
        }
        public void AddRegistrovaniKupac(RegistrovaniKupac noviRegistrovaniKupac)
        {
            
            TableOperation insertOperation = TableOperation.Insert(noviRegistrovaniKupac);
            _table.Execute(insertOperation);
        }

        public bool Exists(string id)
        {
            TableOperation retrieveOperation = TableOperation.Retrieve<RegistrovaniKupac>("RegistrovaniKupac", id);            TableResult retrievedResult = _table.Execute(retrieveOperation);
            
            RegistrovaniKupac provera = (RegistrovaniKupac)retrievedResult.Result;            if (provera != null)
            {
                return true;
            }            return false;
        }



        public bool DeleteRegistrovaniKupac(string id)
        {
            TableOperation retrieveOperation = TableOperation.Retrieve<RegistrovaniKupac>("RegistrovaniKupac", id);
            
            TableResult retrievedResult = _table.Execute(retrieveOperation);

            RegistrovaniKupac deleteEntity = (RegistrovaniKupac)retrievedResult.Result;
            
            if (deleteEntity != null)
            {
                TableOperation deleteOperation = TableOperation.Delete(deleteEntity);
               
                _table.Execute(deleteOperation);
                return true;
            }

            return false;
        }        public RegistrovaniKupac GetRegistrovaniKupac(string id)
        {
            return RetrieveAllRegistrovaniKupac().Where(p => p.RowKey == id).FirstOrDefault();

        }
        public void UpdateRegistrovaniKupac(RegistrovaniKupac registrovaniKupac)
        {
            TableOperation updateOperation = TableOperation.InsertOrReplace(registrovaniKupac);
            _table.Execute(updateOperation);
        }


    }
}
