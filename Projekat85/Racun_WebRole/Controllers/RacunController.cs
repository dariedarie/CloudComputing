using Common;
using KlaseService_Data;
using Microsoft.WindowsAzure.ServiceRuntime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;

namespace Racun_WebRole.Controllers
{
    public class RacunController : Controller
    {
        

        // GET: Racun
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateRacun()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateRacunKlik(string RowKey, int CenaRacuna, int BrojProizvodaNaRacunu)
        {
            Racun r = new Racun(RowKey);
            r.CenaRacuna = CenaRacuna;
            r.BrojProizvodaNaRacunu = BrojProizvodaNaRacunu;


            try
            {
              
                foreach (var indeks in RoleEnvironment.Roles["EntityHandlerBlue"].Instances)
                {
                    if(indeks.Id.Contains("_IN_0") || indeks.Id.Contains("_IN_1"))
                    {

                        NetTcpBinding binding = new NetTcpBinding();
                        string endpoint = indeks.InstanceEndpoints["WebInternal"].IPEndpoint.ToString();
                        IEntityHandlerBlue proxy = new ChannelFactory<IEntityHandlerBlue>(binding, new EndpointAddress(String.Format("net.tcp://{0}/WebInternal", endpoint))).CreateChannel();
                        proxy.CreateRacun(r);
                        return RedirectToAction("ReadRacun");
                    }

                 
                }
               
                return RedirectToAction("ReadRacun");
            }
            catch
            {
                return View("CreateRacun");
            }
        }



        public ActionResult UpDateRacun(string id)
        {

            foreach (var indeks in RoleEnvironment.Roles["EntityHandlerBlue"].Instances)
            {
                if (indeks.Id.Contains("_IN_0") || indeks.Id.Contains("_IN_1"))
                {

                    NetTcpBinding binding = new NetTcpBinding();
                    string endpoint = indeks.InstanceEndpoints["WebInternal"].IPEndpoint.ToString();
                    IEntityHandlerBlue proxy = new ChannelFactory<IEntityHandlerBlue>(binding, new EndpointAddress(String.Format("net.tcp://{0}/WebInternal", endpoint))).CreateChannel();
                    Racun r=proxy.UzmiRacunIndeks(id);
                    return View(r);
                }


            }

            return RedirectToAction("ReadRacun");
        }

        public ActionResult UpDateRacunKlik(string id,int cenaRacuna,int brojProizvodaNaRacunu)
        {
            Racun r = new Racun(id);
            r.CenaRacuna = cenaRacuna;
            r.BrojProizvodaNaRacunu = brojProizvodaNaRacunu;

            foreach (var indeks in RoleEnvironment.Roles["EntityHandlerBlue"].Instances)
            {
                if (indeks.Id.Contains("_IN_0") || indeks.Id.Contains("_IN_1"))
                {

                    NetTcpBinding binding = new NetTcpBinding();
                    string endpoint = indeks.InstanceEndpoints["WebInternal"].IPEndpoint.ToString();
                    IEntityHandlerBlue proxy = new ChannelFactory<IEntityHandlerBlue>(binding, new EndpointAddress(String.Format("net.tcp://{0}/WebInternal", endpoint))).CreateChannel();
                    proxy.UpdateRacun(r);
                    return RedirectToAction("ReadRacun");
                }


            }

            return RedirectToAction("ReadRacun");
        }

        public ActionResult DeleteRacun(string RowKey)
        {

                foreach (var indeks in RoleEnvironment.Roles["EntityHandlerBlue"].Instances)
                {
                    if (indeks.Id.Contains("_IN_0") || indeks.Id.Contains("_IN_1"))
                    {

                        NetTcpBinding binding = new NetTcpBinding();
                        string endpoint = indeks.InstanceEndpoints["WebInternal"].IPEndpoint.ToString();
                        IEntityHandlerBlue proxy = new ChannelFactory<IEntityHandlerBlue>(binding, new EndpointAddress(String.Format("net.tcp://{0}/WebInternal", endpoint))).CreateChannel();
                        proxy.DeleteRacun(RowKey);
                        return RedirectToAction("ReadRacun");
                    }


                }

            return RedirectToAction("ReadRacun");

        }

        public ActionResult ReadRacun()
        {
            foreach (var indeks in RoleEnvironment.Roles["EntityHandlerBlue"].Instances)
            {
                if (indeks.Id.Contains("_IN_0") || indeks.Id.Contains("_IN_1"))
                {

                    NetTcpBinding binding = new NetTcpBinding();
                    string endpoint = indeks.InstanceEndpoints["WebInternal"].IPEndpoint.ToString();
                    IEntityHandlerBlue proxy = new ChannelFactory<IEntityHandlerBlue>(binding, new EndpointAddress(String.Format("net.tcp://{0}/WebInternal", endpoint))).CreateChannel();
                    return View(proxy.ReadRacune());
                }


            }

            return RedirectToAction("ReadRacun");
            

        }



        
    }
}