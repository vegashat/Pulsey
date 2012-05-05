using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pulsey.Core.Models;

namespace Pulsey.Web.Controllers
{
    public class GroupController : Controller
    {
        //
        // GET: /Group/

        public ActionResult Index(int id)
        {


            return View();
        }

        public JsonResult Save(Group group)
        {
            return Json(null);
        }



    }
}
