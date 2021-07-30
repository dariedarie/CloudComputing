using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlaseService_Data
{
    public class Proizvod:TableEntity
    {
        
        private string nazivProizvoda;
        private int cenaProizvoda;

        public Proizvod()
        {

        }

        public Proizvod(string id)
        {
            PartitionKey = "Proizvod";
            RowKey = id;
        }

        
        public string NazivProizvoda { get => nazivProizvoda; set => nazivProizvoda = value; }
        public int CenaProizvoda { get => cenaProizvoda; set => cenaProizvoda = value; }
    }
}
