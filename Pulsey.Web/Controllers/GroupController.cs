using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pulsey.Core.Models;
using Pulsey.Core.Repositories;
using Pulsey.Web.Viewmodels;

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


        public ActionResult Index(int id = 0)
        {
            var group = _groupRepository.Get(id);
            var groupUsers = _groupRepository.GetGroupUsers(id);

            var model = new GroupViewModel(group, groupUsers);

            return View(model);
        }

        public JsonResult Save(Group group)
        {
            return Json(null);
        }

        public JsonResult GetGroupUsers(int groupId)
        {
            var groupUsers = _groupRepository.GetGroupUsers(groupId);

            return Json(groupUsers);
        }

    }
}
