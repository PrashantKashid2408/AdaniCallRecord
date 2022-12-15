//using Microsoft.AspNetCore.Http;
//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.IO;
//using System.Linq;
//using System.Reflection;
//using System.Security.Cryptography;
//using System.Text;
//using System.Web;
//using Microsoft.AspNetCore.Mvc;

//namespace AdaniCall.Models
//{
//    public class CookieStore
//    {
//        public readonly IHttpContextAccessor _httpContextAccessor;
//        public CookieStore(IHttpContextAccessor httpContextAccessor)
//        {
//            _httpContextAccessor = httpContextAccessor;
//        }
//        //string cookieValueFromContext = _httpContextAccessor.HttpContext.Request.Cookies["key"];
//        public void SetCookie(string key, string value, int? expireTime)
//        {
//            CookieOptions option = new CookieOptions();
//            if (expireTime > 0)
//                option.Expires = DateTime.Now.AddDays(double.Parse(expireTime.ToString()));
//            else
//                option.Expires = DateTime.Now.AddMilliseconds(10);
//            Response.Cookies.Append(key, value, option);
//        }
//        public void SetCookie(string key, string value, int? expireTime)
//        {
//            CookieOptions option = new CookieOptions();
//            if (expireTime > 0)
//                option.Expires = DateTime.Now.AddDays(double.Parse(expireTime.ToString()));
//            else
//                option.Expires = DateTime.Now.AddMilliseconds(10);
//            Response.Cookies.Append(key, value, option);
//        }

//        public static string GetCookie(string key)
//        {
//            string value = string.Empty;
//            var cookie = _httpContextAccessor.HttpContext.Current.Request.Cookies[key];

//            if (cookie != null)
//            {
//                // For security purpose, we need to encrypt the value.
//                HttpCookie decodedCookie = HttpSecureCookie.Decode(cookie);
//                value = decodedCookie.Value;
//            }

//            return value;
//        }
//        public void RemoveCookie(string key)
//        {
//            Response.Cookies.Delete(key);
//        }
////        public static void RemoveCookie(string key)
////        {
////            HttpCookie cookie = new HttpCookie(key, "");
////            cookie.Expires = DateTime.Now.AddYears(-1);
////            HttpContext.Current.Response.Cookies.Add(cookie);

////            public static String GetCookieByKey(string key)
////            {

////                string culture = string.Empty;
////                var cookie = HttpContext.Current.Request.Cookies[key];
////                if (cookie != null && cookie.Value != null
////                    && cookie.Value.Trim() != string.Empty)
////                    culture = cookie.Value;


////                return culture;
////            }

////            public static String GetDecryptedCookieByKey(string key)
////            {
////                string culture = string.Empty;
////                var cookie = HttpContext.Current.Request.Cookies[key];
////                if (cookie != null && cookie.Value != null
////                    && cookie.Value.Trim() != string.Empty)
////                    culture = cookie.Value;
////                if (!string.IsNullOrWhiteSpace(culture))
////                {
////                    var encription = new AdaniCall.Utility.Common.Encription();
////                    culture = encription.Decrypt(culture);
////                }
////                return culture;
////            }

////            public static void SetEncryptedCookieKey(string key, string value, TimeSpan expires)
////            {
////                var encription = new AdaniCall.Utility.Common.Encription();
////                value = encription.Encrypt(value);

////                if (HttpContext.Current.Request.Cookies[key] != null)
////                {
////                    var cookieOld = HttpContext.Current.Request.Cookies[key];
////                    cookieOld.Expires = DateTime.MaxValue;
////                    cookieOld.Value = value;
////                    HttpContext.Current.Response.Cookies.Add(cookieOld);
////                }
////                else
////                {
////                    HttpCookie newCookie = new HttpCookie(key, value);
////                    newCookie.Expires = DateTime.MaxValue;
////                    HttpContext.Current.Response.Cookies.Add(newCookie);
////                }
////            }

////            //public static void UpdateCookieByKeyandValue(string key, string NewValue)
////            //{
////            //    //remove cookie
////            //    CookieStore.RemoveCookie(key);

////            //    //add cookie with new value
////            //    var cookieCultureLanguage = new HttpCookie(key)
////            //    {
////            //        Value = LanguageMaster.GetLanguage(NewValue).ToString().ToLower()
////            //    };
////            //    HttpContext.Current.Response.Cookies.Set(cookieCultureLanguage);
////            //}
////        }


