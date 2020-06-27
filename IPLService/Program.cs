using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace EFTConnectSvc
{
    static class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            try
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
            {
                            new Service1()
            };
                ServiceBase.Run(ServicesToRun);

                //TODO: Start of Debug
                //#if (!DEBUG)
                //                                ServiceBase[] ServicesToRun;
                //                                ServicesToRun = new ServiceBase[]
                //                                {
                //                                        new Service1()
                //                                };
                //                                ServiceBase.Run(ServicesToRun);
                //#else
                //                Service1 svc = new Service1();
                //                svc.Process();
                //#endif
                //End of Debug
            }
            catch (Exception ex) {
                log.Error(ex);
            }
        }
    }
}
