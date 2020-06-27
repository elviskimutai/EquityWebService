using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace EFTConnectSvc
{
    public partial class Service1 : ServiceBase
    {
        const int SleepTime = 100;
        private EventLog _eventLog;
        private bool m_running; 
        private System.Threading.Thread m_thread;
        private System.ServiceModel.ServiceHost serviceHost = null;
        
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
     {
            try
            {
                log.Info("=====================================");
                log.Info("Starting Service ...");
                this.EventLogger("Starting Service...", EventLogEntryType.Information);

                this.m_running = true;
                this.m_thread = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadMethod));
                this.m_thread.Start();
                this.EventLogger("Service Started...", EventLogEntryType.Information);

                ////TODO
                ////Mbadi: Remove the following line before deployment
                //while (true) ;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                this.EventLogger(ex.Message, EventLogEntryType.Error);
            }
        }

        protected override void OnStop()
        {
            
            log.Info("Stopping Service ...");
            log.Info("=====================================");
            this.EventLogger("Stopping Service ...", EventLogEntryType.Warning);
        }

        internal void Process()
        {
            OnStart(null);
        }

        public void ThreadMethod()
        {
            try
            {
                // Start the host
                this.serviceHost = new System.ServiceModel.ServiceHost(typeof(EFTConnectSvc));
                foreach (var endpoint in serviceHost.Description.Endpoints)
                {
                    //endpoint.Behaviors.Add(
                }

                this.serviceHost.Open();

                while (m_running)
                {
                    // Wait until thread is stopped
                    System.Threading.Thread.Sleep(SleepTime);
                }

                // Stop the host
                this.serviceHost.Close();
            }
            catch (Exception ex) {
                log.Error(ex);
                this.EventLogger(ex.Message, EventLogEntryType.Error);
            }
        }

        private void EventLogger(string data, EventLogEntryType logType)
        {
            try
            {
                using (_eventLog = new EventLog())
                {
                    _eventLog.Source = "EFTConnectNet";
                    if (!EventLog.SourceExists("EFTConnectNet"))
                    {
                        EventLog.CreateEventSource("Logs for EFTConnect", "EFTConnectNet");
                    }
                    _eventLog.WriteEntry(data, logType);
                }
            }
            catch (Exception ) { }
        }
    }
}
