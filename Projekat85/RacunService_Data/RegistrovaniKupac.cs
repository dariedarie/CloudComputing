using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacunService_Data
{
    public class RegistrovaniKupac
    {
        private float popustPriKupovini;
        private string nazivKupca;
        private string prezimeKupca;
        private int jmbg;

        public RegistrovaniKupac(float popustPriKupovini, string nazivKupca, string prezimeKupca, int jmbg)
        {
            this.popustPriKupovini = popustPriKupovini;
            this.nazivKupca = nazivKupca;
            this.prezimeKupca = prezimeKupca;
            this.jmbg = jmbg;
        }

        public float PopustPriKupovini { get => popustPriKupovini; set => popustPriKupovini = value; }
        public string NazivKupca { get => nazivKupca; set => nazivKupca = value; }
        public string PrezimeKupca { get => prezimeKupca; set => prezimeKupca = value; }
        public int Jmbg { get => jmbg; set => jmbg = value; }
    }
}
