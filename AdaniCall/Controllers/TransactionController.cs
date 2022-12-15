using AdaniCall.Business.BusinessFacade;
using AdaniCall.Entity;
using AdaniCall.Entity.Common;
using AdaniCall.Entity.Enums;
using AdaniCall.Models;
using AdaniCall.Utility.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using X.PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdaniCall.Controllers
{
   // [Localisation] //<<< ADD THIS TO ALL CONTROLLERS (OR A BASE CONTROLLER)
   // [CustomAuthorizeAttribute(false, Roles = RoleEnums.SuperAdmin + "," + RoleEnums.Admin + "," + RoleEnums.LocationAdmin)]
    public class TransactionsController : Controller
    {
        private readonly string _module = "AdaniCall.Controllers.TransactionsController";
        private List<CallTransactions> _list = new List<CallTransactions>();
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;
        private IMemoryCache _cache;
        private Int64 _userId = 0;
        private string _role = "";
        string _cacheKey = "Transactions_";

        public TransactionsController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        JsonMessage _jsonMessage = null;

        // GET: Transactions
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            List<CallTransactions> _list = new List<CallTransactions>();
            int page = 1, size = 10;
            try
            {
                ViewBag.MenuId = KeyEnums.MenuKeys.liTransactionAll.ToString();
                ViewBag.RequestList = KeyEnums.ListType.AllTran.ToString();
                _userId = (_session.GetString(KeyEnums.SessionKeys.UserId.ToString()) != null ? Convert.ToInt64(_session.GetString(KeyEnums.SessionKeys.UserId.ToString())) : 0);
                _role = (_session.GetString(KeyEnums.SessionKeys.UserRole.ToString()) != null ? Convert.ToString(_session.GetString(KeyEnums.SessionKeys.UserRole.ToString())) : "");

                _list = GetList("", "", "asc", ref page, ref size, "sort", _userId, true, ViewBag.RequestList);
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "List", ex.Source, ex.Message, ex);
            }

            return View(_list.ToPagedList(1, size));
        }

        public List<CallTransactions> GetList(string query, string sortColumn, string sortOrder, ref int page, ref int size, string flag, Int64 _userId = 0, bool isLoad = true, string ListType = "")
        {
            List<CallTransactions> _list = new List<CallTransactions>();
            try
            {
                _cacheKey = _cacheKey + ListType + _session.Id;

                if (isLoad || _cache.Get(_cacheKey) == null)
                {
                    Int64 UserID = _userId;
                    if (_role.ToLower() == RoleEnums.SuperAdmin.ToString().ToLower() || _role.ToLower() == RoleEnums.Admin.ToString().ToLower())
                        UserID = 0;

                    CallTransactionsBusinessFacade objBusinessFacade = new CallTransactionsBusinessFacade();
                    _list = objBusinessFacade.GetCallTransactions(UserID, ListType, query);

                    //_cache.Set(_cacheKey, _list, TimeSpan.FromMinutes(10));
                    //    HttpContext.Cache.Insert(_cacheKey, _list, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(10));
                }
                else
                    _list = (List<CallTransactions>)_cache.Get(_cacheKey);

                flag = !string.IsNullOrEmpty(flag) ? flag : "";

                if (_list != null)
                {
                    if (!string.IsNullOrEmpty(query))
                    {
                        query = query.Trim().ToLower();
                        _list = _list.Where(a => a.KioskName.ToLower().Trim().Contains(query.Trim())
                                                    || a.KioskLocation.ToLower().Trim().Contains(query.Trim())
                                                    || a.AgentName.ToLower().Trim().Contains(query.Trim())
                                                    || a.AgentLocation.ToLower().Trim().Contains(query.Trim())
                                                    || a.CallStartTime.ToLower().Trim().Contains(query.Trim())
                                                    || a.CallEndTime.ToLower().Trim().Contains(query.Trim())
                                                    ).ToList();

                        if (flag.ToLower() == "search")
                        {
                            page = 1;
                        }
                    }

                    if (flag.ToLower() == "size")
                        page = 1;

                    if (!string.IsNullOrEmpty(sortColumn) && !string.IsNullOrEmpty(sortOrder))
                    {
                        if (flag.ToLower() == "sort")
                            sortOrder = sortOrder.ToLower().Trim() == "asc" ? "desc" : "asc";

                        switch (sortColumn.ToLower().Trim())
                        {
                            case "srno":
                                if (sortOrder.ToLower() == "desc")
                                    _list = _list.OrderByDescending(p => p.RowNumber).ToList();
                                else
                                    _list = _list.OrderBy(p => p.RowNumber).ToList();
                                break;
                            case "kiosk":
                                if (sortOrder.ToLower() == "desc")
                                    _list = _list.OrderByDescending(p => p.KioskName).ToList();
                                else
                                    _list = _list.OrderBy(p => p.KioskName).ToList();
                                break;
                            case "kiosklocation":
                                if (sortOrder.ToLower() == "desc")
                                    _list = _list.OrderByDescending(p => p.KioskLocation).ToList();
                                else
                                    _list = _list.OrderBy(p => p.KioskLocation).ToList();
                                break;
                            case "agent":
                                if (sortOrder.ToLower() == "desc")
                                    _list = _list.OrderByDescending(p => p.AgentName).ToList();
                                else
                                    _list = _list.OrderBy(p => p.AgentName).ToList();
                                break;
                            case "agentlocation":
                                if (sortOrder.ToLower() == "desc")
                                    _list = _list.OrderByDescending(p => p.AgentLocation).ToList();
                                else
                                    _list = _list.OrderBy(p => p.AgentLocation).ToList();
                                break;
                            case "start":
                                if (sortOrder.ToLower() == "desc")
                                    _list = _list.OrderByDescending(p => p.CallStartTime).ToList();
                                else
                                    _list = _list.OrderBy(p => p.CallStartTime).ToList();
                                break;
                            case "end":
                                if (sortOrder.ToLower() == "desc")
                                    _list = _list.OrderByDescending(p => p.CallEndTime).ToList();
                                else
                                    _list = _list.OrderBy(p => p.CallEndTime).ToList();
                                break;
                            default:
                                break;
                        }
                    }

                    ViewBag.SortColumn = sortColumn.ToLower();
                    ViewBag.SortOrder = sortOrder.ToLower();
                    ViewBag.Page = page;
                    ViewBag.Size = size;
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetList(query=" + query + "sortColumn=" + sortColumn + "," + "sortOrder=" + sortOrder + "," + "page=" + page + "," + "size=" + size + ", flag=" + flag + ")", ex.Source, ex.Message, ex);
            }

            if (_list == null)
                return new List<CallTransactions>();
            else
                return _list;
        }

        public ActionResult Search(string query, string sortColumn, string sortOrder, int page, int size, string flag, bool ISLOAD = false, string ListType = "")
        {
            try
            {
                ViewBag.RequestList = ListType;
                _userId = (_session.GetString(KeyEnums.SessionKeys.UserId.ToString()) != null ? Convert.ToInt64(_session.GetString(KeyEnums.SessionKeys.UserId.ToString())) : 0);
                _role = (_session.GetString(KeyEnums.SessionKeys.UserRole.ToString()) != null ? Convert.ToString(_session.GetString(KeyEnums.SessionKeys.UserRole.ToString())) : "");

                _list = GetList(query, sortColumn, sortOrder, ref page, ref size, flag, _userId, ISLOAD, ListType);
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "Search(query=" + query + ", sortColumn=" + sortColumn + ", sortOrder=" + sortOrder + ", page=" + page + ", size=" + size + ", flag=" + flag + ", ISLOAD=" + ISLOAD + ",ListType:" + ListType + ")", ex.Source, ex.Message, ex);
            }
            return PartialView("_ListPartial", _list.ToPagedList(page, size));
        }

        public ActionResult GetAnalysis(Int64 ID)
        {
            List<Analysis> lstAnalysis = new List<Analysis>();
            try
            {
                _userId = (_session.GetString(KeyEnums.SessionKeys.UserId.ToString()) != null ? Convert.ToInt64(_session.GetString(KeyEnums.SessionKeys.UserId.ToString())) : 0);
                _role = (_session.GetString(KeyEnums.SessionKeys.UserRole.ToString()) != null ? Convert.ToString(_session.GetString(KeyEnums.SessionKeys.UserRole.ToString())) : "");
                CallTransactionsBusinessFacade objCTBF = new CallTransactionsBusinessFacade();
                lstAnalysis = objCTBF.GetAnalysis(ID);
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetAnalysis(ID:" + ID + ")", ex.Source, ex.Message, ex);
            }
            return PartialView("_Analysis", lstAnalysis);
        }
    }
}