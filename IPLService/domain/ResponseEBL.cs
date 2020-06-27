using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace EFTConnectSvc
{
    [DataContract]
    public class ResponseEBL
    {
        [DataMember]
        public String Amount { get; set; }
        [DataMember]
        public String Cashback { get; set; }
        [DataMember]
        public String RespCode { get; set; }
        [DataMember]
        public String Msg { get; set; }
        [DataMember]
        public String RRN { get; set; }
        [DataMember]
        public String Pan { get; set; }
        [DataMember]
        public String CardExpiry { get; set; }
        [DataMember]
        public String Currency { get; set; }
        [DataMember]
        public String Tid { get; set; }
        [DataMember]
        public String MID { get; set; }
        [DataMember]
        public String TransactionType { get; set; }
        [DataMember]
        public String AuthCode { get; set; }
        [DataMember]
        public String PaymentDetails { get; set; }

        //added
        [DataMember]
        public String Rfu { get; set; }
        [DataMember]
        public String TransactionID { get; set; }
        [DataMember]
        public String HoldersName { get; set; }
        [DataMember]
        public String ResponseCodeHost { get; set; }
        [DataMember]
        public String ProviderCode { get; set; }
        [DataMember]
        public String PathParameters { get; set; }
        [DataMember]
        public String Hash { get; set; }
        [DataMember]
        public String FileNameResult { get; set; }
        [DataMember]
        public String FileNameReport { get; set; }
        [DataMember]
        public String FileName { get; set; }
        [DataMember]
        public String EncData { get; set; }
        [DataMember]
        public String DateTimeHost { get; set; }
        public String DateTimeCRM { get; set; }
        public String CRMID { get; set; }
        [DataMember]
        public String CommodityCode { get; set; }
        [DataMember]
        public String CardType { get; set; }
        [DataMember]
        public int CardEntryMode { get; set; }
        [DataMember]
        public String  BIN { get; set; }
    }
}
