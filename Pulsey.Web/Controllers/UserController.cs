using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pulsey.Core.Repositories;

namespace Pulsey.Web.Controllers
{
    public class UserController : Controller
    {
        UserRepository _userRepository;

        public UserController()
        {
            _userRepository = new UserRepository();
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult List()
        {
            var users = _userRepository.Get();

            return Json(users, JsonRequestBehavior.AllowGet);
        }
    }
}