////        /// <summary>
////        /// Provides cookie cyphering services.
////        /// </summary>
////        public static class HttpSecureCookie
////        {

////            /// <summary>
////            /// Encodes a cookie with all protection levels
////            /// </summary>
////            /// <param name="cookie">The cookie to encode</param>
////            /// <returns>A clone of the cookie in encoded format</returns>
////            public static HttpCookie Encode(HttpCookie cookie)
////            {
////                return Encode(cookie, CookieProtection.All);
////            }

////            /// <summary>
////            /// Encodes a cookie
////            /// </summary>
////            /// <param name="cookie">The cookie to encode</param>
////            /// <param name="cookieProtection">The cookie protection to set</param>
////            /// <returns>A clone of the cookie in encoded format</returns>
////            public static HttpCookie Encode(HttpCookie cookie, CookieProtection cookieProtection)
////            {
////                HttpCookie encodedCookie = CloneCookie(cookie);
////                encodedCookie.Value = MachineKeyCryptography.Encode(cookie.Value, cookieProtection);
////                return encodedCookie;
////            }

////            /// <summary>
////            /// Decodes a cookie that has all levels of cookie protection. Throws InvalidCypherTextException if unable to decode.
////            /// </summary>
////            /// <param name="cookie">The cookie to decode</param>
////            /// <returns>A clone of the cookie in decoded format</returns>
////            public static HttpCookie Decode(HttpCookie cookie)
////            {
////                return Decode(cookie, CookieProtection.All);
////            }

////            /// <summary>
////            /// Decodes a cookie. Throws InvalidCypherTextException if unable to decode.
////            /// </summary>
////            /// <param name="cookie">The cookie to decode</param>
////            /// <param name="cookieProtection">The protection level to use when decoding</param>
////            /// <returns>A clone of the cookie in decoded format</returns>
////            public static HttpCookie Decode(HttpCookie cookie, CookieProtection cookieProtection)
////            {
////                HttpCookie decodedCookie = CloneCookie(cookie);
////                decodedCookie.Value = MachineKeyCryptography.Decode(cookie.Value, cookieProtection);
////                return decodedCookie;
////            }

////            /// <summary>
////            /// Creates a clone of the given cookie
////            /// </summary>
////            /// <param name="cookie">A cookie to clone</param>
////            /// <returns>The cloned cookie</returns>
////            public static HttpCookie CloneCookie(HttpCookie cookie)
////            {
////                HttpCookie clonedCookie = new HttpCookie(cookie.Name, cookie.Value);
////                clonedCookie.Domain = cookie.Domain;
////                clonedCookie.Expires = cookie.Expires;
////                clonedCookie.HttpOnly = cookie.HttpOnly;
////                clonedCookie.Path = cookie.Path;
////                clonedCookie.Secure = cookie.Secure;

////                return clonedCookie;
////            }

////        }


////        /// <summary>
////        /// A class to encode, decode and validate strings based on the MachineKey
////        /// </summary>
////        public static class MachineKeyCryptography
////        {

////            /// <summary>
////            /// Encodes a string and protects it from tampering
////            /// </summary>
////            /// <param name="text">String to encode</param>
////            /// <returns>Encoded string</returns>
////            public static string Encode(string text)
////            {
////                return Encode(text, CookieProtection.All);
////            }

////            /// <summary>
////            /// Encodes a string
////            /// </summary>
////            /// <param name="text">String to encode</param>
////            /// <param name="cookieProtection">The method in which the string is protected</param>
////            /// <returns></returns>
////            public static string Encode(string text, CookieProtection cookieProtection)
////            {
////                if (string.IsNullOrEmpty(text) || cookieProtection == CookieProtection.None)
////                {
////                    return text;
////                }
////                byte[] buf = Encoding.UTF8.GetBytes(text);
////                return CookieProtectionHelperWrapper.Encode(cookieProtection, buf, buf.Length);
////            }

////            /// <summary>
////            /// Decodes a string and returns null if the string is tampered
////            /// </summary>
////            /// <param name="text">String to decode</param>
////            /// <returns>The decoded string or throws InvalidCypherTextException if tampered with</returns>
////            public static string Decode(string text)
////            {
////                return Decode(text, CookieProtection.All);
////            }

