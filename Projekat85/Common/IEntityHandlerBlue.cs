using KlaseService_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [ServiceContract]
    public interface IEntityHandlerBlue
    {
        [OperationContract]
        void CreateRacun(Racun r);

        [OperationContract]
        void UpdateRacun(Racun r);

        [OperationContract]
        Racun UzmiRacunIndeks(string id);

        [OperationContract]
        void DeleteRacun(string RowKey);

        [OperationContract]
       IQueryable<Racun> ReadRacune();

        [OperationContract]
        void CreateProizvod(Proizvod p);

        [OperationContract]
        void UpdateProizvod(Proizvod p);

        [OperationContract]
        Proizvod UzmiProizvodIndeks(string id);

        [OperationContract]
        void DeleteProizvod(string RowKey);

        [OperationContract]
        IQueryable<Proizvod> ReadProizvode();

        [OperationContract]
        void CreateRegistrovaniKupac(RegistrovaniKupac rk);

        [OperationContract]
        void UpdateRegistrovaniKupac(RegistrovaniKupac rk);

        [OperationContract]
        RegistrovaniKupac UzmiRegistrovaniKupacIndeks(string id);

        [OperationContract]
        void DeleteRegistrovaniKupac(string RowKey);

        [OperationContract]
        IQueryable<RegistrovaniKupac> ReadRegistrovaniKupac();





    }
}
