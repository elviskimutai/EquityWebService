using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Newtonsoft.Json;

namespace EFTConnectSvc
{
    class EFTConnectSvc : IEFTConnectSvc
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region SALE TRANSACTIONS
        public String getname(String slip)
        {
            try
            {
                int index1 = slip.IndexOf('*');
                String news = slip.Remove(0, index1);
                String news1 = news.Remove(0, 14);
                int indexrrn = news1.IndexOf("RRN");
                int lastindex = news1.Length - 1;

                news1.Remove(indexrrn, (lastindex - indexrrn)); // to remove text
                String newstring = news1.Remove(indexrrn, (lastindex - indexrrn)); // to remove text
                                                                                   // 
                return (newstring.Trim());
            }
            catch (Exception)
            {
                return "";
                // MessageBox.Show(ex.Message);
            }




        }
         public ResponseEBL saleEBL(string amount, string cashBack, string tillNO, string transKey, string version)
        {
            string acquirer = "EBL";
            ResponseEBL cres = new ResponseEBL();
            try
            {

                bool log_Debug = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["log_Debug"]);

                log.Info(string.Format("Request received from {0}", this.GetClientIP()));


                //VALIDATE THE REQUEST
                if (log_Debug)
                    log.Info(string.Format("REQ.SALE Channel:{0}, Amount:{1}, Cashback:{2}, TillNo:{3}, TransKey:{4}, Version:{5}", acquirer, amount, cashBack, tillNO, transKey, version));

                string errMsg = null;
                bool valid = Utils.validSaleRequest(acquirer, amount, cashBack, tillNO, transKey, version, ref errMsg);
                if (!valid) throw new Exception(errMsg);

                //Check Comports
              //  utilies.Comports.Start();

                //TRIGGER ARCUS DLL THROUGH A FRIEND ;) =======================================================
                ArcComHelper.CArcusDll arcusHelper = new ArcComHelper.CArcusDll();
                Hashtable hsh = arcusHelper.execSale(amount, cashBack, tillNO, transKey, log_Debug);

                //assign data to the response contract class
                cres.Amount = (string)hsh["amount"];
                cres.Cashback = (string)hsh["cashBack"];
                cres.AuthCode = (string)hsh["authCode"];
                cres.RespCode = (string)hsh["respCode"];
                cres.CardExpiry = (string)hsh["cardExpiry"];
                cres.Currency = (string)hsh["currency"];
                cres.Msg = (string)hsh["msg"];
                cres.Pan = (string)hsh["pan"];
                cres.Tid = (string)hsh["tid"];
                cres.MID = (string)hsh["tid"];
                cres.RRN = (string)hsh["rrn"];
                cres.TransactionType = (string)hsh["transType"];
                cres.PaymentDetails = (string)hsh["payDetails"];
                cres.Rfu =(string) hsh["rfu"];
                cres.TransactionID =(string) hsh["transactionID"];
                cres.HoldersName = getname((string) hsh["slip"]);
                cres.ResponseCodeHost =(string) hsh["responseCodeHost"];
                cres.ProviderCode =(string) hsh["providerCode"] ;
                cres.PathParameters =(string) hsh["pathParameters"] ;
                cres.Hash =(string) hsh["hash"] ;
                cres.FileNameResult =(string) hsh["fileNameResult"] ;
                cres.FileNameReport =(string) hsh["fileNameReport"] ;
                cres.FileName =(string) hsh["fileName"];
                cres.EncData =(string) hsh["encData"] ;
                cres.DateTimeHost =(string) hsh["dateTimeHost"] ;
                cres.DateTimeCRM =(string) hsh["dateTimeCRM"] ;
                cres.CRMID =(string) hsh["cRMID"] ;
                cres.CommodityCode =(string) hsh["commodityCode"];
                cres.CardType =(string) hsh["cardType"] ;
                cres.CardEntryMode =(int) hsh["cardEntryMode"] ;
                cres.BIN = (string)hsh["bIN"] ;
                
                
                if (log_Debug)
                    log.Info(
                        string.Format("RES.SALE Channel:{0}, Amount:{1}, Cashback:{2}, TillNo:{3}, TransKey:{4}, RspCode:{5}, AuthCode:{6}, RRN:{7}, PAN:{8}, Msg:{9}, Version:{10}",
                        acquirer, amount, cashBack, tillNO, transKey, cres.RespCode, cres.AuthCode, cres.RRN, cres.Pan, cres.Msg, version));
            }
            catch (Exception e)
            {
                log.Error(e);
                cres.Msg = e.Message;
            }

