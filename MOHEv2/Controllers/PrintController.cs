using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MOHEv2.Models;

namespace MOHEv2.Controllers
{
    public class PrintController : Controller
    {
        private mohedbEntities1 db = new mohedbEntities1();

        //
        // GET: /Print/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Transaction trans)
        {
            var st_num = trans.Student_num;


            var db_st_nam = (from s in db.Transactions where s.Student_num == st_num select s.Student_name).FirstOrDefault();
            var db_st_num = (from s in db.Transactions where s.Student_num == st_num select s.Student_num).FirstOrDefault();

            var db_stno = (from s in db.Transactions where s.Student_num == st_num select s.StNo).FirstOrDefault();
            var db_st_amo = (from s in db.Transactions where s.Student_num == st_num select s.Amount).FirstOrDefault();
            var db_st_e15 = (from s in db.Transactions where s.Student_num == st_num select s.e15).FirstOrDefault();
            var db_st_formn = (from s in db.Transactions where s.Student_num == st_num select s.FormNo).FirstOrDefault();

            var dbfkid = (from s in db.Transactions where s.Student_num == st_num select s.From_kind_code).FirstOrDefault();
            var db_st_fk = (from s in db.Form_kind where s.From_kind_code == dbfkid select s.From_kind_name).FirstOrDefault();


            var dbactid = (from s in db.Transactions where s.Student_num == st_num select s.academy_type_code).FirstOrDefault();
            var db_st_acty = (from s in db.Academy_type where s.academy_type_code == dbactid select s.academy_type_name).FirstOrDefault();
            var db_st_date = (from s in db.Transactions where s.Student_num == st_num select s.Trans_date).FirstOrDefault();

            TempData["nam"] = db_st_nam;
            TempData["num"] = db_st_num;
            TempData["stn"] = db_stno;
            TempData["amo"] = db_st_amo;
            TempData["fk"] = db_st_fk;
            TempData["acty"] = db_st_acty;
            string x = db_st_date.ToString();
            string y = x.Substring(0, 10);
            TempData["stdat"] = y;
            TempData["e15"] = db_st_e15;
            TempData["formno"] = db_st_formn;

            return RedirectToAction("receipt", "Print");
        }

        public ActionResult Receipt()
        {
            var rna = TempData["nam"];
            var rnu = TempData["num"];
            var rsn = TempData["stn"];
            var ramo = TempData["amo"];
            var rfk = TempData["fk"];
            var ract = TempData["acty"];
            var rdt = TempData["stdat"];
            var e_15 = TempData["e15"];
            var formnub = TempData["formno"];

            return View();
        }
	}
}