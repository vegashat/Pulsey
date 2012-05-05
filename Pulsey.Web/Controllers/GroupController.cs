using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pulsey.Core.Models;
using Pulsey.Core.Repositories;

namespace Pulsey.Web.Controllers
{
    [Authorize]
    public class GroupController : Controller
    {
        public GroupRepository _groupRepository;

        public GroupController()
        {
            _groupRepository = new GroupRepository();
        }


        public ActionResult Index(int id)
        {
            Group g = new Group() { Name = "Test Group" };

            _groupRepository.Save(g);

            var group = _groupRepository.Get(id);

            return View();
        }

        public JsonResult Save(Group group)
        {
            return Json(null);
        }



    }
}
