using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using WeatherWorkerRole.Classes;
using WeatherWorkerRoleData.Classes;

namespace WeatherWorkerRole
{
    public class WorkerRole : RoleEntryPoint
    {
        #region parameters
        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private readonly ManualResetEvent runCompleteEvent = new ManualResetEvent(false);

        private WeatherJobServer weatherServer = new WeatherJobServer();
        private InternalWeatherJobServer internalWeatherServer = new InternalWeatherJobServer();

        Repositories repositories = new Repositories();
        #endregion
        public override void Run()
        {
            Trace.TraceInformation("WeatherWorkerRole is running");

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

            weatherServer.Open();
            internalWeatherServer.Open();

            Trace.TraceInformation("WeatherWorkerRole has been started");

            return result;
        }

        public override void OnStop()
        {
            Trace.TraceInformation("WeatherWorkerRole is stopping");

            this.cancellationTokenSource.Cancel();
            this.runCompleteEvent.WaitOne();

            base.OnStop();

            weatherServer.Close();
            internalWeatherServer.Close();

            Trace.TraceInformation("WeatherWorkerRole has stopped");
        }

        private async Task RunAsync(CancellationToken cancellationToken)
        {
            // TODO: Replace the following with your own logic.
            while (!cancellationToken.IsCancellationRequested)
            {

                Trace.WriteLine("working");
                await Task.Delay(5000);
            }
        }
    }
}
