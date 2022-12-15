using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Collections.Generic;
using System.Text;
using AdaniCall.Utility.Common;
/// <summary>
/// Summary description for Conversion
/// </summary>
namespace AdaniCall.Business.DataAccess.DataAccessLayer.General
{
    public static class Conversion
    {
        public static double? DBToDouble(object value)
        {
            return (Convert.IsDBNull(value)) ? null : (double?)Convert.ToDouble(value);
        }
        public static long? DBTolong(object value)
        {
            return (Convert.IsDBNull(value) || value.ToString().Trim() == "") ? null : (long?)Convert.ToInt64(value);
        }
        public static DateTime? DBToDateTime(object value)
        {
            return (Convert.IsDBNull(value) || value.ToString().Trim() == "") ? null : (DateTime?)Convert.ToDateTime(value);
        }
        public static int? DBToInt(object value)
        {
            return (Convert.IsDBNull(value) || value.ToString().Trim() == "") ? null : (int?)Convert.ToInt32(value);
        }
        public static char? DBToChar(object value)
        {
            return (Convert.IsDBNull(value) || value.ToString().Trim() == "") ? null : (char?)Convert.ToChar(value);
        }

        //Conversion Functions to set the Command Parameters From Object Properties
        public static object ValueToDB(object value)
        {
            return (value == null) ? (object)DBNull.Value : value;
        }

        public static DateTime GetNotNullDateTime(DateTime? value)
        {
            return (value == null) ? Convert.ToDateTime(0) : Convert.ToDateTime(value);
        }

        public static long GetNotNullLong(long? value)
        {
            return (value == null) ? 0 : Convert.ToInt64(value);
        }
        public static int GetNotNullInt(int? value)
        {
            return (value == null) ? 0 : Convert.ToInt32(value);
        }
        public static double GetNotNullDouble(double? value)
        {
            return (value == null) ? 0 : Convert.ToDouble(value);
        }
        public static string GetNotNullString(string value)
        {
            return (value == null) ? "" : value;
        }

        public static string XmlEncode(string xmlString)
        {
            //return xmlString.Replace('"', '|').Replace('<','[').Replace('>',']').Replace('&','~');
            return "";
        }

        public static string XmlDecode(string xmlString)
        {
            return xmlString.Replace('|', '"').Replace('[', '<').Replace(']', '>').Replace('~', '&');
        }

        public static double StringToDouble(string number, int precision)
        {
            try
            {
                return Convert.ToDouble(number.Substring(0, number.Length - precision) + "." + number.Substring(number.Length - precision, precision));
            }
            catch (Exception ex)
            {
                Log.WriteLog("Getconvertion class", "StringToDouble", ex.Source, ex.Message);
                return 0;
            }
        }

