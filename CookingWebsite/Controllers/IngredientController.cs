using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CookingWebsite.Controllers
{
    public class IngredientController : Controller
    {
        // GET: Ingredient
        public ActionResult Home()
        {
            return View();
        }

        // GET: Ingredient
        public ActionResult List()
        {
            return View();
        }
    }
}