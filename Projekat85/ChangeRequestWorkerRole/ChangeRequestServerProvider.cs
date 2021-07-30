using Common;
using KlaseService_Data;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeRequestWorkerRole
{
    public class ChangeRequestServerProvider : IChange
    {
        public string SendChange(string izabranaRola)
        {
            CloudQueue queue = QueueHelper.GetQueueReference("promenaqueue");
            CloudQueueMessage mess = new CloudQueueMessage(izabranaRola);
            queue.AddMessage(mess);

            return izabranaRola;
        }
    }
}
