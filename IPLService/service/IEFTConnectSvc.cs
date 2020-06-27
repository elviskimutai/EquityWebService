using System;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EFTConnectSvc
{
    [ServiceContract]
    public interface IEFTConnectSvc
    {
        // Equity PinPad
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "saleEBL/{amount},{cashBack},{tillNO},{transKey},{version}")]
        ResponseEBL saleEBL(string amount, string cashBack, string tillNO, string transKey, string version);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "reversalEBL/{amount},{rrn},{version}")]
        ResponseEBL reversalEBL(string amount, string rrn, string version);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "saleEBL")]
        ResponseEBL execSaleEBL(RequestEBL req);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "reversalEBL")]
        ResponseEBL execReversalEBL(ReversalRequest req);

        // Equity EasyPay
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "saleEZP/{mobileNo},{transactionRefNo},{tillNo},{amount},{version}")]
        ResponseEZP saleEZP(string mobileNo, string transactionRefNo, string tillNo, string amount, string version);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "saleEZP")]
        ResponseEZP execSaleEZP(RequestEZP req);
    }
}
