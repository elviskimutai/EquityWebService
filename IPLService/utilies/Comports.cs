using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;

namespace EFTConnectSvc.utilies
{
    class Comports
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static String getComports()
        {

            String Comport = null;

            try
            {
              
                String deviceName = System.Configuration.ConfigurationManager.AppSettings["deviceName"];
                string lowerdeviceName = deviceName.ToLower();
                Boolean ingenicofound = false;
                using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE Caption like '%(COM%'"))
                {
                    var portnames = SerialPort.GetPortNames();
                    var ports = searcher.Get().Cast<ManagementBaseObject>().ToList().Select(p => p["Caption"].ToString());
                    var portList = portnames.Select(n => n + " - " + ports.FirstOrDefault(s => s.Contains(n))).ToList();
                    int count = portList.Count;
                    if (count > 0)
                    {
                        foreach (string s in portList)
                        {
                            String[] NewList = s.Split('-');                          
                            string founddevice = NewList[1].ToLower();
                           
                            //if (count == 1)
                            //{
                                if (founddevice.Contains(lowerdeviceName))
                                {
                                    Comport = NewList[0];
                                    ingenicofound = true;
                                    break;
                                    // }
                                    //else
                                    //{
                                    //    if (founddevice.Contains("usb") || founddevice.Contains("serial"))
                                    //    {
                                    //        Comport = NewList[0];
                                    //        ingenicofound = true;
                                    //        break;
                                    //    }
                                    //}
                                    //}
                                    //else
                                    //{
                                    //    if (founddevice.Contains(lowerdeviceName))
                                    //    {
                                    //        Comport = NewList[0];
                                    //        ingenicofound = true;
                                    //        break;
                                    //    }
                                }


                        }
                        //if (!ingenicofound)
                        //{
                        //    foreach (string s in portList)
                        //    {
                        //        String[] NewList = s.Split('-');
                        //        string founddevice = NewList[1].ToLower();
                        //        if (founddevice.Contains("usb") || founddevice.Contains("serial"))
                        //        {
                        //            Comport = NewList[0];                                   
                        //            break;
                        //        }
                        //    }
                        //}
                    }
                    else
                    {
                        log.Info("No Device Connected");
                    }

                   
                }
                return Comport;
            }
            catch (Exception e )
            {
                // log.Error(e);
                log.Error(e);
                return Comport;
                
            }

        }
        public static void EditINI(String Comport)
        {
            try
            {
              
                String iniPath = System.Configuration.ConfigurationManager.AppSettings["iniPath"];
                StringBuilder newFile = new StringBuilder();
                string temp = "";
                string[] file = File.ReadAllLines(@iniPath);
                foreach (string line in file)
                {
                    if (line.Contains("PORT="))
                    {
                        String NewComport = "PORT=" + Comport;
                        temp = line.Replace(line, NewComport);
                        newFile.Append(temp + "\r\n");
                        continue;
                    }
                    newFile.Append(line + "\r\n");
                }
                File.WriteAllText(@iniPath, newFile.ToString());
            }
            catch (Exception e)
            {
                log.Error(e);

            }

        }
        public static void Start()
        {
            try
            {
                //bool log_Debug = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["log_Debug"]);

                //log.Info(string.Format("Updating INI file to change comport"));
                String Comport = getComports();
                if (String.IsNullOrEmpty(Comport))
                {

                }
                else {
                    EditINI(Comport);
                }
                
            }
            catch (Exception e)
            {
                log.Error(e);

            }
           

        }
    }

}
