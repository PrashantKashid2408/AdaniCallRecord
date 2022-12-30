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
    //[Localisation] //<<< ADD THIS TO ALL CONTROLLERS (OR A BASE CONTROLLER)
    //[CustomAuthorizeAttribute(false, Roles = RoleEnums.SuperAdmin + "," + RoleEnums.Admin + "," + RoleEnums.LocationAdmin)]
    public class AssessmentsController : Controller
    {
        private readonly string _module = "AdaniCall.Controllers.AssessmentsController";
        private List<SentenceAssessments> _list = new List<SentenceAssessments>();
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;
        private IMemoryCache _cache;
        private Int64 _userId = 0;
        private string _role = "";
        string _cacheKey = "Assessments_";

        JsonMessage _jsonMessage = null;
        public AssessmentsController(IHttpContextAccessor httpContextAccessor, IMemoryCache cache)
        {
            _httpContextAccessor = httpContextAccessor;
            _cache = cache;
        }


        // GET: Assessments
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            List<SentenceAssessments> _list = new List<SentenceAssessments>();
            int page = 1, size = 10;
            try
            {
                ViewBag.MenuId = KeyEnums.MenuKeys.liWordCloudAssessments.ToString();
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

        public List<SentenceAssessments> GetList(string query, string sortColumn, string sortOrder, ref int page, ref int size, string flag, Int64 _userId = 0, bool isLoad = true, string ListType = "")
        {
            List<SentenceAssessments> _list = new List<SentenceAssessments>();
            try
            {
                _cacheKey = _cacheKey + ListType + _session.Id;

                if (isLoad || _cache.Get(_cacheKey) == null)
                {
                    Int64 UserID = _userId;
                    if (_role.ToLower() == RoleEnums.SuperAdmin.ToString().ToLower() || _role.ToLower() == RoleEnums.Admin.ToString().ToLower())
                        UserID = 0;

                    SentenceAssessmentsBusinessFacade objBusinessFacade = new SentenceAssessmentsBusinessFacade();
                    _list = objBusinessFacade.GetSentenceAssessments(UserID, ListType, query);
                    _cache.CreateEntry(_cacheKey);
                    //  HttpContext.Cache.Insert(_cacheKey, _list, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(10));

                }
                else
                    _list = (List<SentenceAssessments>)_cache.Get(_cacheKey);

                flag = !string.IsNullOrEmpty(flag) ? flag : "";

                if (_list != null)
                {
                    if (!string.IsNullOrEmpty(query))
                    {
                        query = query.Trim().ToLower();
                        _list = _list.Where(a => a.AssessmentText.ToLower().Trim().Contains(query.Trim())
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
                                    _list = _list.OrderByDescending(p => p.AssessmentText).ToList();
                                else
                                    _list = _list.OrderBy(p => p.AssessmentText).ToList();
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
                return new List<SentenceAssessments>();
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