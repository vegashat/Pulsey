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
        public UserRepository _userRepository;

        public GroupController()
        {
            _groupRepository = new GroupRepository();
            _userRepository  = new UserRepository();
        }

        public ActionResult Index(int id = 0)
        {
            var group = _groupRepository.Get(id);
            var groupUsers = _groupRepository.GetGroupUsers(id);
            var users = _userRepository.Get();

            var model = new GroupViewModel(group, groupUsers, users);

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

        public ActionResult AddGroupUser(GroupUser groupUser)
        {
            groupUser = _groupRepository.SaveGroupUser(groupUser);

            return RedirectToAction("GroupUsers", new { groupId = groupUser.GroupId });
        }

        public PartialViewResult GroupUsers(int groupId)
        {
            var groupUsers = _groupRepository.GetGroupUsers(groupId);

            return PartialView("_UserList", groupUsers);
        }


        public ActionResult TestGetLocation()
        {


            return View();

        }
    }
}
