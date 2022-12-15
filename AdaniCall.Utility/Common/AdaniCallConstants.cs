using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace AdaniCall.Utility.Common
{
    public class AdaniCallConstants
    {
        private static IConfiguration Configuration;
        public static string GetAppSetting(string appSettingKey)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false);
            Configuration = builder.Build();

            string[] SplittedKey = appSettingKey.Split(":");

            string PureKey = SplittedKey[(SplittedKey.Length) - 1];

            bool a = Configuration.GetChildren().Any(item => item.Key == appSettingKey);
            string appSettingValue = Configuration.GetValue<string>(appSettingKey);

            return appSettingValue;
        }
        //Recording Paths:
        public static readonly string RootPath = GetAppSetting("AppSettings:RootPath");
        public static readonly string PhyPath = GetAppSetting("AppSettings:PhyPath");
        public static readonly string AudioPath = GetAppSetting("AppSettings:AudioPath");
        public static readonly string VideoPath = GetAppSetting("AppSettings:VideoPath");
        public static readonly string CallBackURI = GetAppSetting("AppSettings:CallBackURI");

        /// <summary>
        /// /
        /// </summary>
        public static readonly string AdaniCallQRDomain = GetAppSetting("AppSettings:AdaniCallQRDomain");

        //SMTP details
        public static readonly string LOG_FOLDER_PATH = GetAppSetting("AppSettings:LOG_FOLDER_PATH");
        public static readonly string LOG_EMAIL_SENDER = GetAppSetting("AppSettings:LOG_EMAIL_SENDER");
        public static readonly string LOG_EMAIL_RECEIVER = GetAppSetting("AppSettings:LOG_EMAIL_RECEIVER");
        public static readonly string LOG_EMAIL_SUBJECT = GetAppSetting("AppSettings:LOG_EMAIL_SUBJECT");
        public static readonly string LOG_EMAIL_IS_SEND = GetAppSetting("AppSettings:LOG_EMAIL_IS_SEND");
        public static readonly string LOG_EMAIL_CC = GetAppSetting("AppSettings:LOG_EMAIL_CC");
        public static readonly string LOG_EMAIL_BCC = GetAppSetting("AppSettings:LOG_EMAIL_BCC");
        public static readonly string CareEmail = GetAppSetting("AppSettings:CareEmail");

        /// <summary>
        /// 
        /// </summary>
        public static readonly string shortURL = GetAppSetting("AppSettings:shortURL");
        public static readonly string Cachedate = GetAppSetting("AppSettings:Cachedate");


        public static readonly string DefaultmailID = GetAppSetting("AppSettings:DefaultmailID");
        public static readonly string Account_Confirmation = GetAppSetting("AppSettings:Account_Confirmation");
        public static readonly string ReplyToEmail = GetAppSetting("AppSettings:ReplyToEmail");

        // Default Domain controller and View:
        public static readonly string AdaniCallDomain = GetAppSetting("AppSettings:AdaniCallDomain");
        public static readonly string DefaultController = GetAppSetting("AppSettings:DefaultController");
        public static readonly string DefaultView = GetAppSetting("AppSettings:DefaultView");

        //Encryption Constants:
        public static readonly string AESUserEncrryptKey = GetAppSetting("AppEncryption:AESUserEncrryptKey");
        public static readonly string AESUserVector = GetAppSetting("AppEncryption:AESUserVector");
        public static readonly string AESUserSalt = GetAppSetting("AppEncryption:AESUserSalt");

        public static readonly int SQLCommandTimeOut = GetAppSetting("AppEncryption:SQLCommandTimeOut") != "" ? Convert.ToInt32(GetAppSetting("AppEncryption:SQLCommandTimeOut")) : 0;

    }
}
