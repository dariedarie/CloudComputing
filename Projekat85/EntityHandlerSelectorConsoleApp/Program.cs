using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EntityHandlerSelectorConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IChange changeProxy;
            

            ChannelFactory<IChange> channelFactory = new ChannelFactory<IChange>(new NetTcpBinding(), new EndpointAddress("net.tcp://127.0.0.1:10100/SelectorInput"));
            changeProxy = channelFactory.CreateChannel();

            while (true)
            {
                string izbor;

                Console.WriteLine("Unesite blue ili green za promenu entity hendlera: ");
                izbor = Console.ReadLine();


                changeProxy = channelFactory.CreateChannel();
                changeProxy.SendChange(izbor);
               
            }


        }
    }
}
