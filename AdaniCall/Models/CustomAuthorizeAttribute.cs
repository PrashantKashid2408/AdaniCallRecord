//using AdaniCall.Entity.Enums;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using AdaniCall.Utility;
//using AdaniCall.Utility.Common;
//using AdaniCall.Entity;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Http;

//namespace AdaniCall.Models
//{
//    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
//    public sealed class CustomAuthorizeAttribute : AuthorizeAttribute
//    {
//        private readonly IHttpContextAccessor _httpContextAccessor;
//        private bool LocalAllowed;
//        public CustomAuthorizeAttribute(bool AllowParam, IHttpContextAccessor httpContextAccessor)
//        {
//            LocalAllowed = AllowParam;
//            _httpContextAccessor = httpContextAccessor;
//        }
//        protected override bool AuthorizeCore()
//        {
//            if (_httpContextAccessor.HttpContext.Session.GetString(KeyEnums.SessionKeys.UserRole.ToString()) == null)
//                return false;

//            if (Roles.ToLower().Contains(_httpContextAccessor.HttpContext.Session.GetString(KeyEnums.SessionKeys.UserRole.ToString()).ToString().ToLower()))
//                return true;
//            else
//                return false;

//        }
//        public override void OnAuthorization()
//        {
//            base.OnAuthorization(filterContext);
//            //if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
//            //{
//            //    filterContext.Result = new RedirectResult("~/Account/Logon");
//            //    return;
//            //}

//            if (filterContext.Result is HttpUnauthorizedResult)
//            {
//                //filterContext.Result = new RedirectResult("~/Pages/AccessDenied");
//                //http://prideparrot.com/blog/archive/2012/6/customizing_authorize_attribute
//                //  filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Pages", action = "AccessDenied" }));
//                //filterContext.Result = new RedirectResult("~/" + AdaniCallConstants.OnAuthorizationController + "/" + AdaniCallConstants.OnAuthorizationAction + "");

//                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = AdaniCallConstants.OnAuthorizationController, action = AdaniCallConstants.OnAuthorizationAction }));

//                return;
//            }
//        }
//    }

//    //http://vivien-chevallier.com/Articles/create-a-custom-authorizeattribute-that-accepts-parameters-of-type-enum
//    //[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
//    //public class AuthorizeEnumAttribute : AuthorizeAttribute
//    //{
//    //    public AuthorizeEnumAttribute(params object[] roles)
//    //    {
//    //        if (roles.Any(r => r.GetType().BaseType != typeof(Enum)))
//    //            throw new ArgumentException("roles");

//    //        this.Roles = string.Join(",", roles.Select(r => Enum.GetName(r.GetType(), r)));
//    //    }
//    //}
//    //public enum Role
//    //{
//    //    Administrator = 1,
//    //    UserWithPrivileges = 2,
//    //    User = 3,
//    //}

//    //  [AuthorizeEnum(Role.Administrator, Role.UserWithPrivileges)]
//    //    public ActionResult ThePrivilegeZone()
//    //    {
//    //        return View();
//    //    }
//}