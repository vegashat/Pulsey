using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pulsey.Core.Repositories;
using Pulsey.Web.Models;

namespace Pulsey.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View("CurrentLocation");
        }

        public JsonResult SaveLocation(Location location)
        {
            var response = new PulseyResponse();
            
            try
            {
                
                using (PulseyContext context = new PulseyContext())
                {

                    // Save(User, location.lat, location.lon);
                    // context.Save(location);
                }

                response.Success = true;

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Error Saving Pick /r/n" + ex.Message;
            }
            return Json(response);
        }

    }
}
