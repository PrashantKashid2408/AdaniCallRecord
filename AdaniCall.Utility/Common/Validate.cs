using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdaniCall.Utility
{
    public static class Validate
    {
        public static string ValidPhone(string PhoneNo)
        {
            try
            {
                if (PhoneNo != "")
                {
                    if (PhoneNo.Length < 10)
                        return "";
                    else
                    {
                        PhoneNo = PhoneNo.Replace(" ", "").Trim();
                        if (PhoneNo.Length == 11 && PhoneNo.StartsWith("0"))
                            PhoneNo = PhoneNo.Substring(1, 10);
                        else if (PhoneNo.Length == 13 && PhoneNo.StartsWith("+91"))
                            PhoneNo = PhoneNo.Substring(3, 10);
                        else if (PhoneNo.Length == 12 && PhoneNo.StartsWith("91"))
                            PhoneNo = PhoneNo.Substring(2, 10);

                        if (PhoneNo.Length == 10 && Regex.IsMatch(PhoneNo, @"^\d+$"))
                            return PhoneNo;
                    }
                }
            }
            catch (Exception ex)
            {
                return "";
            }
            return "";
        }
    }
}
