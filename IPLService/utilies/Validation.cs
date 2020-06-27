﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EFTConnectSvc
{
    public class Validation
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // Function to validate Application's Version Number
        public bool IsValidVersion(String version) {
            string[] inVer = version.Split('.');
            string[] dllVer = typeof(Validation).Assembly.GetName().Version.ToString().Split('.');

            //System.Version verApp = typeof(Validation).Assembly.GetName().Version;
            //System.Diagnostics.Debug.WriteLine("System's Version: " + verApp.ToString());

            //return verApp.ToString() == version;
            return ((inVer[0] == dllVer[0]) && (inVer[1] == dllVer[1]));
        }

        // Function to test for Positive Integers
        public bool IsNaturalNumber(String strNumber)
        {
            Regex objNotNaturalPattern = new Regex("[^0-9]");
            Regex objNaturalPattern = new Regex("0*[1-9][0-9]*");
            return !objNotNaturalPattern.IsMatch(strNumber) &&
            objNaturalPattern.IsMatch(strNumber);
        }

        // Function to test for Positive Integers with zero inclusive
        public bool IsWholeNumber(String strNumber)
        {
            Regex objNotWholePattern = new Regex("[^0-9]");
            return !objNotWholePattern.IsMatch(strNumber);
        }

        // Function to Test for Integers both Positive & Negative
        public bool IsInteger(String strNumber)
        {
            Regex objNotIntPattern = new Regex("[^0-9-]");
            Regex objIntPattern = new Regex("^-[0-9]+$|^[0-9]+$");
            return !objNotIntPattern.IsMatch(strNumber) &&
            objIntPattern.IsMatch(strNumber);
        }

        // Function to Test for Positive Number both Integer & Real
        public bool IsPositiveNumber(String strNumber)
        {
            Regex objNotPositivePattern = new Regex("[^0-9.]");
            Regex objPositivePattern = new Regex(
            "^[.][0-9]+$|[0-9]*[.]*[0-9]+$");
            Regex objTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");
            return !objNotPositivePattern.IsMatch(strNumber) &&
            objPositivePattern.IsMatch(strNumber) &&
            !objTwoDotPattern.IsMatch(strNumber);
        }

        // Function to test whether the string is valid number or not
        public bool IsNumber(String strNumber)
        {
            Regex objNotNumberPattern = new Regex("[^0-9.-]");
            Regex objTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");
            Regex objTwoMinusPattern = new Regex("[0-9]*[-][0-9]*[-][0-9]*");
            String strValidRealPattern =
            "^([-]|[.]|[-.]|[0-9])[0-9]*[.]*[0-9]+$";
            String strValidIntegerPattern = "^([-]|[0-9])[0-9]*$";
            Regex objNumberPattern = new Regex("(" + strValidRealPattern
            + ")|(" + strValidIntegerPattern + ")");
            return !objNotNumberPattern.IsMatch(strNumber) &&
            !objTwoDotPattern.IsMatch(strNumber) &&
            !objTwoMinusPattern.IsMatch(strNumber) &&
            objNumberPattern.IsMatch(strNumber);
        }

        // Function To test for Alphabets.
        public bool IsAlpha(String strToCheck)
        {
            Regex objAlphaPattern = new Regex("[^a-zA-Z]");
            return !objAlphaPattern.IsMatch(strToCheck);
        }

        // Function to Check for AlphaNumeric.
        public bool IsAlphaNumeric(String strToCheck)
        {
            Regex objAlphaNumericPattern = new Regex("[^a-zA-Z0-9]");
            return !objAlphaNumericPattern.IsMatch(strToCheck);
        }

        public bool IsValidBank(string acquirer)
        {
            bool valid = false;
            switch (acquirer.ToUpper().Trim()) {
                case "EBL":
                    valid = true;
                    break;

                case "EZP":
                    valid = true;
                    break;

                default:
                    valid = false;
                    break;
            }
            return valid;
        }
    }
}
