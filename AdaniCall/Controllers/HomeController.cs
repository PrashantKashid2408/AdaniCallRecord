using AdaniCall.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;
using Azure.Core;
using Microsoft.AspNetCore.Routing;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs;
using Azure.Messaging.EventGrid;
using Azure.Messaging.EventGrid.SystemEvents;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using AdaniCall.Entity.Enums;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using AdaniCall.Business.BusinessFacade;
using AdaniCall.Utility.Common;
using AdaniCall.Entity;
using AdaniCall.Business.DataAccess.Constants;
using AdaniCall.Controllers;

namespace AdaniCall.Controllers
{
   // [Localisation]
    public class HomeController : Controller
    {
        TokenHelper objTokenHelper = new TokenHelper();
        private readonly string _module = "AdaniCall.Controllers.UserController";

        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
         private ISession _session => _httpContextAccessor.HttpContext.Session;
         private IMemoryCache _cache;

        
        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor , IMemoryCache cache)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _cache = cache;
        }
        public ActionResult Privacy()
        {
            return View();
        }
            // [CustomAuthorizeAttribute(false, Roles = RoleEnums.Kiosk)]
            public ActionResult Call()
        {
            string _cacheKey = "CallToken_" + _session.Id;
            _cache.Remove(_cacheKey);
            Int64 UserID = 0;
            string CallerID = "";
            string KioskID = "";
            if (_session.GetString(KeyEnums.SessionKeys.UserId.ToString()) != null)
            {
                UserID = Convert.ToInt64(_session.GetString(KeyEnums.SessionKeys.UserId.ToString()));
                if (_session.GetString(KeyEnums.SessionKeys.CallerID.ToString()) != null)
                    CallerID = _session.GetString(KeyEnums.SessionKeys.CallerID.ToString()).ToString();
                if (_session.GetString(KeyEnums.SessionKeys.KioskID.ToString()) != null)
                    KioskID = _session.GetString(KeyEnums.SessionKeys.KioskID.ToString()).ToString();
            }

            try
            {
                ViewBag.Title = "Traveller";

                CommonData objCD = new CommonData();
                AccessToken objAT = new AccessToken();

                if (!string.IsNullOrWhiteSpace(CallerID))
                {
                    DateTime objDTNow = DateTime.Now;
                    if (_cache.Get(_cacheKey) != null)
                    {

                        objAT = objCD.GetFromCache(_cacheKey);
                       
                        if (objDTNow > objAT.ExpiresOn.DateTime)
                        {
                            objAT = objTokenHelper.RefreshTokenAsync(CallerID);
                            //  objCD.AddToCache(_cacheKey, objDTNow, objAT.ExpiresOn.DateTime);
                            _cache.Set(_cacheKey, DateTime.Now, TimeSpan.FromDays(1));
                        }
                    }
                    else
                    {
                        objAT = objTokenHelper.RefreshTokenAsync(CallerID);
                        // objCD.AddToCache(_cacheKey, objDTNow, objAT.ExpiresOn.DateTime);
                        _cache.Set(_cacheKey, DateTime.Now, TimeSpan.FromDays(1));
                    }
                }
                else
                    new UserController(_httpContextAccessor,_cache).Logout();

                ViewBag.CallToken = objAT.Token;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "Accept(UserId=" + UserID + ")", ex.Source, ex.Message);
            }

            return View();
        }
        //[CustomAuthorizeAttribute(false, Roles = RoleEnums.Agent)]
        public ActionResult Accept()
        {
            string _cacheKey = "AcceptToken_" + HttpContext.Session.Id;
            _cache.Remove(_cacheKey);
            Int64 UserID = 0;
            string CallerID = "";
         
            if (_session.GetString(KeyEnums.SessionKeys.UserId.ToString()) != null)
            {
                UserID = Convert.ToInt64(_session.GetString(KeyEnums.SessionKeys.UserId.ToString()));
                if (_session.GetString(KeyEnums.SessionKeys.CallerID.ToString()) != null)
                    CallerID = _session.GetString(KeyEnums.SessionKeys.CallerID.ToString()).ToString();
                UsersBusinessFacade objUsers = new UsersBusinessFacade();
                objUsers.ChangeAvailabilityStatus(UserID, "1");
            }

            try
            {
                ViewBag.Title = "Help Desk";

                CommonData objCD = new CommonData();
                AccessToken objAT = new AccessToken();

                if (!string.IsNullOrWhiteSpace(CallerID))
                {
                    DateTime objDTNow = DateTime.Now;
                    if (_cache.Get(_cacheKey)!= null)
                    {
                        objAT = objCD.GetFromCache(_cacheKey);
                      
                        if (objDTNow > objAT.ExpiresOn.DateTime)
                        {
                            objAT = objTokenHelper.RefreshTokenAsync(CallerID);
                           // objCD.AddToCache(_cacheKey, objDTNow, objAT.ExpiresOn.DateTime);
                            _cache.Set(_cacheKey, DateTime.Now, TimeSpan.FromDays(1));
                        }
                    }
                    else
                    {
                        objAT = objTokenHelper.RefreshTokenAsync(CallerID);
                        //objCD.AddToCache(_cacheKey, objDTNow, objAT.ExpiresOn.DateTime);
                        _cache.Set(_cacheKey, DateTime.Now, TimeSpan.FromDays(1));
                    }
                }
                else
                    new UserController(_httpContextAccessor,_cache).Logout();

                ViewBag.AcceptToken = objAT.Token;
                ViewBag.AgentCallerID = CallerID;
            }
            catch (Exception ex)
            {
                Console.WriteLine(_module, "Accept(UserId=" + UserID + ")", ex.Source, ex.Message);
            }

            return View();
        }
        //public IActionResult Index()
        //{
        //    return View();
           
        //}
        [HttpPost]
        public JsonResult MakeCallTransaction(string UniqueCallID, string IncomingCallID)
        {
            Int64 UserID = 0;
            CallTransactions objCT = new CallTransactions();
            try
            {
                CallTransactionsBusinessFacade objBF = new CallTransactionsBusinessFacade();
                if (_session.GetString(KeyEnums.SessionKeys.UserId.ToString()) != null)
                {
                    UserID = Convert.ToInt64(_session.GetString(KeyEnums.SessionKeys.UserId.ToString()));
                    objCT.AgentUserID = UserID;
                    objCT.TravellerCallID = IncomingCallID;
                    objCT.UniqueCallID = UniqueCallID;
                    objBF.Save(objCT);
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "MakeCallTransaction(UniqueCallID:" + UniqueCallID + ",IncomingCallID:" + IncomingCallID + ")", ex.Source, ex.Message);
            }
            return Json("");
        }
        [HttpPost]
        public JsonResult UpdateCallTransactionsEndTime(string UniqueCallID, string CallLanguage = "3")
        {
            CallTransactions objCT = new CallTransactions();
            try
            {
                CallTransactionsBusinessFacade objBF = new CallTransactionsBusinessFacade();
                if (_session.GetString(KeyEnums.SessionKeys.UserId.ToString()) != null)
                {
                    int callLanguage;
                    int.TryParse(CallLanguage, out callLanguage);
                    objBF.UpdateCallTransactions(CallTransactionsDBFields.CallEndTime + "=CONVERT(VARCHAR, GETDATE(), 120)," + CallTransactionsDBFields.LanguageId + "=" + callLanguage, CallTransactionsDBFields.UniqueCallID + "='" + UniqueCallID + "'");
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "UpdateCallTransactionsEndTime(UniqueCallID:" + UniqueCallID + ",CallLanguage:" + CallLanguage + ")", ex.Source, ex.Message);
            }
            return Json("");
        }
        [HttpPost]
        public JsonResult InsertAM(string UniqueCallID, string CallStatus)
        {
            Int64 UserID = 0;
            string _role = "";
            Users objUsers = new Users();
            AccessMember objAM = new AccessMember();
            Helper _helper = new Helper(_httpContextAccessor);
            objAM = _helper.GetAccessMember();

            try
            {
                if (_session.GetString(KeyEnums.SessionKeys.UserId.ToString()) != null)
                {
                    UserID = Convert.ToInt64(_session.GetString(KeyEnums.SessionKeys.UserId.ToString()));
                    if (_session.GetString(KeyEnums.SessionKeys.UserRole.ToString()) != null)
                    {
                        _role = _session.GetString(KeyEnums.SessionKeys.UserRole.ToString());
                        objAM.UniqueCallID = UniqueCallID;
                        if (_role == Convert.ToString((byte)RoleEnums.Role.Agent))
                        {
                            objAM.CallerID = "";
                        }
                        else if (_role == Convert.ToString((byte)RoleEnums.Role.Kiosk))
                        {
                            objAM.CallerID = "";
                            if (_session.GetString(KeyEnums.SessionKeys.KioskID.ToString()) != null && _session.GetString(KeyEnums.SessionKeys.KioskID.ToString()).ToString() != "")
                                objAM.KioskID = Convert.ToInt64(_session.GetString(KeyEnums.SessionKeys.KioskID.ToString()));
                        }
                    }
                }

                if (UserID > 0)
                {
                    objUsers.ID = UserID;
                    if (CallStatus.ToLower() == "connected")
                    {
                        string AMID = InsertAccessMember(objUsers, objAM, "Call");
                        return Json(AMID);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "InsertAM(UniqueCallID:" + UniqueCallID + ",UserID:" + UserID + ",CallStatus=" + CallStatus + ")", ex.Source, ex.Message);
            }
            return Json("");
        }
        [HttpPost]
        public JsonResult InsertAMPing(string pingFrom = "")
        {
            Int64 UserID = 0;
            string _role = "";
            Users objUsers = new Users();
            AccessMember objAM = new AccessMember();
            Helper _helper = new Helper(_httpContextAccessor);
            objAM = _helper.GetAccessMember();

            try
            {
                if (_session.GetString(KeyEnums.SessionKeys.UserId.ToString()) != null)
                {
                    UserID = Convert.ToInt64(_session.GetString(KeyEnums.SessionKeys.UserId.ToString()));
                    if (_session.GetString(KeyEnums.SessionKeys.UserRole.ToString()) != null)
                    {
                        _role = _session.GetString(KeyEnums.SessionKeys.UserRole.ToString()).ToString();
                        objAM.UniqueCallID = "";
                        if (_role == Convert.ToString((byte)RoleEnums.Role.Agent))
                        {
                            objAM.CallerID = "";
                        }
                        else if (_role == Convert.ToString((byte)RoleEnums.Role.Kiosk))
                        {
                            objAM.CallerID = "";
                            if (_session.GetString(KeyEnums.SessionKeys.KioskID.ToString()) != null && _session.GetString(KeyEnums.SessionKeys.KioskID.ToString()).ToString() != "")
                                objAM.KioskID = Convert.ToInt64(_session.GetString(KeyEnums.SessionKeys.KioskID.ToString()));
                        }
                    }
                }
                string strPing = "Ping";
                if (!string.IsNullOrWhiteSpace(pingFrom))
                    strPing = pingFrom;
                if (UserID > 0 && _role == Convert.ToString((byte)RoleEnums.Role.Kiosk))
                {
                    objUsers.ID = UserID;
                    string AMID = InsertAccessMember(objUsers, objAM, strPing);
                    return Json(AMID);
                }
                else
                {
                    string AMID = InsertAccessMember(objUsers, objAM, strPing);
                    return Json(AMID);
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "InsertAMPing(pingFrom:" + pingFrom + ")", ex.Source, ex.Message);
            }
            return Json("");
        }
        private string InsertAccessMember(Users objUsers, AccessMember objAccessMember, string ClickedBy)
        {
            try
            {
                objAccessMember.UserID = objUsers.ID;
                objAccessMember.ClickedBy = ClickedBy;
                AccessMemberBusinessFacade objAccessMemberBusinessFacade = new AccessMemberBusinessFacade();
                var AMID = objAccessMemberBusinessFacade.Save(objAccessMember);
                return AMID.ToString();
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "InsertAccessMember(UserID: " + objUsers.ID + ", clickedby:" + ClickedBy + ")", ex.Source, ex.Message);
            }
            return "0";
        }

        }
    }
