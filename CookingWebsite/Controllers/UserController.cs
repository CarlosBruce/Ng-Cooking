using Microsoft.AspNetCore.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CookingWebsite.Controllers
{
    [EnableCors( "*" )]
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Home()
        {
            return View();
        }

        // GET: User
        public ActionResult List()
        {
            return View();
        }

        // GET: User
        public ActionResult Detail()
        {
            return View();
        }
    }
}
