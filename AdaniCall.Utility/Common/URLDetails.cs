using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace AdaniCall.Utility.Common
{
    public class URLDetails
    {
        //public static string GetScheme()
        //{
        //    if (HttpContext.Current.Request.IsSecureConnection)
        //        return "https://";
        //    else
        //        return "http://";
        //}

        public static string GetSiteRootUrl()
        {
            try
            {
                string protocol;

                try
                {
                    //if (HttpContext.Current.Request.IsSecureConnection)
                    //    protocol = "https";
                    //else
                    protocol = "http";
                }
                catch (Exception ex)
                {
                    protocol = "https";
                }


                StringBuilder uri = new StringBuilder(protocol + "://");

                //try
                //{
                //    string hostname = HttpContext.Current.Request.Url.Host;

                //    uri.Append(hostname);

                //    int port = HttpContext.Current.Request.Url.Port;

                //    if (port != 80 && port != 443)
                //    {
                //        uri.Append(":");
                //        uri.Append(port.ToString());
                //    }
                //}
                //catch (Exception ex)
                //{
                //}

                return (uri + "/").ToString();
            }
            catch (Exception)
            {
                return "";
            }

        }
    }
}
