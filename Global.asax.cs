using DeWee.Models;
using SubSonic.Schema;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace DeWee
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        public static UserViewModel CUser
        {
            get
            {
                if (HttpContext.Current?.User?.Identity?.IsAuthenticated ?? false)
                {
                    // Retrieve user from session if exists
                    //if (HttpContext.Current.Session["CUser"] is UserViewModel cachedUser)
                    //{
                    //    return cachedUser;
                    //}
                    if (HttpContext.Current.Session["CUser"] != null)
                    {
                        return (UserViewModel)HttpContext.Current.Session["CUser"];
                    }
                    else
                    {
                        // Fetch user from database if not in session
                        var user = new UserViewModel();
                        StoredProcedure sp = new StoredProcedure("SP_GetCurrentLogin");
                        sp.Command.AddParameter("@UN", HttpContext.Current.User.Identity.Name, DbType.String);
                        DataTable dt = sp.ExecuteDataSet().Tables[0];

                        if (dt.Rows.Count > 0)
                        {
                            DataRow dr = dt.Rows[0]; // Get first row
                            user.UserId = dr["UserId"].ToString();
                            user.Name = dr["Name"].ToString();
                            user.Email = dr["Email"].ToString();
                            user.UserName = dr["UserName"].ToString();
                            user.PhoneNumber = dr["PhoneNumber"].ToString();
                            user.LockoutEnabled = dr["LockoutEnabled"].ToString();
                            user.RoleId = Convert.ToInt32(dr["RoleId"]);
                            user.RoleName = dr["RoleName"].ToString();
                            user.Location = dr["Location"].ToString();
                        }

                        // Cache user details in session
                        HttpContext.Current.Session["CUser"] = user;
                        return user;
                    }
                }
                else
                {
                    RouteCollection routes = new RouteCollection();
                    routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
                    routes.MapRoute(
                        name: "Default",
                        url: "{controller}/{action}/{id}",
                        defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
                    );
                    return null;
                    // Redirect to login page if not authenticated
                    //HttpContext.Current.Response.Redirect("~/Account/Login", false);
                    //HttpContext.Current.ApplicationInstance.CompleteRequest();
                    //return null;
                }
            }
        }

    }
}
