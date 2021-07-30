using Common;
using KlaseService_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityHandlerGreen
{
    public class EntityHandlerGreenServerProvider : IEntityHandlerGreen
    {
        RacunRepository repo = new RacunRepository();
        ProizvodRepository repoProizvod = new ProizvodRepository();
        RegistrovaniKupacRepository repoReg = new RegistrovaniKupacRepository();

        public void CreateProizvod(Proizvod p)
        {
            repoProizvod.AddProizvod(p);
        }

        public void CreateRacun(Racun r)
        {
            repo.AddRacun(r);
        }

        public void CreateRegistrovaniKupac(RegistrovaniKupac rk)
        {
            repoReg.AddRegistrovaniKupac(rk);
        }

        public void DeleteProizvod(string RowKey)
        {
            repoProizvod.DeleteProizvod(RowKey);
        }

        public void DeleteRacun(string RowKey)
        {
            repo.DeleteRacun(RowKey);
        }

        public void DeleteRegistrovaniKupac(string RowKey)
        {
            repoReg.DeleteRegistrovaniKupac(RowKey);
        }

        public IQueryable<Proizvod> ReadProizvode()
        {
            return repoProizvod.RetrieveAllProizvod();
        }

        public IQueryable<Racun> ReadRacune()
        {
            return repo.RetrieveAllRacun();
        }

        public IQueryable<RegistrovaniKupac> ReadRegistrovaniKupac()
        {
            return repoReg.RetrieveAllRegistrovaniKupac();
        }

        public void UpdateProizvod(Proizvod p)
        {
            repoProizvod.UpdateProizvod(p);
        }

        public void UpdateRacun(Racun r)
        {
            repo.UpdateRacun(r);
        }

        public void UpdateRegistrovaniKupac(RegistrovaniKupac rk)
        {
            repoReg.UpdateRegistrovaniKupac(rk);
        }

        public Proizvod UzmiProizvodIndeks(string id)
        {
            return repoProizvod.GetProizvod(id);
        }

        public Racun UzmiRacunIndeks(string id)
        {
            return repo.GetRacun(id);
        }

        public RegistrovaniKupac UzmiRegistrovaniKupacIndeks(string id)
        {
            return repoReg.GetRegistrovaniKupac(id);
        }
    }
}
