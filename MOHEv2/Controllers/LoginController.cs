using MOHEv2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace MOHEv2.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Autherize(MOHEv2.Models.user usermodel)
        {
            using (mohedbEntities1 db = new mohedbEntities1())
            {

                var userd = db.users.Where(x => x.Branch_name == usermodel.Branch_name && x.password == usermodel.password).FirstOrDefault();

                if (userd == null)
                {
                    usermodel.loginerr = "اسم المستخدم او كلمة المرور غير صحيحة";
                    return View("Index", usermodel);
                }
                else
                {
                    Session["userid"] = userd.user_id;
                    Session["username"] = userd.Branch_name;
                    Session["branchcode"] = userd.Branch_code;
                    Session["userauth"] = userd.Privilege;
                    return RedirectToAction("Home", "Login");
                }
            }

        }


        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

        public ActionResult Notauth()
        {
            return View();
        }

        public ActionResult Notfound()
        {
            return View();
        }


        //public ActionResult Dashboord()
        //{
        //    return View();
        //}




    }
}