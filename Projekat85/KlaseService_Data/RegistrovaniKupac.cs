using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlaseService_Data
{
    public class RegistrovaniKupac: TableEntity
    {
        private double popustPriKupovini;
        private string nazivKupca;
        private string prezimeKupca;

        public RegistrovaniKupac()
        {

        }

        public RegistrovaniKupac(string id)
        {
            PartitionKey = "RegistrovaniKupac";
            RowKey = id;
           
        }

        public double PopustPriKupovini { get => popustPriKupovini; set => popustPriKupovini = value; }
        public string NazivKupca { get => nazivKupca; set => nazivKupca = value; }
        public string PrezimeKupca { get => prezimeKupca; set => prezimeKupca = value; }
    }
}
