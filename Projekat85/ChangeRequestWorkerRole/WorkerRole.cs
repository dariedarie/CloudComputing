using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using KlaseService_Data;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace ChangeRequestWorkerRole
{
    public class WorkerRole : RoleEntryPoint
    {
        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private readonly ManualResetEvent runCompleteEvent = new ManualResetEvent(false);

        public override void Run()
        {
            Trace.TraceInformation("ChangeRequestWorkerRole is running");



            try
            {
                this.RunAsync(this.cancellationTokenSource.Token).Wait();
            }
            finally
            {
                this.runCompleteEvent.Set();
            }
        }

        public override bool OnStart()
        {
            // Set the maximum number of concurrent connections
            ServicePointManager.DefaultConnectionLimit = 12;

            // For information on handling configuration changes
            // see the MSDN topic at https://go.microsoft.com/fwlink/?LinkId=166357.

            bool result = base.OnStart();

            Trace.TraceInformation("ChangeRequestWorkerRole has been started");

            return result;
        }

        public override void OnStop()
        {
            Trace.TraceInformation("ChangeRequestWorkerRole is stopping");

            this.cancellationTokenSource.Cancel();
            this.runCompleteEvent.WaitOne();

            base.OnStop();

            Trace.TraceInformation("ChangeRequestWorkerRole has stopped");
        }

        private async Task RunAsync(CancellationToken cancellationToken)
        {
            // TODO: Replace the following with your own logic.
            while (!cancellationToken.IsCancellationRequested)
            {

                CloudQueue queue = QueueHelper.GetQueueReference("promenaqueue");
                CloudQueueMessage message;

                while (true)
                {
                    if ((message = queue.GetMessage()) == null)
                    {
                        Trace.WriteLine("Nema poruke");



                    }
                    else
                    {
                        Trace.TraceInformation(String.Format("Poruka glasi: {0}", message.AsString), "Information");
                        queue.DeleteMessage(message);
                        Trace.TraceInformation(String.Format("Poruka procesuirana: {0}", message.AsString), "Information");
                    }

                    Thread.Sleep(5000);
                    Trace.TraceInformation("Working", "Information");

                }




               
                
            }
            await Task.Delay(1000);




        }
    }
}
