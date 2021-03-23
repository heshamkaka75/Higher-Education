using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MOHEv2.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace MOHEv2.Controllers
{
    public class ArabController : Controller
    {
        private mohedbEntities1 db = new mohedbEntities1();
        // GET: Sudani
        public ActionResult Create()
        {
            var count = db.Transactions.Count();
            string str = "36" + Session["branchcode"] + count + "";
            ViewBag.stid = str;
            ViewBag.appid = "FBSD";
            ViewBag.billerid = "108";
            ViewBag.sercod = "803";
            ViewBag.serreqtyp = 2;
            ViewBag.curr = "SDG";


            return View();

        }


        [HttpPost]

        public async Task<ActionResult> Create(ArabViewModel create)
        {
            using (var client = new HttpClient())
            {
                var serilizer = new System.Web.Script.Serialization.JavaScriptSerializer();

                string serilizedObject = serilizer.Serialize(create);

                client.BaseAddress = new Uri("http://10.138.1.205/hrp/Login/");

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");

                var postjob = await client.PostAsJsonAsync<ArabViewModel>("arab/create", create);

                if (postjob.IsSuccessStatusCode)
                {
                    var res = await postjob.Content.ReadAsAsync<ResponseViewModel>();

                    if (res.responseCode == 500 && res.additionalData.ErrorCode == "0")
                    {

                    var rs_stid = res.sourceTransactionId.ToString();
                    var rs_cbr = res.customerBillerRef; 
                    var rs_sn = res.additionalData.stName;
                    var rs_amo = Convert.ToInt32(res.transactionPaidAmount);
                    var rs_fk = res.additionalData.FormKind;
                    int fff = Int32.Parse(rs_fk);
                    var rs_act = Int32.Parse(res.additionalData.Student_Acad_Type);
                    var rs_crt = Int32.Parse(res.serviceCode);
                    var dt = DateTime.Now;
                    var e15 = res.additionalData.E15;
                    var usr = Session["userid"];
                    int us = Convert.ToInt32(usr);
                    var stno = res.additionalData.StNo;
                    var formn = res.additionalData.FormNo;

                    Transaction tr = new Transaction
                    {
                        Source_trans_id = rs_stid,
                        Student_num = rs_cbr,
                        Student_name = rs_sn,
                        Amount = rs_amo,
                        From_kind_code = fff,
                        academy_type_code = rs_act,
                        Certificate_type_code = rs_crt,
                        Trans_date = dt,
                        e15 = e15,
                        user_code = us,
                        StNo = stno,
                        FormNo = formn
                        
                    };
                    db.Transactions.Add(tr);
                    db.SaveChanges();
                    TempData["respons"] = "تمت العمليه بنجاح.";
                    }
                    #region
                    else if (res.responseCode == 106) {
                        TempData["respons"] = "External System Validation Error"; }
                    else if (res.responseCode == 130) {
                        TempData["respons"] = "Invalid Type"; }
                    else if (res.responseCode == 152) {
                        TempData["respons"] = "Mandatory field is cannotbe NULL"; }
                    else if (res.responseCode == 156) {
                        TempData["respons"] = "Pattern = mismatch the pattern."; }
                    else if (res.responseCode == 160) {
                        TempData["respons"] = "Digits has wrong in fraction or integer"; }
                    else if (res.responseCode == 168) {
                        TempData["respons"] = "Min less than minimum"; }
                    else if (res.responseCode == 172) {
                        TempData["respons"] = "Max=more than maximumvalue "; }
                    else if (res.responseCode == 201) {
                        TempData["respons"] = "Internal Authorization Error"; }
                    else if (res.responseCode == 202) {
                        TempData["respons"] = "External Authorization Error"; }
                    else if (res.responseCode == 301) {
                        TempData["respons"] = "Internal Authentication Error"; }
                    else if (res.responseCode == 302) {
                        TempData["respons"] = "External Authentication Error"; }
                    else if (res.responseCode == 400) {
                        TempData["respons"] = "System Error"; }
                    else if (res.responseCode == 401) {
                        TempData["respons"] = "Internal System Error"; }
                    else if (res.responseCode == 402) {
                        TempData["respons"] = "External System Declined"; }
                    else if (res.responseCode == 403) {
                        TempData["respons"] = "External System Timeout"; }
                    else if (res.responseCode == 404) {
                        TempData["respons"] = "External System Error"; }
                    else if (res.responseCode == 512) {
                        TempData["respons"] = "Failed business validation "; }
                    else if (res.responseCode == 520) {
                        TempData["respons"] = "Failed Pre Check"; }
                    else if (res.responseCode == 524) {
                        TempData["respons"] = "Failed Provisioning"; }
                    else if (res.responseCode == 628) {
                        TempData["respons"] = "Transaction Exception DB is down"; }
                    else if (res.responseCode == 532) {
                        TempData["respons"] = "Biller Exception Biller not found"; }
                    else if (res.responseCode == 536) {
                        TempData["respons"] = "Service Not Found (Biller Service not found)"; }
                    else if (res.responseCode == 538) {
                        TempData["respons"] = "External Application does not exist ( External application with specified application id does not exist)"; }
                    else if (res.responseCode == 540) {
                        TempData["respons"] = "Failed Loading Fields (a problem occurred during loading validation vields)"; }
                    else if (res.responseCode == 544) {
                        TempData["respons"] = "Failed Validation Process (validation process has failed)"; }
                    else if (res.responseCode == 546) {
                        TempData["respons"] = "Invalid Validation Arguments Types "; }
                    else if (res.responseCode == 552) {
                        TempData["respons"] = "TransactionTotalAmount not equals sum of transaction Fee and transactionPaidAmount."; }
                    else if (res.responseCode == 559) {
                        TempData["respons"] = "Transaction under inquiry is not found"; }
                    else if (res.responseCode == 556) {
                        TempData["respons"] = "Transaction Status Check Failed (Probably identifier is not unique)"; }
                    else if (res.responseCode == 998) {
                        TempData["respons"] = "Connection error (Connection error occurred while connecting with biller)"; }
                    else if (res.responseCode == 999) {
                        TempData["respons"] = "Connection time out (Connection time out occurred with biller)"; }
                    else if (res.responseCode == 557) {
                        TempData["respons"] = "Aggregrator With This Prefix is not found"; }
                    else if (res.additionalData.ErrorCode == "1") {
                        TempData["respons"] = "Already paid "; }
                    else if (res.additionalData.ErrorCode == "2") {
                        TempData["respons"] = "Invalid student Record "; }
                    else if (res.additionalData.ErrorCode == "3") {
                        TempData["respons"] = "NOT valid request System error"; }
                    else {
                        TempData["respons"] = "الرجاء مراجعة اداره التقنية !";
                    }
                    #endregion


                    return RedirectToAction("Errorco", "Arab");
                }

                else
                {

                    //var res = await postjob.Content.ReadAsAsync<ResponseViewModel>();

                    TempData["respons"] = "حدث خطا! ، الرجاء مراجعة اداره التقنيه.";
                    return RedirectToAction("Errorco", "Arab");
                }
            }
        }

        public ActionResult Errorco()
        {

            var show_mes = TempData["respons"];
            return View(); 
        }
    }
}

