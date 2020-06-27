using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFTConnectSvc
{
    public class Utils
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region VALIDATE SALE TRANSACTIONS
        public static bool validSaleRequest(RequestEBL req, ref string msg)
        {
            return validSaleRequest(req.Acquirer, req.Amount, req.CashBack, req.TillNO, req.TransKey, "100.1.0", ref msg);
        }
        public static bool validSaleRequest(string mobileNo, string transactionRefNo, string tillNo, string amount, string version, ref string errMsg)
        {
            Validation val = new Validation();
            
            // verify transaction amount
            bool valid = val.IsPositiveNumber(amount);
            if (!valid) {
                errMsg = "REQ.SALE - Invalid Amount provided";
                return false;
            }

            if (string.IsNullOrEmpty(mobileNo))
            {
                errMsg = "REQ.SALE - Mobile Number not specified";
                return false;
            }
            return valid;
        }
        public static bool validSaleRequest(string acquirer, string amount, string cashBack, string tillNO, string transKey, string version, ref string msg)
        {
            Validation val = new Validation();
            bool valid ;
           // bool valid = val.IsValidVersion(version);
            //if (!valid)
            //{
            //    msg = "REQ.SALE - Application Version mismatch";
            //    return false;
            //}

            // Verify processing acquirer
            if (string.IsNullOrEmpty(acquirer))
            {
                msg = "REQ.SALE - Acquirer not specified";
                return false;
            }
            else
            {
                valid = val.IsValidBank(acquirer);
                if (!valid)
                {
                    msg = "REQ.SALE - Acquirer " + acquirer + " has not been implemented";
                    return false;
                }
            }

            //empty string for amnt
            if (string.IsNullOrEmpty(amount))
            {
                msg = "REQ.SALE - Trans.Amount not specified";
                
                valid = false;
            }

            //valid number for amount
            valid = val.IsNumber(amount);
            if (!valid)
            {
                msg = "REQ.SALE - Invalid Trans.Amount: " + amount;
                
                return false;
            }

            //cashback provided
            if (!string.IsNullOrEmpty(cashBack))
            {
                valid = val.IsNumber(cashBack);
                if (!valid)
                {
                    msg = "REQ.SALE - Invalid Cashback Amount: " + cashBack;
                    
                    return false;
                }
            }

            //must have transaction key also number
            if (valid)
            {
                valid = string.IsNullOrEmpty(transKey) ? false : true;
                if (!valid)
                {
                    msg = "REQ.SALE - Trans.Key not provided";
                    
                    return false;
                }
            }

            return valid;
        }
        #endregion

        #region VALIDATE REVERSAL TRANSACTIONS
        public static bool validReversalRequest(ReversalRequest req, ref string msg)
        {
            return validReversalRequest(req.Acquirer, req.Amount, req.RRN, req.Version, ref msg);
        }

        public static bool validReversalRequest(string acquirer, string amount, string rrn, string version, ref string msg)
        {
            Validation val = new Validation();

            bool valid = true;

            valid = val.IsValidVersion(version);
            if (!valid)
            {
                msg = "REQ.SALE - Application Version mismatch";
                return false;
            }

            // Verify processing acquirer
            if (string.IsNullOrEmpty(acquirer))
            {
                msg = "REQ.REVERSAL - Acquirer not specified";
                return false;
            }
            else
            {
                valid = val.IsValidBank(acquirer);
                if (!valid)
                {
                    msg = "REQ.REVERSAL - Acquirer " + acquirer + " has not been implemented";
                    return false;
                }
            }

            //empty string for amnt
            if (string.IsNullOrEmpty(amount))
            {
                msg = "REQ:REVERSAL - Trans.Amount not specified";
                return false;
            }

            //valid number for amount
            valid = val.IsNumber(amount);
            if (!valid)
            {
                msg = "REQ:REVERSAL - Invalid Trans.Amount: " + amount;
                return false;
            }

            //must have transaction key also number
            if (valid)
            {
                valid = string.IsNullOrEmpty(rrn) ? false : true;
                if (!valid)
                {
                    msg = "REQ:REVERSAL - RRN not specfied";
                    return false;
                }
                else {
                    if (rrn.Length < 12) {
                        msg = "REQ:REVERSAL - RRN has invalid number of characters";
                        return false;
                    }
                }
            }

            return valid;

        }
        #endregion

        #region OS RELATED
        public static string GetOS()
        {
            string version = GetOSVersion();
            if (string.Equals(version, "5.1"))
                return "WinXP";
            else if (string.Equals(version, "5.2"))
                return "WinXP/03";
            else if (string.Equals(version, "6.0"))
                return "WinVista/08";
            else if (string.Equals(version, "6.1"))
                return "Win7/08R2";
            else if (string.Equals(version, "6.2"))
                return "Win8/12";
            else
                return "Unknown";
        }
        public static string GetOSVersion() {
            return string.Format("{0}.{1}", System.Environment.OSVersion.Version.Major, System.Environment.OSVersion.Version.Minor);
        }
        #endregion
    }
}