            return cres;
        }
        public ResponseEZP saleEZP(string mobileNo,string transactionRefNo,string tillNo, string amount, string version)
        {
            ResponseEZP cres = new ResponseEZP();
            string acquirer = "EZP";
            try
            {
                bool log_Debug = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["log_Debug"]);

                log.Info(string.Format("Request received from {0}", this.GetClientIP()));

                //VALIDATE THE REQUEST
                if (log_Debug)
                    log.Info(string.Format("REQ.SALE Channel:{0}, mobileNo:{1}, transactionRefNo:{2}, tillNo:{3}, amount{4}. Version:{5}", acquirer, mobileNo, transactionRefNo, tillNo, amount, version));

                string errMsg = null;
                bool valid = Utils.validSaleRequest(mobileNo, transactionRefNo, tillNo, amount, version, ref errMsg);
                if (!valid) throw new Exception(errMsg);


                //trigger easypay webservice using this friend of ours ;) =======================================================
                HTTPHelper.HTTPHelper httpHelper = new HTTPHelper.HTTPHelper();
                httpHelper.ContentType = "application/json";
                httpHelper.Url = this.GetRequestUrl_EZP(mobileNo, transactionRefNo, tillNo, amount);
                string resp = httpHelper.HttpGet();
                //string resp = "{\"paymentConfirmationResponse\":{\"tillNumber\":\"0766944664\",\"mobileNumber\":\"254722777151\",\"amount\":\"1250\",\"timeStamp\":\"20190205\",\"transactionRefNo\":\"FT588I002637\",\"servedBy\":\"NGENO\",\"additionalInfo\":null,\"status\":\"000\"}}";
                //string resp = "{\"paymentConfirmationResponse\":{\"resultCode\":\"505\"}}";

                //// ealier
                //ResponseEZP_tmp tmp = JsonConvert.DeserializeObject<ResponseEZP_tmp>(resp);
                ////if (tmp.Capacity > 0)
                //if (tmp.paymentConfirmationResponse)
                //{
                //    //cres.additionalInfo = tmp.data[0].additionalInfo;
                //    //cres.amount = tmp.data[0].amount;
                //    //cres.mobileNumber = tmp.data[0].mobileNumber;
                //    //cres.servedBy = tmp.data[0].servedBy;
                //    //cres.source = tmp.data[0].source;
                //    //cres.status = tmp.data[0].status;
                //    //cres.tillNumber = tmp.data[0].tillNumber;
                //    //cres.timeStamp = tmp.data[0].timeStamp;
                //    //cres.transactionRefNo = tmp.data[0].transactionRefNo;
                //    cres = tmp.data;
                //}

                // today - 2019/05/01
                ResponseEZP_tmp tmp = JsonConvert.DeserializeObject<ResponseEZP_tmp>(resp);
                cres = tmp.paymentConfirmationResponse;

                //if (log_Debug)
                //    log.Debug(
                //        string.Format("RES.SALE Channel:{0}, amount:{1}, additionalInfo:{2}, mobileNumber:{3}, servedBy:{4}, source:{5}, status:{6}, tillNumber:{7}, timeStamp:{8}, transactionRefNo:{9}, Version:{10}",
                //        acquirer, cres.amount, cres.additionalInfo, cres.mobileNumber, cres.servedBy, cres.source, cres.status, cres.tillNumber, cres.timeStamp, cres.transactionRefNo, version));
            }
            catch (Exception e)
            {
                log.Error(e);
                cres.additionalInfo = e.Message;
            }

            return cres;
        }
        public ResponseEBL execSaleEBL(RequestEBL creq)
        {

            ResponseEBL res = null;
            try
            {
                var jsonString = JsonConvert.SerializeObject(creq);
                log.Info(
                      "Request------"+ jsonString);
                if (creq != null)
                    res = this.saleEBL(creq.Amount, creq.CashBack, creq.TillNO, creq.TransKey, "100.1.0");
            }
            catch (Exception e)
            {
                log.Error(e);
            }

            return res;
        }
        public ResponseEZP execSaleEZP(RequestEZP creq)
        {
            ResponseEZP res = null;
            try
            {
                if (creq != null)
                    res = this.saleEZP(creq.mobileNo, creq.transactionRefNo, creq.tillNo, creq.amount, creq.Version);
            }
            catch (Exception e)
            {
                log.Error(e);
            }

            return res;
        }

        #endregion

        #region REVERSAL TRANSACTIONS
        public ResponseEBL reversalEBL(string amount, string rrn, string version)
        {
            string acquirer = "EBL";
            ResponseEBL cres = new ResponseEBL();
            try
            {
                bool log_Debug = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["log_Debug"]);

                log.Info(string.Format("Request received from {0}", this.GetClientIP()));

                //VALIDATE THE REQUEST
                if (log_Debug)
                    log.Info(string.Format("REQ.REVERSAL Channel:{0}, Amount:{1}, RRN:{2}, Version:{3}", acquirer, amount, rrn, version));

                string errMsg = null;
                bool valid = Utils.validReversalRequest(acquirer, amount, rrn, version, ref errMsg);

                if (!valid)
                    throw new Exception(errMsg);

                //TRIGGER ARCUS DLL THROUGH A FRIEND ;)
                ArcComHelper.CArcusDll dll = new ArcComHelper.CArcusDll();
                Hashtable hsh = dll.execReversal(amount, rrn, log_Debug);

                //ASSIGN VARIABLES TO RESPONSE CONTRACT CLASS
                cres.Amount = (string)hsh["amount"];
                cres.Cashback = (string)hsh["cashBack"];
                cres.AuthCode = (string)hsh["authCode"];
                cres.RespCode = (string)hsh["respCode"];
                cres.CardExpiry = (string)hsh["cardExpiry"];
                cres.Currency = (string)hsh["currency"];
                cres.Msg = (string)hsh["msg"];
                cres.Pan = (string)hsh["pan"];
                cres.Tid = (string)hsh["tid"];
                cres.MID = (string)hsh["tid"];
                cres.RRN = (string)hsh["rrn"];
                cres.TransactionType = (string)hsh["transType"];
                cres.PaymentDetails = (string)hsh["payDetails"];

                if (log_Debug)
                    log.Info(
                        string.Format("RES.REVERSAL Channel:{0}, Amount:{1}, RRN:{2}, RspCode:{3}, AuthCode:{4}, PAN:{5}, Msg:{6}, Version:{7}",
                        acquirer, amount, cres.RRN, cres.RespCode, cres.AuthCode, cres.Pan, cres.Msg, version));
            }
            catch (Exception ex)
            {
                log.Error(ex);

                cres.Msg = ex.Message;
            }

            return cres;
        }
        public ResponseEBL execReversalEBL(ReversalRequest creq)
        {
            if (creq == null)
                return null;
            else
                return this.reversalEBL(creq.Amount, creq.RRN, creq.Version);
        }
        
        #endregion

        private string GetClientIP() {
            try
            {
                System.ServiceModel.OperationContext context = System.ServiceModel.OperationContext.Current;
                System.ServiceModel.Channels.MessageProperties prop = context.IncomingMessageProperties;
                System.ServiceModel.Channels.RemoteEndpointMessageProperty endpoint = prop[System.ServiceModel.Channels.RemoteEndpointMessageProperty.Name] as System.ServiceModel.Channels.RemoteEndpointMessageProperty;
                return endpoint.Address;
            }
            catch (Exception ex) {
                log.Error(ex);
            }
            return "";
        }
        private string GetRequestUrl_EZP(string mobileNo, string transactionRefNo, string tillNo, string amount)
        {
            // Took positioning of parameters to app.config to make it more flexible

            bool log_Debug = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["log_Debug"]);

            string apiKey = System.Configuration.ConfigurationManager.AppSettings["apiKey"];
            string ezpServer = System.Configuration.ConfigurationManager.AppSettings["EZPConfirmURL"];
            ezpServer = ezpServer.Replace("{mobileNumber}", mobileNo);
            ezpServer = ezpServer.Replace("{tillNumber}", tillNo);
            ezpServer = ezpServer.Replace("{transactionRefNo}", transactionRefNo);
            ezpServer = ezpServer.Replace("{amount}", amount);
            ezpServer = ezpServer.Replace("{ApiKey}", apiKey);

            if (log_Debug)
                log.Debug(
                    string.Format("Server request url {0}", ezpServer));

            return ezpServer;
        }
    }
}
