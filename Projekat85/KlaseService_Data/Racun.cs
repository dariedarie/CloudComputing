using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlaseService_Data
{
    public class Racun:TableEntity
    {
       
        private int cenaRacuna;
        private int brojProizvodaNaRacunu;

        public Racun()
        {

        }

        public Racun(string id)
        {
            PartitionKey ="Racun";
            RowKey = id;
        }

        
        public int CenaRacuna { get => cenaRacuna; set => cenaRacuna = value; }
        public int BrojProizvodaNaRacunu { get => brojProizvodaNaRacunu; set => brojProizvodaNaRacunu = value; }
    }
}
