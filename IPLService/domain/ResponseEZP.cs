using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace EFTConnectSvc
{
    [DataContract]
    public class ResponseEZP
    {
        [DataMember]
        public string tillNumber { get; set; }
        [DataMember]
        public string mobileNumber { get; set; }
        [DataMember]
        public float amount { get; set; }
        [DataMember]
        public string timeStamp { get; set; }
        [DataMember]
        public string transactionRefNo { get; set; }
        [DataMember]
        public string servedBy { get; set; }
        [DataMember]
        public string additionalInfo { get; set; }
        [DataMember]
        public string status { get; set; }
        [DataMember]
        public string source { get; set; }
        [DataMember]
        public string responseCode { get; set; }
        [DataMember]
        public string resultCode { get; set; }
    }
}
