﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Pulsey.Core.Models;
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

        public ActionResult UserProfile()
        {

            var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            var ticket = FormsAuthentication.Decrypt(cookie.Value);
            var email = ticket.UserData.Split(';')[2];
            var userObj = (new Pulsey.Core.Repositories.UserRepository().GetUserByEmail(email));
            return View(userObj);
        }

        [HttpPost]
        public ActionResult UserProfile(User user)
        {
            var repo = new UserRepository();
            repo.InsertUserProfile(user);
            return View();
        }
    }
}