        public static string CurrencyToWord(string MyNumber, string orginalNumber)
        {
            try
            {
                string Temp = "";
                string Paisa = "";
                int DecimalPlace;
                int iCount;
                string Hundreds = "";
                string Words = "";

                string[] Place = new string[9];
                Place[0] = " Thousand ";
                Place[2] = " Lakh ";
                Place[4] = " Crore ";
                Place[6] = " Arab ";
                Place[8] = " Kharab ";

                if (MyNumber == "0" || MyNumber == "")
                {
                    return "";
                }
                else
                {

                    // Convert MyNumber to a string, trimming extra spaces.
                    MyNumber = System.Convert.ToString(MyNumber).ToString().Trim(' ');

                    // Find decimal place.
                    DecimalPlace = (int)(MyNumber.ToString().IndexOf(".", 0) + 1);

                    // If we find decimal place...
                    if (DecimalPlace > 0)
                    {
                        // Convert Paisa
                        Temp = ((string)(MyNumber.ToString().Substring(DecimalPlace) + "00")).Substring(0, 2);
                        Paisa = " and " + ConvertTens(Temp) + " Paisa";

                        // Strip off paisa from remainder to convert.
                        MyNumber = System.Convert.ToString(MyNumber.ToString().Substring(0, DecimalPlace - 1)).Trim(' ');
                        orginalNumber = System.Convert.ToString(MyNumber.ToString().Substring(0, DecimalPlace - 1)).Trim(' ');
                        if (MyNumber == "0")
                        {
                            Paisa = "" + ConvertTens(Temp) + " Paisa";
                        }
                    }


                    // Convert last 3 digits of MyNumber to ruppees in word.
                    if ((MyNumber.Length - 3) >= 0)
                    {
                        Hundreds = ConvertHundreds(MyNumber.ToString().Substring(MyNumber.Length - 3));
                        // Strip off last three digits
                        MyNumber = MyNumber.ToString().Substring(0, MyNumber.Length - 3);
                    }

                    iCount = 0;
                    if (orginalNumber.Length <= 2)
                    {
                        while (MyNumber != "")
                        {

                            Temp = MyNumber.ToString().Substring(MyNumber.Length - 1);
                            if (MyNumber.Length == 1)
                            {
                                Words = ConvertDigit(Temp) + Words;
                                MyNumber = MyNumber.ToString().Substring(0, MyNumber.Length - 1);

                            }
                            else
                            {
                                Words = ConvertTens(Temp) + Words;
                                MyNumber = MyNumber.ToString().Substring(0, MyNumber.Length - 2);
                            }
                            iCount = iCount + 2;
                        }
                    }
                    else
                    {
                        while (MyNumber != "")
                        {
                            if (MyNumber.Length == 1)
                                Temp = MyNumber.ToString().Substring(MyNumber.Length - 1);
                            else
                                Temp = MyNumber.ToString().Substring(MyNumber.Length - 2);

                            if (MyNumber.Length == 1)
                            {
                                Words = ConvertDigit(Temp) + Place[iCount] + Words;
                                MyNumber = MyNumber.ToString().Substring(0, MyNumber.Length - 1);

                            }
                            else if (MyNumber.Length == 2)
                            {
                                Words = ConvertTens(Temp) + Place[iCount] + Words;
                                MyNumber = MyNumber.ToString().Substring(0, MyNumber.Length - 2);
                            }
                            else
                            {
                                Words = ConvertTens(Temp) + Place[iCount] + Words;
                                MyNumber = MyNumber.ToString().Substring(0, MyNumber.Length - 2);
                            }
                            iCount = iCount + 2;
                        }
                    }
                }
                return "Rupees " + Words + Hundreds + Paisa;
            }
            catch (Exception ex)
            {
                Log.WriteLog("Convertion to Word", "CurrencyToWord", ex.Source, ex.Message);
                return "error - not converted!";
            }
        }

        private static string ConvertHundreds(string MyNumber)
        {
            try
            {
                string Result = "";

                // Exit if there is nothing to convert.
                if (MyNumber == "0" || MyNumber == "")
                {
                    return "";
                }
                else
                {

                    // Append leading zeros to number.
                    MyNumber = ((string)("000" + MyNumber.ToString())).Substring(((string)("000" + MyNumber.ToString())).Length - 3);

                    // Do we have a hundreds place digit to convert?
                    if (MyNumber.ToString().Substring(0, 1) != "0")
                    {
                        Result = ConvertDigit(MyNumber.ToString().Substring(0, 1)) + " Hundred ";
                    }

                    // Do we have a tens place digit to convert?
                    if (MyNumber.ToString().Substring(1, 1) != "0")
                    {
                        Result = Result + ConvertTens(MyNumber.ToString().Substring(1));
                    }
                    else
                    {
                        // If not, then convert the ones place digit.
                        Result = Result + ConvertDigit(MyNumber.ToString().Substring(2));
                    }
                }
                return Result.Trim(' ');
            }
            catch (Exception ex)
            {

                Log.WriteLog("Convertion to Word", "ConvertHundreds", ex.Source, ex.Message);
                return "error - not converted!";
            }
        }

