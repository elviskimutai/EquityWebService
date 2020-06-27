using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace EFTConnectSvc
{
    public class ResponseEZP_tmp
    {
        //private ResponseEZP _data;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ResponseEZP paymentConfirmationResponse { get; set; }
        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //public ResponseEZP data
        //{
        //    get { return this._data; }
        //    set { this._data = value; }
        //}

        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //public string dateOf { get; set; }
        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //public string tillNumber { get; set; }
        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //public string mobileNumber { get; set; }
        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //public float amount { get; set; }
        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //public string timeStamp { get; set; }
        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //public string transactionRefNo { get; set; }
        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //public string servedBy { get; set; }
        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //public string additionalInfo { get; set; }
        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //public string status { get; set; }
        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //public string source { get; set; }
    }
}
