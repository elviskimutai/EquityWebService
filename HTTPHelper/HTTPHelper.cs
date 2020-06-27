using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace HTTPHelper
{
    public class HTTPHelper
    {
        #region variables
        private string _url;
        private string _postData;
        private string _contentType;
        private const int TIMEOUT = 20000;
        private StreamWriter _requestWriter;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        #region properties
        public string Url { get { return this._url; } set { this._url = value; }}
        public string PostData { get { return this._postData; } set { this._postData = value; } }
        public string ContentType { get { return this._contentType; } set { this._contentType = value; } }
        #endregion

        public string HttpPost() {
            string ret = string.Empty;
            bool log_Debug = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["log_Debug"]);

            var webRequest = System.Net.WebRequest.Create(this._url) as HttpWebRequest;
            if (webRequest != null)
            {
                webRequest.Method = "POST";
                webRequest.ServicePoint.Expect100Continue = false;
                webRequest.Timeout = TIMEOUT;

                //var username = "usernameForYourApi";
                //var password = "passwordForYourApi";
                //var bytes = Encoding.UTF8.GetBytes(username + ":" + password);
                //webRequest.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(bytes));

                webRequest.ContentType = this._contentType;
                //POST the data.
                using (this._requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                {
                    this._requestWriter.Write(this._postData);
                }
            }

            HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
            Stream resStream = resp.GetResponseStream();
            StreamReader reader = new StreamReader(resStream);
            ret = reader.ReadToEnd();

            return ret;
        }

        public string HttpGet()
        {
            string ret = "";
            bool log_Debug = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["log_Debug"]);

            //specify to use TLS 1.2 as default connection
            //System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            //System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            //ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);

            var webRequest = System.Net.WebRequest.Create(this._url) as HttpWebRequest;
            if (webRequest != null)
            {
                webRequest.Method = "GET";
                webRequest.ServicePoint.Expect100Continue = false;
                webRequest.Timeout = TIMEOUT;

                //var username = "usernameForYourApi";
                //var password = "passwordForYourApi";
                //var bytes = Encoding.UTF8.GetBytes(username + ":" + password);
                //webRequest.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(bytes));

                webRequest.ContentType = this._contentType;
            }

            HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
            Stream resStream = resp.GetResponseStream();
            StreamReader reader = new StreamReader(resStream);
            ret = reader.ReadToEnd();

            if (log_Debug)
                log.Debug(
                    string.Format("Server responded with {0}", ret));

            return ret;
        }
    }
}
