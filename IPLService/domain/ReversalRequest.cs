using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace EFTConnectSvc
{
    [DataContract]
    public class ReversalRequest
    {
        [DataMember]
        public String Acquirer { get; set; }
        [DataMember]
        public String Amount { get; set; }
        [DataMember]
        public String RRN { get; set; }
        [DataMember]
        public String Version { get; set; }
    }
}
