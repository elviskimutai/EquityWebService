using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Configuration;

namespace ArcComHelper
{
    public class CArcusDll
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Hashtable execSale(string amount, string cashBack, string tillNO, string transKey, bool log_Debug)
        {
            Hashtable hsh = null;
            try
            {
                ARCCOMLib.SAPacketObj preq = new ARCCOMLib.SAPacketObj();
                ARCCOMLib.SAPacketObj pres = new ARCCOMLib.SAPacketObj();
                preq.Amount = Utils.formatAmount(amount, true);
                preq.CashbackAmount = Utils.formatAmount(cashBack, true);
                preq.CurrencyCode = ConfigurationManager.AppSettings["currencyCode"];
                preq.OperationCode = Convert.ToInt32(ConfigurationManager.AppSettings["sale_Op"]);

               // bool con = CheckConnection();
                bool con = true;
                hsh = new Hashtable();

                if (con)
                {
                   
                    ARCCOMLib.PCPOSTConnectorObj svr = new ARCCOMLib.PCPOSTConnectorObj();
                   
                    // svr.
                    int status = svr.Exchange(ref preq, ref pres, 10);
                         
                    //hsh = new Hashtable();
                    hsh["amount"] = Utils.formatAmount(pres.Amount, false);
                    hsh["cashBack"] = Utils.formatAmount(pres.CashbackAmount, false);
                    hsh["authCode"] = pres.AuthorizationCode;
                    hsh["rrn"] = pres.ReferenceNumber;
                    hsh["msg"] = pres.TextResponse;
                    hsh["respCode"] = (string.IsNullOrEmpty(pres.ResponseCodeHost)) ? "999" : ((pres.ResponseCodeHost == "000") ? "00" : pres.ResponseCodeHost);

                    if ((string.IsNullOrEmpty(pres.AuthorizationCode) || string.IsNullOrEmpty(pres.ReferenceNumber))
                        &&
                       (Convert.ToString(pres.ResponseCodeHost) == "000" || Convert.ToString(pres.ResponseCodeHost) == "00"))
                    {
                        hsh["respCode"] = "";
                        hsh["msg"] = "Refer to your Bank";
                    }
    
                    hsh["cardExpiry"] = pres.CardExpiryDate;
                    hsh["currency"] = pres.CurrencyCode;
                    hsh["pan"] = Utils.maskPAN(pres.PAN);
                    hsh["tid"] = pres.TerminalOutID;
                    hsh["transType"] = "Sale";
                    hsh["payDetails"] = pres.PaymentDetails;
                   
                    hsh["rfu"] = pres.RFU;
                    hsh["transactionID"] = pres.TransactionID;
                    hsh["slip"] = pres.Slip;
                    hsh["responseCodeHost"] = pres.ResponseCodeHost;
                    hsh["providerCode"] = pres.ProviderCode;
                    hsh["pathParameters"] = pres.PathParameters;
                    hsh["hash"] = pres.Hash;
                    hsh["fileNameResult"] = pres.FileNameResult;
                    hsh["fileNameReport"] = pres.FileNameReport;
                    hsh["fileName"] = pres.FileName;
                    hsh["encData"] = pres.EncData;
                    hsh["dateTimeHost"] = pres.DateTimeHost;
                    hsh["dateTimeCRM"] = pres.DateTimeCRM;
                    hsh["cRMID"] = pres.CRMID;
                    hsh["commodityCode"] = pres.CommodityCode;
                    hsh["cardType"] = pres.CardType;
                    hsh["cardEntryMode"] = pres.CardEntryMode;
                    hsh["bIN"] = pres.BIN;
                    

                }
                else
                {
                    hsh["amount"] = amount;
                    hsh["respCode"] = "402";
                    hsh["msg"] = "Connection broke. Transaction could not be completed.";
                }

            }
            catch (Exception ex)
            {
                log.Error(ex);
            }

            return hsh;
        }

        public Hashtable execReversal(string amount, string rrn, bool log_Debug)
        {
            Hashtable hsh = null;
            try
            {
 
                ARCCOMLib.SAPacketObj preq = new ARCCOMLib.SAPacketObj();
                ARCCOMLib.SAPacketObj pres = new ARCCOMLib.SAPacketObj();

                preq.ReferenceNumber = rrn;
                preq.Amount = Utils.formatAmount(amount, true);
                preq.CashbackAmount = Utils.formatAmount("0", true);
                preq.CurrencyCode = ConfigurationManager.AppSettings["currencyCode"];
                preq.OperationCode = Convert.ToInt32(ConfigurationManager.AppSettings["reversal_Op"]);
                
                bool con = CheckConnection();
                hsh = new Hashtable();

                if (con)
                {
                    ARCCOMLib.PCPOSTConnectorObj svr = new ARCCOMLib.PCPOSTConnectorObj();
                    int status = svr.Exchange(ref preq, ref pres, 12000);

                    hsh["amount"] = Utils.formatAmount(pres.Amount, false);
                    hsh["cashBack"] = Utils.formatAmount(pres.CashbackAmount, false);
                    hsh["authCode"] = pres.AuthorizationCode;
                    hsh["msg"] = pres.TextResponse;
                    hsh["rrn"] = pres.ReferenceNumber;
                    hsh["respCode"] = string.IsNullOrEmpty(pres.ResponseCodeHost) ? "999" : ((pres.ResponseCodeHost == "000") ? "00" : pres.ResponseCodeHost);
                    hsh["cardExpiry"] = pres.CardExpiryDate;
                    hsh["currency"] = pres.CurrencyCode;
                    hsh["pan"] = Utils.maskPAN(pres.PAN);
                    hsh["tid"] = pres.TerminalOutID;
                    hsh["transType"] = "Reversal";
                    hsh["payDetails"] = pres.PaymentDetails;
                }
                else
                {
                    hsh["rrn"] = rrn;
                    hsh["amount"] = amount;
                    hsh["respCode"] = "402";
                    hsh["msg"] = "Connection broke. Transaction could not be completed.";
                }  
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }

            return hsh;
        }

        private bool CheckConnection() {
            bool success = false;
            string ip = ConfigurationManager.AppSettings["bankServerIP"];
            int port = Convert.ToInt32(ConfigurationManager.AppSettings["bankServerPort"]);
            int timeout = Convert.ToInt32(ConfigurationManager.AppSettings["connectionTimeout"]);

            try
            {
                using (System.Net.Sockets.TcpClient tcp = new System.Net.Sockets.TcpClient())
                {
                    IAsyncResult ar = tcp.BeginConnect(ip, port, null, null);
                    System.Threading.WaitHandle wh = ar.AsyncWaitHandle;
                    try
                    {
                        if (!ar.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(timeout), false))
                        {
                            tcp.Close();
                            throw new TimeoutException();
                        }
                        success = tcp.Connected;
                        tcp.EndConnect(ar);
                    }
                    finally
                    {
                        wh.Close();
                    }
                }
            }
            catch (Exception e) {
                log.Error(e);
            }
            
            return success;
        }
    }
}
