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
    public class RegistrovaniKupacController : Controller
    {
        // GET: RegistrovaniKupac
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult CreateRegistrovaniKupac()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateRegistrovaniKupacKlik(string RowKey, double popustPrikupovini, string nazivKupca, string prezimeKupca)
        {
            RegistrovaniKupac rk = new RegistrovaniKupac(RowKey);
            rk.PopustPriKupovini= popustPrikupovini;
            rk.NazivKupca = nazivKupca;
            rk.PrezimeKupca = prezimeKupca;

            try
            {

                foreach (var indeks in RoleEnvironment.Roles["EntityHandlerBlue"].Instances)
                {
                    if (indeks.Id.Contains("_IN_2"))
                    {

                        NetTcpBinding binding = new NetTcpBinding();
                        string endpoint = indeks.InstanceEndpoints["WebInternal"].IPEndpoint.ToString();
                        IEntityHandlerBlue proxy = new ChannelFactory<IEntityHandlerBlue>(binding, new EndpointAddress(String.Format("net.tcp://{0}/WebInternal", endpoint))).CreateChannel();
                        proxy.CreateRegistrovaniKupac(rk);
                        return RedirectToAction("ReadRegistrovaniKupac");
                    }


                }

                return RedirectToAction("ReadRegistrovaniKupac");
            }
            catch
            {
                return View("CreateRacun");
            }
        }

        public ActionResult UpDateRegistrovaniKupac(string id)
        {

            foreach (var indeks in RoleEnvironment.Roles["EntityHandlerBlue"].Instances)
            {
                if (indeks.Id.Contains("_IN_2"))
                {

                    NetTcpBinding binding = new NetTcpBinding();
                    string endpoint = indeks.InstanceEndpoints["WebInternal"].IPEndpoint.ToString();
                    IEntityHandlerBlue proxy = new ChannelFactory<IEntityHandlerBlue>(binding, new EndpointAddress(String.Format("net.tcp://{0}/WebInternal", endpoint))).CreateChannel();
                    RegistrovaniKupac rk = proxy.UzmiRegistrovaniKupacIndeks(id);
                    return View(rk);
                }


            }

            return RedirectToAction("ReadRegistrovaniKupac");
        }

        public ActionResult UpDateRegistrovaniKupacKlik(string id, float popustPrikupovini, string nazivKupca,string prezimeKupca)
        {
            RegistrovaniKupac rk = new RegistrovaniKupac(id);
            rk.PopustPriKupovini = popustPrikupovini;
            rk.NazivKupca = nazivKupca;
            rk.PrezimeKupca = prezimeKupca;

            foreach (var indeks in RoleEnvironment.Roles["EntityHandlerBlue"].Instances)
            {
                if (indeks.Id.Contains("_IN_2"))
                {

                    NetTcpBinding binding = new NetTcpBinding();
                    string endpoint = indeks.InstanceEndpoints["WebInternal"].IPEndpoint.ToString();
                    IEntityHandlerBlue proxy = new ChannelFactory<IEntityHandlerBlue>(binding, new EndpointAddress(String.Format("net.tcp://{0}/WebInternal", endpoint))).CreateChannel();
                    proxy.UpdateRegistrovaniKupac(rk);
                    return RedirectToAction("ReadRegistrovaniKupac");
                }


            }

            return RedirectToAction("ReadRegistrovaniKupac");
        }



        public ActionResult DeleteRegistrovaniKupac(string RowKey)
        {

            foreach (var indeks in RoleEnvironment.Roles["EntityHandlerBlue"].Instances)
            {
                if (indeks.Id.Contains("_IN_2"))
                {

                    NetTcpBinding binding = new NetTcpBinding();
                    string endpoint = indeks.InstanceEndpoints["WebInternal"].IPEndpoint.ToString();
                    IEntityHandlerBlue proxy = new ChannelFactory<IEntityHandlerBlue>(binding, new EndpointAddress(String.Format("net.tcp://{0}/WebInternal", endpoint))).CreateChannel();
                    proxy.DeleteRegistrovaniKupac(RowKey);
                    return RedirectToAction("ReadRegistrovaniKupac");
                }


            }

            return RedirectToAction("ReadRegistrovaniKupac");

        }

        public ActionResult ReadRegistrovaniKupac()
        {
            foreach (var indeks in RoleEnvironment.Roles["EntityHandlerBlue"].Instances)
            {
                if (indeks.Id.Contains("_IN_2"))
                {

                    NetTcpBinding binding = new NetTcpBinding();
                    string endpoint = indeks.InstanceEndpoints["WebInternal"].IPEndpoint.ToString();
                    IEntityHandlerBlue proxy = new ChannelFactory<IEntityHandlerBlue>(binding, new EndpointAddress(String.Format("net.tcp://{0}/WebInternal", endpoint))).CreateChannel();
                    return View(proxy.ReadRegistrovaniKupac());
                }


            }

            return RedirectToAction("ReadRegistrovaniKupac");
        }
    }
}