using AdaniCall.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using AdaniCall.Entity.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using AdaniCall.Utility;
using AdaniCall.Utility.Common;
//using Azure.Core;

namespace AdaniCall.Models
{
    public class Helper
    {
        private readonly string _module = "CallAppCore.Models.Helper";
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;
        public Helper(IHttpContextAccessor httpContextAccessor )
        {
            _httpContextAccessor = httpContextAccessor;
        }
        private bool _IsRegisterProcess = false;

        public bool IsRegisterProcess
        {
            get { return _IsRegisterProcess; }
            set { _IsRegisterProcess = value; }
        }
        public LoginVM GetSession()
        {
            LoginVM loginVM = new LoginVM();

            try
            {
                if (_session.GetString(KeyEnums.SessionKeys.UserSession.ToString()) != null)
                {
                    loginVM = JsonConvert.DeserializeObject<LoginVM>(_session.GetString(KeyEnums.SessionKeys.UserSession.ToString()).ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(_module, "GetSession()", ex.Source, ex.Message, ex);
            }
            return loginVM;
        }

        public LoginVM UpdateSession(LoginVM _LoginVM)
        {
            LoginVM loginVM = new LoginVM();
            try
            {
                _session.SetString(KeyEnums.SessionKeys.UserSession.ToString(), JsonConvert.SerializeObject(_LoginVM));
            }
            catch (Exception ex)
            {
                Console.WriteLine(_module, "UpdateSession()", ex.Source, ex.Message, ex);
            }
            return loginVM;
        }

        public void IsFirstTimeLoginChangeStatus()
        {
            if (_session.GetString(KeyEnums.SessionKeys.UserSession.ToString()) != null)
            {
                LoginVM LM = GetSession();
                LM.IsFirstTimeLogin = false;
                _session.SetString(KeyEnums.SessionKeys.UserSession.ToString(), JsonConvert.SerializeObject(LM));
            }
        }
        public void SetUserLanguage(long LanguageId)
        {
            _session.SetString(KeyEnums.SessionKeys.LanguageId.ToString(), LanguageId.ToString());
        }

        public void SetSession(Users user)
        {
            try
            {
                if (user != null)
                {
                    LoginVM loginVM = new LoginVM();
                    loginVM.SessionId = _session.Id;

                    loginVM.Id = user.ID;
                    loginVM.UserName = user.UserName;
                    loginVM.Password = user.Password;
                    loginVM.FirstName = user.FirstName;
                    loginVM.LastName = user.LastName;
                    loginVM.RoleId = user.RoleId;
                    loginVM.UserRole = (int)user.RoleId;
                    loginVM.ParentId = user.ParentId;

                    loginVM.IsEmailVerified = user.IsEmailVerified;
                    loginVM.EmailVerficationCode = user.EmailVerficationCode;
                    loginVM.EmailVerificationDate = user.EmailVerificationDate;
                    loginVM.StatusId = user.StatusId;
                    loginVM.CreatedDate = user.CreatedDate;
                    loginVM.LanguageId = user.LanguageId;
                    loginVM.LocationID = user.AgentLocationID;
                    loginVM.CallerID = user.AgentCallID;
                    if (IsRegisterProcess)
                    {
                        loginVM.IsFirstTimeLogin = true;
                    }

                    if (!string.IsNullOrWhiteSpace(loginVM.FirstName))
                        loginVM.Initial = StringFilter.GetInitialChar(loginVM.FirstName);

                    if ((!string.IsNullOrWhiteSpace(loginVM.FirstName)) && (!string.IsNullOrWhiteSpace(loginVM.LastName)))
                        loginVM.InitialChars = StringFilter.GetInitials(loginVM.FirstName);

                    loginVM.ParentId = user.ParentId;

                    CommonData _CommonData = new CommonData();
                      //loginVM.ProfileLanguage = _CommonData.LanguageNameFromId(loginVM.LanguageId.ToString());
                     //loginVM.SelectedLanguage = _CommonData.LanguageNameFromId(loginVM.LanguageId.ToString());
                    _session.SetString(KeyEnums.SessionKeys.UserId.ToString(), loginVM.Id.ToString());
                    _session.SetString(KeyEnums.SessionKeys.FirstName.ToString(), loginVM.FirstName.ToString());
                    _session.SetString(KeyEnums.SessionKeys.LastName.ToString(), loginVM.LastName.ToString());
                    _session.SetString(KeyEnums.SessionKeys.UserRole.ToString(), loginVM.UserRole.ToString());
                    _session.SetString(KeyEnums.SessionKeys.CallerID.ToString(), !string.IsNullOrWhiteSpace(loginVM.CallerID) ? loginVM.CallerID.ToString() : "");
                    _session.SetString(KeyEnums.SessionKeys.KioskID.ToString(), !string.IsNullOrWhiteSpace(loginVM.KioskID) ? loginVM.KioskID.ToString() : "");
                    _session.SetString(KeyEnums.SessionKeys.LocationID.ToString(), loginVM.LocationID.ToString());

                    if (!string.IsNullOrWhiteSpace(loginVM.UserName))
                        _session.SetString(KeyEnums.SessionKeys.UserEmailID.ToString(), loginVM.UserName.ToString());
                    _session.SetString(KeyEnums.SessionKeys.UserLogo.ToString(), loginVM.Profile_Logo.ToString());
                    _session.SetString(KeyEnums.SessionKeys.UserSession.ToString(), JsonConvert.SerializeObject(loginVM));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(_module, "SetSession(User user)", ex.Source, ex.Message, ex);
            }
        }

        //public AccessMember GetAccessMember()
        //{
        //    AccessMember objAM = new AccessMember();
        //    try
        //    {
        //        objAM.Url = _httpContextAccessor.HttpContext.Request.Headers["Referer"].ToString() != null ? _httpContextAccessor.HttpContext.Request.Headers["Referer"].ToString() : "";
        //        // _httpContextAccessor.HttpContext.Request.Host.Value != null ? _httpContextAccessor.HttpContext.Request.Host.Value.ToString() : "";
        //        objAM.ReferrerURL = _httpContextAccessor.HttpContext.Request.Headers["Referer"].ToString() != null ? _httpContextAccessor.HttpContext.Request.Headers["Referer"].ToString() : "";
        //        objAM.port = _httpContextAccessor.HttpContext.Request.Host.Port.Value != 0 ? _httpContextAccessor.HttpContext.Request.Host.Port.Value.ToString() : "";
        //        objAM.Host = _httpContextAccessor.HttpContext.Request.Host.Value != null ? _httpContextAccessor.HttpContext.Request.Host.Value.ToString() : "";

        //        var browser = _httpContextAccessor.HttpContext.Request.Headers["User-Agent"];//User-Agent

        //        if (_httpContextAccessor.HttpContext.GetServerVariable("REMOTE_HOST") != null)
        //            objAM.REMOTE_HOST = _httpContextAccessor.HttpContext.GetServerVariable("REMOTE_HOST");
        //        else
        //            objAM.REMOTE_HOST = _httpContextAccessor.HttpContext.GetServerVariable("HTTP_X_FORWARDED_FOR") ?? _httpContextAccessor.HttpContext.GetServerVariable("REMOTE_ADDR");
        //        objAM.REMOTE_ADDR_IP = _httpContextAccessor.HttpContext.GetServerVariable("REMOTE_ADDR") != null ? _httpContextAccessor.HttpContext.GetServerVariable("REMOTE_ADDR") : "";
        //        objAM.Useragent = (_httpContextAccessor.HttpContext.GetServerVariable("HTTP_USER_AGENT") != null ? _httpContextAccessor.HttpContext.GetServerVariable("HTTP_USER_AGENT").ToString() : "");
        //        //objAM.BrowserType = (browser.type != null ? browser.Type.ToString() : "");
        //        //objAM.BrowserVersion = (browser.Browser != null ? browser.Browser.ToString() : "");
        //        //objAM.Platform = (browser.Platform != null ? browser.Platform.ToString() : "");
        //    }

        //    catch (Exception ex)
        //    {
        //        Log.WriteLog(_module, "GetAccessMember()", ex.Source, ex.Message, ex);
        //    }
        //    return objAM;
        //}

        public AccessMember GetAccessMember()
        {
            AccessMember objAM = new AccessMember();
            try
            {
                objAM.Url = _httpContextAccessor.HttpContext.Request.Host + _httpContextAccessor.HttpContext.Request.Path + _httpContextAccessor.HttpContext.Request.QueryString.Value;
                objAM.ReferrerURL = _httpContextAccessor.HttpContext.Request.Headers["Referer"].ToString();
                objAM.port = _httpContextAccessor.HttpContext.Request.Host.Port.Value.ToString();
                objAM.Host = _httpContextAccessor.HttpContext.Request.Host.Value.ToString();
                var browser = _httpContextAccessor.HttpContext.Request.Headers["User-Agent"];//User-Agent

                if (_httpContextAccessor.HttpContext.GetServerVariable("REMOTE_HOST") != null)
                    objAM.REMOTE_HOST = _httpContextAccessor.HttpContext.GetServerVariable("REMOTE_HOST");
                else
                    objAM.REMOTE_HOST = _httpContextAccessor.HttpContext.GetServerVariable("HTTP_X_FORWARDED_FOR") ?? _httpContextAccessor.HttpContext.GetServerVariable("REMOTE_ADDR");

                objAM.REMOTE_ADDR_IP = _httpContextAccessor.HttpContext.GetServerVariable("REMOTE_ADDR") != null ? _httpContextAccessor.HttpContext.GetServerVariable("REMOTE_ADDR") : "";
                objAM.Useragent = (_httpContextAccessor.HttpContext.GetServerVariable("HTTP_USER_AGENT") != null ? _httpContextAccessor.HttpContext.GetServerVariable("HTTP_USER_AGENT").ToString() : "");
                //objAM.BrowserType = (browser.Type != null ? browser.Type.ToString() : "");
                //objAM.BrowserVersion = (browser.Browser != null ? browser.Browser.ToString() : "");
                //objAM.Platform = (browser.Platform != null ? browser.Platform.ToString() : "");
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "getAccessMember()", ex.Source, ex.Message, ex);
            }
            return objAM;
        }
    }
}
