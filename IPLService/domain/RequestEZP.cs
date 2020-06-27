using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EFTConnectSvc
{
    [DataContract]
    public class RequestEZP
    {
        [DataMember]
        public String mobileNo { get; set; }
        [DataMember]
        public String transactionRefNo { get; set; }
        [DataMember]
        public String tillNo { get; set; }
        [DataMember]
        public String amount { get; set; }
        [DataMember]
        public String Version { get; set; }
    }
}
