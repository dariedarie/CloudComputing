using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacunService_Data
{
    public class Racun
    {
        private int idRacuna;
        private int brojProizvodaNaRacunu;
        private int cenaKupovine;

        public Racun(int idRacuna, int brojProizvodaNaRacunu, int cenaKupovine)
        {
            this.idRacuna = idRacuna;
            this.brojProizvodaNaRacunu = brojProizvodaNaRacunu;
            this.cenaKupovine = cenaKupovine;
        }

        public int IdRacuna { get => idRacuna; set => idRacuna = value; }
        public int BrojProizvodaNaRacunu { get => brojProizvodaNaRacunu; set => brojProizvodaNaRacunu = value; }
        public int CenaKupovine { get => cenaKupovine; set => cenaKupovine = value; }
    }
}
