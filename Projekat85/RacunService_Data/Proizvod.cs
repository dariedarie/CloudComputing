using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacunService_Data
{
    public class Proizvod
    {
       private int idProizvoda;
       private string  nazivProizvoda;
        private int cenaProizvoda;

        public int IdProizvoda { get => idProizvoda; set => idProizvoda = value; }
        public string NazivProizvoda { get => nazivProizvoda; set => nazivProizvoda = value; }
        public int CenaProizvoda { get => cenaProizvoda; set => cenaProizvoda = value; }

        public Proizvod()
        {

        }

        public Proizvod(int idProizvoda, string nazivProizvoda)
        {
            this.idProizvoda = idProizvoda;
            this.nazivProizvoda = nazivProizvoda;
        }
    }
}
