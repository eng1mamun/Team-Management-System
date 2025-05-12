using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TeamManagement.Models;

namespace TeamManagement.Controllers
{
    public class URController : Controller
    {
        Company_InformationEntities db = new Company_InformationEntities();

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }
        //public ActionResult LogIn(string UName,string Password)
        //{
        //    var Valid = db.TraneeInfoes.Where(x => x.UName == UName && x.Password == Password).FirstOrDefault();
        //        if(Valid!= null)
        //    {
        //        FormsAuthentication.SetAuthCookie(UName, false);
        //        return  RedirectToAction("TraneeEntry", "TM");
        //    }
        //    return View();
        }
        
    }