////            /// <summary>
////            /// Decodes a string
////            /// </summary>
////            /// <param name="text">String to decode</param>
////            /// <param name="cookieProtection">The method in which the string is protected</param>
////            /// <returns>The decoded string or throws InvalidCypherTextException if tampered with</returns>
////            public static string Decode(string text, CookieProtection cookieProtection)
////            {
////                if (string.IsNullOrEmpty(text))
////                {
////                    return text;
////                }
////                byte[] buf;
////                try
////                {
////                    buf = CookieProtectionHelperWrapper.Decode(cookieProtection, text);
////                }
////                catch (Exception ex)
////                {
////                    throw new InvalidCypherTextException("Unable to decode the text", ex.InnerException);
////                }
////                if (buf == null || buf.Length == 0)
////                {
////                    throw new InvalidCypherTextException("Unable to decode the text");
////                }
////                return Encoding.UTF8.GetString(buf, 0, buf.Length);
////            }
////        }
////        /// <summary>
////        /// Represents errors that occur when a text can't be decoded or the text is tampered 
////        /// </summary>
////        public class InvalidCypherTextException : Exception
////        {

////            /// <summary>
////            /// Constructor
////            /// </summary>
////            public InvalidCypherTextException()
////                : base()
////            {
////            }

////            /// <summary>
////            /// Constructor
////            /// </summary>
////            public InvalidCypherTextException(string message)
////                : base(message)
////            {
////            }

////            /// <summary>
////            /// Constructor
////            /// </summary>
////            public InvalidCypherTextException(string message, Exception innerException)
////                : base(message, innerException)
////            {
////            }
////        }

////        /// <summary>
////        /// A wrapper arroud System.Web.Security.CookieProtectionHelper internal class
////        /// </summary>
////        public static class CookieProtectionHelperWrapper
////        {

////            private static MethodInfo _encode;
////            private static MethodInfo _decode;

////            /// <summary>
////            /// Constructor
////            /// </summary>
////            static CookieProtectionHelperWrapper()
////            {
////                // obtaining a reference to System.Web assembly
////                Assembly systemWeb = typeof(HttpContext).Assembly;
////                if (systemWeb == null)
////                {
////                    throw new InvalidOperationException("Unable to load System.Web.");
////                }
////                // obtaining a reference to the internal class CookieProtectionHelper
////                Type cookieProtectionHelper = systemWeb.GetType("System.Web.Security.CookieProtectionHelper");
////                if (cookieProtectionHelper == null)
////                {
////                    throw new InvalidOperationException("Unable to get the internal class System.Web.Security.CookieProtectionHelper.");
////                }
////                // obtaining references to the methods of CookieProtectionHelper class
////                _encode = cookieProtectionHelper.GetMethod("Encode", BindingFlags.NonPublic | BindingFlags.Static);
////                _decode = cookieProtectionHelper.GetMethod("Decode", BindingFlags.NonPublic | BindingFlags.Static);

////                if (_encode == null || _decode == null)
////                {
////                    throw new InvalidOperationException("Unable to get the methods to invoke.");
////                }
////            }

////            /// <summary>
////            /// Wrapper arround CookieProtectionHelper.Encode
////            /// </summary>
////            /// <param name="cookieProtection">Protection Type</param>
////            /// <param name="buf">Bytes buffer to encode</param>
////            /// <param name="count">The number of bytes in the buffer</param>
////            /// <returns>Encoded text</returns>
////            public static string Encode(CookieProtection cookieProtection, byte[] buf, int count)
////            {
////                return (string)_encode.Invoke(null, new object[] { cookieProtection, buf, count });
////            }

////            /// <summary>
////            /// Wrapper arround CookieProtectionHelper.Decode
////            /// </summary>
////            /// <param name="cookieProtection">Protection Type</param>
////            /// <param name="data">String to decode</param>
////            /// <returns>Decoded bytes</returns>
////            public static byte[] Decode(CookieProtection cookieProtection, string data)
////            {
////                return (byte[])_decode.Invoke(null, new object[] { cookieProtection, data });
////            }

////        }





////        //While the HttpCookie class is sealed and cannot be inherited you can make your life easier by making an encrypted cookie class with an operator overload for ease of use.


////    }
////}