        // Conversion for tens
        //*****************************************
        private static string ConvertTens(string MyTens)
        {
            try
            {
                string Result = null;

                // Is value between 10 and 19?
                if (MyTens.ToString().Substring(0, 1) == "1")
                {
                    switch (MyTens)
                    {
                        case "10":
                            Result = "Ten";
                            break;
                        case "11":
                            Result = "Eleven";
                            break;
                        case "12":
                            Result = "Twelve";
                            break;
                        case "13":
                            Result = "Thirteen";
                            break;
                        case "14":
                            Result = "Fourteen";
                            break;
                        case "15":
                            Result = "Fifteen";
                            break;
                        case "16":
                            Result = "Sixteen";
                            break;
                        case "17":
                            Result = "Seventeen";
                            break;
                        case "18":
                            Result = "Eighteen";
                            break;
                        case "19":
                            Result = "Nineteen";
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    // .. otherwise it's between 20 and 99.
                    switch (MyTens.ToString().Substring(0, 1))
                    {
                        case "2":
                            Result = "Twenty ";
                            break;
                        case "3":
                            Result = "Thirty ";
                            break;
                        case "4":
                            Result = "Forty ";
                            break;
                        case "5":
                            Result = "Fifty ";
                            break;
                        case "6":
                            Result = "Sixty ";
                            break;
                        case "7":
                            Result = "Seventy ";
                            break;
                        case "8":
                            Result = "Eighty ";
                            break;
                        case "9":
                            Result = "Ninety ";
                            break;
                        default:
                            break;
                    }

                    // Convert ones place digit.
                    Result = Result + ConvertDigit(MyTens.ToString().Substring(MyTens.Length - 1));
                }

                return Result;
            }
            catch (Exception ex)
            {

                Log.WriteLog("Convertion to Word", "ConvertTens", ex.Source, ex.Message);
                return "error - not converted!";
            }
        }

        private static string ConvertDigit(string MyDigit)
        {
            try
            {
                string tempConvertDigit = null;
                switch (MyDigit)
                {
                    case "1":
                        tempConvertDigit = "One";
                        break;
                    case "2":
                        tempConvertDigit = "Two";
                        break;
                    case "3":
                        tempConvertDigit = "Three";
                        break;
                    case "4":
                        tempConvertDigit = "Four";
                        break;
                    case "5":
                        tempConvertDigit = "Five";
                        break;
                    case "6":
                        tempConvertDigit = "Six";
                        break;
                    case "7":
                        tempConvertDigit = "Seven";
                        break;
                    case "8":
                        tempConvertDigit = "Eight";
                        break;
                    case "9":
                        tempConvertDigit = "Nine";
                        break;
                    default:
                        tempConvertDigit = "";
                        break;
                }
                return tempConvertDigit;
            }
            catch (Exception ex)
            {

                Log.WriteLog("Convertion to Word", "ConvertDigit", ex.Source, ex.Message);
                return "error - not converted!";
            }
        }

        /// <summary>
        /// Will return the date in following format [Wednesday, 08 June 1977] in english.
        /// </summary>
        /// <param name="dateTime">a object of DateTime representing the date to be formatted</param>
        /// <returns>string representing the formatted date</returns>
        public static string GetDateInEnglish(DateTime dateTime)
        {
            Dictionary<int, string> monthName = new Dictionary<int, string>();
            monthName.Add(1, "January");
            monthName.Add(2, "February");
            monthName.Add(3, "March");
            monthName.Add(4, "April");
            monthName.Add(5, "May");
            monthName.Add(6, "June");
            monthName.Add(7, "July");
            monthName.Add(8, "August");
            monthName.Add(9, "September");
            monthName.Add(10, "October");
            monthName.Add(11, "November");
            monthName.Add(12, "December");

            Dictionary<int, string> weekdays = new Dictionary<int, string>();
            weekdays.Add(1, "Sunday");
            weekdays.Add(2, "Monday");
            weekdays.Add(3, "Tuesday");
            weekdays.Add(4, "Wednesday");
            weekdays.Add(5, "Thursday");
            weekdays.Add(6, "Friday");
            weekdays.Add(7, "Saturday");

            string month = monthName[dateTime.Month];
            string weekday = weekdays[(int)dateTime.DayOfWeek];

            return weekday + ", " + dateTime.Day + " " + month + " " + dateTime.Year;
        }
        public static string Alldatetime(string InputDateTime, string OutputFormatDate)
        {
            StringBuilder sb = new StringBuilder();

            DateTime dt = Convert.ToDateTime(InputDateTime.Replace('.', '/').Replace("Mär", "Mar").Replace("Mai", "May")
                .Replace("Okt", "Oct").Replace("Dez", "Dec").Replace("Mrz", "Mar"));
            if (OutputFormatDate == "M/d/yyyy")
                sb.Append(string.Format("{0:M/d/yyyy}", dt));
            else if (OutputFormatDate == "MM/dd/yyyy")
                sb.Append(string.Format("{0:MM/dd/yyyy}", dt));
            else if (OutputFormatDate == "MMM/dd/yyyy")
                sb.Append(string.Format("{0:MMM/dd/yyyy}", dt));
            else if (OutputFormatDate == "d/M/yyyy  HH:mm:ss")
                sb.Append(string.Format("{0:d/M/yyyy HH:mm:ss}", dt));
            else if (OutputFormatDate == "d/M/yyyy")
                sb.Append(string.Format("{0:d/M/yyyy}", dt));
            else if (OutputFormatDate == "dd/MM/yyyy")
                sb.Append(string.Format("{0:dd/MM/yyyy}", dt));
            else if (OutputFormatDate == "dd/MMM/yyyy")
                sb.Append(string.Format("{0:dd/MMM/yyyy}", dt));
            else if (OutputFormatDate == "yyyyMMdd")
                sb.Append(string.Format("{0:yyyyMMdd}", dt));
            else if (OutputFormatDate == "MMM")
                sb.Append(string.Format("{0:MMM}", dt));
            else if (OutputFormatDate == "HH:mm:ss")
                sb.Append(string.Format("{0:yyyyMMddHHmmss}", dt));
            else if (OutputFormatDate == "MMM.dd.yyyy")
                sb.Append(string.Format("{0:MMM/dd/yyyy}", dt));

            //sb.Append("Custom DateTime Formatting:<br />");
            //sb.Append(string.Format("{0:y yy yyy yyyy}", dt) + "<br />");
            //sb.Append(string.Format("{0:M MM MMM MMMM}", dt) + "<br />");
            //sb.Append(string.Format("{0:d dd ddd dddd}", dt) + "<br />");
            //sb.Append(string.Format("{0:h hh H HH}", dt) + "<br />");
            //sb.Append(string.Format("{0:m mm}", dt) + "<br />");
            //sb.Append(string.Format("{0:s ss}", dt) + "<br />");
            //sb.Append(string.Format("{0:f ff fff ffff}", dt) + "<br />");
            //sb.Append(string.Format("{0:F FF FFF FFFF}", dt) + "<br />");
            //sb.Append(string.Format("{0:t tt}", dt) + "<br />");
            //// How to display timezone: "-6 -06 -06:00"   time zone
            //sb.Append(string.Format("{0:z zz zzz}", dt) + "<br />");
            ////**************************************************
            ////        Using date separator / (slash) and time sepatator : (colon).
            ////**************************************************
            //sb.Append("<br />");
            //sb.Append("Using date separator / (slash) and time sepatator : (colon):<br />");
            ////These characters will be rewritten to characters defined 
            ////in the current DateTimeFormatInfo.DateSeparator and DateTimeFormatInfo.TimeSeparator.
            //// "20/12/09 20:04:08" - english (en-US)
            //sb.Append(string.Format("{0:d/M/yyyy HH:mm:ss}", dt) + "<br />");
            //// "20.12.2009 20:04:08" - german (de-DE)
            //    // date separator in german culture is "." (so "/" changes to ".")
            //sb.Append(string.Format("{0:d/M/yyyy HH:mm:ss}", dt) + "<br />");
            ////**************************************************
            //// Here are some examples of custom date and time formatting:
            ////**************************************************
            //sb.Append("<br />");
            //sb.Append("Here are some examples of custom date and time formatting:<br />");
            //// month/day numbers without/with leading zeroes
            //// "12/20/2009"
            //sb.Append(string.Format("{0:M/d/yyyy}", dt) + "<br />");
            //// "12/20/2009"
            //sb.Append(string.Format("{0:MM/dd/yyyy}", dt) + "<br />");
            //// day/month names
            //// "Sun, Dec 20, 2009"
            //sb.Append(string.Format("{0:ddd, MMM d, yyyy}", dt) + "<br />");
            //// "Sunday, December 20, 2009"
            //// two/four digit year
            //sb.Append(string.Format("{0:dddd, MMMM d, yyyy}", dt) + "<br />");
            //// "12/20/09"
            //sb.Append(string.Format("{0:MM/dd/yy}", dt) + "<br />");
            //// "12/20/2009"
            //sb.Append(string.Format("{0:MM/dd/yyyy}", dt) + "<br />");
            ////**************************************************
            ////        Standard DateTime Formatting
            ////**************************************************
            //sb.Append("<br />");
            //sb.Append("Standard DateTime Formatting:<br />");
            ////In DateTimeFormatInfo there are defined standard patterns for the current culture. 
            ////For example, property ShortTimePattern is string that contains value h:mm tt for en-US culture 
            ////and value HH:mm for de-DE culture.
            ////Following table shows patterns defined in DateTimeFormatInfo and their values for en-US culture. 
            ////First column contains format specifiers for the String.Format method.
            ////Specifier DateTimeFormatInfo property Pattern value (for en-US culture) 
            ////t ShortTimePattern h:mm tt 
            ////d ShortDatePattern M/d/yyyy 
            ////T LongTimePattern h:mm:ss tt 
            ////D LongDatePattern dddd, MMMM dd, yyyy 
            ////f (combination of D and t) dddd, MMMM dd, yyyy h:mm tt 
            ////F FullDateTimePattern dddd, MMMM dd, yyyy h:mm:ss tt 
            ////g (combination of d and t) M/d/yyyy h:mm tt 
            ////G (combination of d and T) M/d/yyyy h:mm:ss tt 
            ////m, M MonthDayPattern MMMM dd 
            ////y, Y YearMonthPattern MMMM, yyyy 
            ////r, R RFC1123Pattern ddd, dd MMM yyyy HH':'mm':'ss 'GMT' (*) 
            ////s SortableDateTi­mePattern yyyy'-'MM'-'dd'T'HH':'mm':'ss (*) 
            ////u UniversalSorta­bleDateTimePat­tern yyyy'-'MM'-'dd HH':'mm':'ss'Z' (*) 
            ////    (*) = culture independent 
            ////Following examples show usage of standard format specifiers in String.Format method and the resulting output.
            //// "8:04 PM"                         ShortTime
            //sb.Append(string.Format("{0:t}", dt) + "<br />");
            //// "12/20/2009"                        ShortDate
            //sb.Append(string.Format("{0:d}", dt) + "<br />");
            //// "8:04:08 PM"                      LongTime
            //sb.Append(string.Format("{0:T}", dt) + "<br />");
            //// "Sunday, December 20, 2009"          LongDate
            //sb.Append(string.Format("{0:D}", dt) + "<br />");
            //// "Sunday, December 20, 2009 8:04 PM"  LongDate+ShortTime
            //sb.Append(string.Format("{0:f}", dt) + "<br />");
            //// "Sunday, December 20, 2009 8:04:08 PM" FullDateTime
            //sb.Append(string.Format("{0:F}", dt) + "<br />");
            //// "12/20/2009 8:04 PM"                ShortDate+ShortTime
            //sb.Append(string.Format("{0:g}", dt) + "<br />");
            //// "12/20/2009 8:04:08 PM"             ShortDate+LongTime
            //sb.Append(string.Format("{0:G}", dt) + "<br />");
            //// "December 20"                        MonthDay
            //sb.Append(string.Format("{0:m}", dt) + "<br />");
            //// "December, 2009"                     YearMonth
            //sb.Append(string.Format("{0:y}", dt) + "<br />");
            //// "Sun, 20 Dec 2009 20:04:08 GMT"   
            //sb.Append(string.Format("{0:r}", dt) + "<br />");
            //// "2009-12-20T20:04:08"             SortableDateTime
            //sb.Append(string.Format("{0:s}", dt) + "<br />");
            //// "2009-12-20 20:04:08Z"            UniversalSortableDateTime
            //sb.Append(string.Format("{0:u}", dt) + "<br />");
            return sb.ToString();
        }
        /// <summary>
        /// case "M/d/yyyy":Format("{0:M/d/yyyy}", dt));break;
        /// case "MM/dd/yyyy" :Format("{0:MM/dd/yyyy}", dt));break;
        /// case "MMM/dd/yyyy":Format("{0:MMM/dd/yyyy}", dt));break;
        /// case "d/M/yyyy  HH:mm:ss":Format("{0:d/M/yyyy HH:mm:ss}", dt));break;
        /// case "d/M/yyyy":Format("{0:d/M/yyyy}", dt));break;
        /// case "dd/MM/yyyy":Format("{0:dd/MM/yyyy}", dt));break;
        /// case "dd/MMM/yyyy":Format("{0:dd/MMM/yyyy}", dt));break;
        /// case "yyyyMMdd":Format("{0:yyyyMMdd}", dt));break;
        /// case "MMM":Format("{0:MMM}", dt));break;
        /// case "HH:mm:ss":Format("{0:yyyyMMddHHmmss}", dt));break;
        /// case "MMM.dd.yyyy":Format("{0:MMM/dd/yyyy}", dt));break;
        /// </summary>
        /// <param name="InputDateTime"></param>
        /// <param name="OutputFormatDate"></param>
        /// <returns></returns>
        public static string AlldatetimeCase(string InputDateTime, string OutputFormatDate)
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                DateTime dt = Convert.ToDateTime(InputDateTime.Replace('.', '/').Replace("Mär", "Mar").Replace("Mai", "May")
                    .Replace("Okt", "Oct").Replace("Dez", "Dec").Replace("Mrz", "Mar"));
                switch (OutputFormatDate)
                {
                    case "M/d/yyyy":
                        sb.Append(string.Format("{0:M/d/yyyy}", dt));
                        break;
                    case "MM/dd/yyyy":
                        sb.Append(string.Format("{0:MM/dd/yyyy}", dt));
                        break;
                    case "MMM/dd/yyyy":
                        sb.Append(string.Format("{0:MMM/dd/yyyy}", dt));
                        break;
                    case "d/M/yyyy  HH:mm:ss":
                        sb.Append(string.Format("{0:d/M/yyyy HH:mm:ss}", dt));
                        break;
                    case "d/M/yyyy":
                        sb.Append(string.Format("{0:d/M/yyyy}", dt));
                        break;
                    case "dd/MM/yyyy":
                        sb.Append(string.Format("{0:dd/MM/yyyy}", dt));
                        break;
                    case "dd/MMM/yyyy":
                        sb.Append(string.Format("{0:dd/MMM/yyyy}", dt));
                        break;
                    case "yyyyMMdd":
                        sb.Append(string.Format("{0:yyyyMMdd}", dt));
                        break;
                    case "MMM":
                        sb.Append(string.Format("{0:MMM}", dt));
                        break;
                    case "HH:mm:ss":
                        sb.Append(string.Format("{0:yyyyMMddHHmmss}", dt));
                        break;
                    case "MMM.dd.yyyy":
                        sb.Append(string.Format("{0:MMM/dd/yyyy}", dt));
                        break;
                }
            }
            catch (Exception ex)
            {
                sb.Append(InputDateTime);
                // throw ex;
                string error = ex.Message;
                //Log.WriteLog("Getconvertion class", "AlldatetimeCase(" + InputDateTime + ")", ex.Source, ex.Message);
            }
            return sb.ToString();
        }
    }
}