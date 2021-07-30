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
    public class ProizvodController : Controller
    {
        // GET: Proizvod
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult CreateProizvod()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CreateProizvodKlik(string RowKey, string nazivProizvoda, int cenaProizvoda)
        {
            Proizvod p = new Proizvod(RowKey);
            p.NazivProizvoda = nazivProizvoda;
            p.CenaProizvoda = cenaProizvoda;

            try
            {

                foreach (var indeks in RoleEnvironment.Roles["EntityHandlerBlue"].Instances)
                {
                    if (indeks.Id.Contains("_IN_2"))
                    {

                        NetTcpBinding binding = new NetTcpBinding();
                        string endpoint = indeks.InstanceEndpoints["WebInternal"].IPEndpoint.ToString();
                        IEntityHandlerBlue proxy = new ChannelFactory<IEntityHandlerBlue>(binding, new EndpointAddress(String.Format("net.tcp://{0}/WebInternal", endpoint))).CreateChannel();
                        proxy.CreateProizvod(p);
                        return RedirectToAction("ReadProizvod");
                    }


                }

                return RedirectToAction("ReadProizvod");
            }
            catch
            {
                return View("CreateRacun");
            }
        }



        public ActionResult UpDateProizvod(string id)
        {

            foreach (var indeks in RoleEnvironment.Roles["EntityHandlerBlue"].Instances)
            {
                if (indeks.Id.Contains("_IN_2"))
                {

                    NetTcpBinding binding = new NetTcpBinding();
                    string endpoint = indeks.InstanceEndpoints["WebInternal"].IPEndpoint.ToString();
                    IEntityHandlerBlue proxy = new ChannelFactory<IEntityHandlerBlue>(binding, new EndpointAddress(String.Format("net.tcp://{0}/WebInternal", endpoint))).CreateChannel();
                    Proizvod p = proxy.UzmiProizvodIndeks(id);
                    return View(p);
                }


            }

            return RedirectToAction("ReadProizvod");
        }

        public ActionResult UpDateProizvodKlik(string id, string nazivProizvoda, int cenaProizvoda)
        {
            Proizvod p = new Proizvod(id);
            p.NazivProizvoda = nazivProizvoda;
            p.CenaProizvoda = cenaProizvoda;

            foreach (var indeks in RoleEnvironment.Roles["EntityHandlerBlue"].Instances)
            {
                if (indeks.Id.Contains("_IN_2"))
                {

                    NetTcpBinding binding = new NetTcpBinding();
                    string endpoint = indeks.InstanceEndpoints["WebInternal"].IPEndpoint.ToString();
                    IEntityHandlerBlue proxy = new ChannelFactory<IEntityHandlerBlue>(binding, new EndpointAddress(String.Format("net.tcp://{0}/WebInternal", endpoint))).CreateChannel();
                    proxy.UpdateProizvod(p);
                    return RedirectToAction("ReadProizvod");
                }


            }

            return RedirectToAction("ReadProizvod");
        }



        public ActionResult DeleteProizvod(string RowKey)
        {

            foreach (var indeks in RoleEnvironment.Roles["EntityHandlerBlue"].Instances)
            {
                if (indeks.Id.Contains("_IN_2"))
                {

                    NetTcpBinding binding = new NetTcpBinding();
                    string endpoint = indeks.InstanceEndpoints["WebInternal"].IPEndpoint.ToString();
                    IEntityHandlerBlue proxy = new ChannelFactory<IEntityHandlerBlue>(binding, new EndpointAddress(String.Format("net.tcp://{0}/WebInternal", endpoint))).CreateChannel();
                    proxy.DeleteProizvod(RowKey);
                    return RedirectToAction("ReadProizvod");
                }


            }

            return RedirectToAction("ReadProizvod");

        }

        public ActionResult ReadProizvod()
        {
            foreach (var indeks in RoleEnvironment.Roles["EntityHandlerBlue"].Instances)
            {
                if (indeks.Id.Contains("_IN_2"))
                {

                    NetTcpBinding binding = new NetTcpBinding();
                    string endpoint = indeks.InstanceEndpoints["WebInternal"].IPEndpoint.ToString();
                    IEntityHandlerBlue proxy = new ChannelFactory<IEntityHandlerBlue>(binding, new EndpointAddress(String.Format("net.tcp://{0}/WebInternal", endpoint))).CreateChannel();
                    return View(proxy.ReadProizvode());
                }


            }

            return RedirectToAction("ReadProizvod");
        }
    }
}