using Microsoft.AspNetCore.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CookingWebsite.Controllers
{
    [EnableCors( "*" )]
    public class RecipeCategoryController : Controller
    {
        // GET: RecipeCategory
        public ActionResult Home()
        {
            return View();
        }
    }
}