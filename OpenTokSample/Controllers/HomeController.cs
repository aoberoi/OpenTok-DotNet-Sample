using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpenTok;

namespace OpenTokSample.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            NameValueCollection appSettings = ConfigurationManager.AppSettings;
            ViewBag.APIKey = appSettings["opentok_key"];

            OpenTokSDK opentok = new OpenTokSDK();

            string sessionId = opentok.CreateSession(Request.ServerVariables["REMOTE_ADDR"]);

            Dictionary<string, object> tokenOptions = new Dictionary<string, object>();
            tokenOptions.Add(TokenPropertyConstants.ROLE, RoleConstants.MODERATOR);
            ViewBag.Token = opentok.GenerateToken(sessionId, tokenOptions);
            return View();
        }

    }
}