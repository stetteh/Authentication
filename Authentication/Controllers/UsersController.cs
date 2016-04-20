using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Authentication.Models;

namespace Authentication.Controllers
{
    public class UsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Users
        public ActionResult Info()
        {
            var model = db.Users.Select(lg => new
            {
                CurrentUser = lg.UserName,
                EmailAddress = lg.Email,
                First_Name = lg.FirstName,
                DOB = lg.DateOfBirth
            });
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            var model = db.Users.Select(lg => new
            {
                CurrentUser = lg.UserName,
                EmailAddress = lg.Email,
                First_Name = lg.FirstName,
                DOB = lg.DateOfBirth
                
            });
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}