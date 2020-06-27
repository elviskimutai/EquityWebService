using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArcComHelper
{
    class Utils
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static string formatAmount(string amnt, bool toPinpad)
        {
            string sAmount = "0";
            try
            {
                if (toPinpad)
                    sAmount = (Convert.ToDouble(amnt) * 100).ToString();
                else
                    sAmount = (Convert.ToDouble(amnt) / 100.0).ToString();
            }
            catch (Exception e) {
                log.Error(e);
            }
            return sAmount;
        }

        public static string maskPAN(string pan)
        {
            string bin_n_pad_n_trail = "";
            try
            {
                //check for empty string
                if (string.IsNullOrEmpty(pan)) return pan;

                //check the length of pan
                int panLen = pan.Length;
                if (panLen <= 10) return pan;

                //mask pan
                int padLen = panLen - 10;
                int padEndMark = panLen - 4;

                string bin = pan.Substring(0, 6);
                bin_n_pad_n_trail = bin.PadRight(6 + padLen, 'x') + pan.Substring(padEndMark, 4);
            }
            catch (Exception e) {
                log.Error(e);
            }
            return bin_n_pad_n_trail;
        }
    }
}
