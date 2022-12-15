using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using AdaniCall.Utility.Common;
using System.Text.RegularExpressions;
using AdaniCall.Utility.Common;
//using CommonUtilities;
namespace AdaniCall.Utility
{
    public static class StringFilter
    {
        private static readonly string _module = "AdaniCallQR.Utility.StringFilter";

        public static string Change_Endwith_FolderPath(string strPath)
        {
            if (Convert.ToString(strPath).Trim() != "")
            {
                string strFolderPath = strPath;
                strFolderPath = strFolderPath.Replace(@"/", @"\");
                strFolderPath = strFolderPath.EndsWith(@"\") ? strFolderPath : strFolderPath + @"\";
                return strFolderPath;
            }
            else
            {
                return "";
            }
        }
      
        public static string CombineFolderPath(string pstrRootPath, string FolderPath)
        {
            if (Convert.ToString(pstrRootPath).Trim() != "")
            {
                string strOutputFolderPath = pstrRootPath;
                string strFolderPath = FolderPath;
                strOutputFolderPath = strOutputFolderPath.Replace(@"/", @"\");
                strOutputFolderPath = strOutputFolderPath.EndsWith(@"\") ? strOutputFolderPath : strOutputFolderPath + @"\";

                if (Convert.ToString(strFolderPath).Trim() != "")
                {
                    strFolderPath = strFolderPath.Replace(@"/", @"\");
                    strOutputFolderPath = strOutputFolderPath + Convert.ToString(strFolderPath.EndsWith(@"\") ? strFolderPath : strFolderPath + @"\");

                }
                return strOutputFolderPath;
            }
            else
            {
                return "";
            }
        }

        public static string CreateFilePath(string strRootPath, string FileName)
        {
            if (Convert.ToString(strRootPath).Trim() != "" && Convert.ToString(FileName).Trim() != "" && Path.GetFileName(FileName) != "")
            {
                string strFolderPath = strRootPath;
                strFolderPath = strFolderPath.Replace(@"/", @"\");
                strFolderPath = strFolderPath.EndsWith(@"\") ? strFolderPath : strFolderPath + @"\";
                strFolderPath = strFolderPath + FileName.Replace(@"/", @"\");
                return strFolderPath;
            }
            else
            {
                return "";
            }

        }
        public static string GetValidFilename(string input)
        {
            try
            {
                return Regex.Replace(input, "[\\\\/:*?\"<>|+]", "");
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetValidFilename(input=" + input + ")", ex.Source, ex.Message);
                return input;
            }
        }

        public static bool IsEmail(string email)
        {
                    string MatchEmailPattern =
           @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
    + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
    + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
    + @"([a-zA-Z0-9]+[\w-]+\.)+[a-zA-Z]{1}[a-zA-Z0-9-]{1,23})$";


            if (email != null) return Regex.IsMatch(email, MatchEmailPattern);
            else return false;
        }


        public static char GetInitialChar(string input)
        {
            char retVal = ' ';
            try
            {
                if (!string.IsNullOrWhiteSpace(input) && input.Trim().Length > 1)
                    retVal = Convert.ToChar(input.Trim().Substring(0, 1));
                else if (input.Trim().Length == 1)
                    retVal = Convert.ToChar(input.Trim());
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetInitialChar(input=" + input + ")", ex.Source, ex.Message);
            }
            return retVal;
        }

        public static string GetEmailName(string input)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(input))
                {
                    if (input.ToLower().StartsWith("doctor") && input.Length>6)
                        input = input.Remove(0,6);
                    if (input.ToLower().StartsWith("doc") && input.Length > 3)
                        input = input.Remove(0, 3);
                    if (input.ToLower().StartsWith("dr.") && input.Length > 3)
                        input = input.Remove(0, 3);
                    if (input.ToLower().StartsWith("dr") && input.Length > 2)
                        input = input.Remove(0, 2);

                    input = input.Trim(' ');
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetEmailName(input=" + input + ")", ex.Source, ex.Message);
            }
            return input;
        }         


        public static string GetInitials(string firstName)
        {
            string retVal = string.Empty;
            try
            {
                if (!string.IsNullOrWhiteSpace(firstName))
                {
                    string[] arrName = firstName.Split(' ');
                    if (arrName.Count() > 0)
                    {
                        if (arrName[0].Length > 1)
                            retVal = arrName[0].Substring(0, 1);
                    }
                    if (arrName.Count() > 1)
                    {
                        if (arrName[1].Length > 1)
                            retVal += arrName[1].Substring(0, 1);
                    }
                    if (!string.IsNullOrWhiteSpace(retVal))
                        retVal = retVal.ToUpper();
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetInitials(firstName=" + firstName + ")", ex.Source, ex.Message);
            }
            return retVal;
        }

        public static string GetValidUrl(string url)
        {
            if (!string.IsNullOrWhiteSpace(url))
            {
                url = url.Trim().TrimEnd('/');
                if (url.Contains('.') && !url.ToLower().StartsWith("http"))
                {
                    //var regex = new Regex(Regex.Escape("www."));
                    //url = "http://www." + (url.ToLower().StartsWith("www.") ? regex.Replace(url, "", 1).Trim() : url.Trim());
                    url = "http://www." + (url.ToLower().StartsWith("www.") ? url.Substring(4).Trim() : url.Trim());
                }
            }
            return url;
        }

        //public static int GetAge(DateTime dtDOB)
        //{
        //    int Age = 0;
        //    try
        //    {
        //        //Today's date.
        //        DateTime today = DateTime.Now;
        //        // Calculate the age.
        //        Age = today.Year - dtDOB.Year;
        //        // Go back to the year the person was born in case of a leap year
        //        if (dtDOB.Date > today.AddYears(-Age)) Age--;
        //    }
        //    catch (Exception ex)
        //    {
        //          Log.WriteLog(_module, "GetAge(dtDOB=" + dtDOB + ")", ex.Source, ex.Message, ex);
        //    }
        //    return Age;
        //}


        public static int GetAge(DateTime dtDOB, string AgeType = "Year")
        {
            int Age = 0;
            var _ageType = AgeType == null ? "Year" : AgeType;
            try
            {
                //Today's date.
                DateTime today = DateTime.Now;
                if (_ageType == "Month")
                {
                    var _TotalDays = today.Subtract(dtDOB).TotalDays;
                    var totalMonths =((_TotalDays / 365) * 12);
                    Age = Convert.ToInt32(Math.Round(totalMonths));
                }
                else
                {                    
                    // Calculate the age.
                    Age = today.Year - dtDOB.Year;
                    // Go back to the year the person was born in case of a leap year
                    if (dtDOB.Date > today.AddYears(-Age)) Age--;
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetAge(dtDOB=" + dtDOB + ")", ex.Source, ex.Message, ex);
            }
            return Age;
        }


        public static DateTime GetDOB(int Age, string AgeType="Year")
        {
            var _ageType = AgeType == null ? "Year" : AgeType;
            DateTime dtDob = DateTime.Now;
            try
            {
                if (_ageType == "Month")
                {
                    dtDob = dtDob.AddMonths(-Age);                  
                }
                else
                {
                    dtDob = dtDob.AddYears(-Age);  
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDOB(Age:" + Age + ")", ex.Source, ex.Message, ex);
            }
            return dtDob;
        }

        public static string PadZero(int i)
        {
            if (i < 10)
            {
                return "0" + i.ToString();
            }
            else
            {
                return i.ToString();
            }
        }

        public static string MaskPhone(string PhoneNo, string Message = "")
        {
            try 
	        {	 
                string NumToMask = "";
                string MaskedNum = "";
                if (PhoneNo != "")
                {
                    NumToMask = PhoneNo.Substring(3, 6);
                    if (Message != "")
                    {
                        MaskedNum = PhoneNo.Replace(NumToMask, "xxxxxx");
                        Message = Message.Replace(PhoneNo, MaskedNum);
                        return Message;
                    }
                    else
                    {
                        PhoneNo = PhoneNo.Replace(NumToMask, "xxxxxx");
                        return PhoneNo;
                    }
                }
                else
                {
                    if (Message != "")
                        return Message;
                    else
                        return PhoneNo;
                }
	        }
	        catch (Exception ex)
	        {
                if (Message != "")
                    return Message;
                else
		            return PhoneNo;
	        }
        }
    }
}
