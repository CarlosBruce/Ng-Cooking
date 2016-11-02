using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CookingWebsite.Controllers
{
    public class RecipeController : Controller
    {
        // GET: Recipe
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult List()
        {
            return View();
        }

        public ActionResult Detail()
        {
            return View();
        }

        public ActionResult New()
        {
            return View();
        }
    }
}