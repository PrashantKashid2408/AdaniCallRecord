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

namespace CallRecord.Controllers
{
  //  [Localisation] //<<< ADD THIS TO ALL CONTROLLERS (OR A BASE CONTROLLER)
   // [CustomAuthorizeAttribute(false, Roles = RoleEnums.SuperAdmin + "," + RoleEnums.Admin + "," + RoleEnums.LocationAdmin)]
    public class OpinionController : Controller
    {
        private readonly string _module = "AdaniCall.Controllers.OpinionController";
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;
        private IMemoryCache _cache;
        private List<SentenceOpinion> _list = new List<SentenceOpinion>();
        public OpinionController(IHttpContextAccessor httpContextAccessor, IMemoryCache cache)
        {
            _httpContextAccessor = httpContextAccessor;
            _cache = cache;
        }
        private Int64 _userId = 0;
        private string _role = "";
        string _cacheKey = "Opinion_";

        JsonMessage _jsonMessage = null;
        // GET: Opinion
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            List<SentenceOpinion> _list = new List<SentenceOpinion>();
            int page = 1, size = 10;
            try
            {
                ViewBag.MenuId = KeyEnums.MenuKeys.liWordCloud.ToString();
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

        public List<SentenceOpinion> GetList(string query, string sortColumn, string sortOrder, ref int page, ref int size, string flag, Int64 _userId = 0, bool isLoad = true, string ListType = "")
        {
            List<SentenceOpinion> _list = new List<SentenceOpinion>();
            try
            {
                _cacheKey = _cacheKey + ListType + _session.Id;

                if (isLoad || _cache.Get(_cacheKey) == null)
                {
                    Int64 UserID = _userId;
                    if (_role.ToLower() == RoleEnums.SuperAdmin.ToString().ToLower() || _role.ToLower() == RoleEnums.Admin.ToString().ToLower())
                        UserID = 0;

                    SentenceOpinionBusinessFacade objBusinessFacade = new SentenceOpinionBusinessFacade();
                    _list = objBusinessFacade.GetOpinion(UserID, ListType, query);

                    _cache.CreateEntry(_cacheKey);
                }
                else
                    _list = (List<SentenceOpinion>)_cache.Get(_cacheKey);

                flag = !string.IsNullOrEmpty(flag) ? flag : "";

                if (_list != null)
                {
                    if (!string.IsNullOrEmpty(query))
                    {
                        query = query.Trim().ToLower();
                        _list = _list.Where(a => a.TargetText.ToLower().Trim().Contains(query.Trim())
                                                    || a.Sentiment.ToLower().Trim().Contains(query.Trim())
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
                            case "text":
                                if (sortOrder.ToLower() == "desc")
                                    _list = _list.OrderByDescending(p => p.TargetText).ToList();
                                else
                                    _list = _list.OrderBy(p => p.TargetText).ToList();
                                break;
                            case "sentiment":
                                if (sortOrder.ToLower() == "desc")
                                    _list = _list.OrderByDescending(p => p.Sentiment).ToList();
                                else
                                    _list = _list.OrderBy(p => p.Sentiment).ToList();
                                break;
                            case "count":
                                if (sortOrder.ToLower() == "desc")
                                    _list = _list.OrderByDescending(p => p.Count).ToList();
                                else
                                    _list = _list.OrderBy(p => p.Count).ToList();
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
                return new List<SentenceOpinion>();
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
    }
}