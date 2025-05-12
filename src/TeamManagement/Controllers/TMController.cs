using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamManagement.Models;
using System.IO;

namespace TeamManagement.Controllers
{
    
    public class TMController : Controller
    {
        Company_InformationEntities db = new Company_InformationEntities();

        #region TraneeEntry

        [HttpGet]
        public ActionResult TraneeEntry(int? TId)
        {
            TraneeInfo getId = db.TraneeInfoes.Where(x => x.TraneeId == TId).FirstOrDefault();
            if (getId == null)
            {
                getId = new TraneeInfo();
            }
            return View(getId);
        }
        [HttpPost]
        public ActionResult TraneeEntry(TraneeInfo T, HttpPostedFileBase Image)
        {

            var update = db.TraneeInfoes.Where(x => x.TraneeId == T.TraneeId).FirstOrDefault();
            if (update == null)
            {

                if (Image != null)
                {

                    string F = Path.GetFileNameWithoutExtension(Image.FileName);
                    string E = Path.GetExtension(Image.FileName);
                    string ImageName = F + DateTime.Now.ToString("yymmssff") + E;
                    T.Image = ImageName;
                    Image.SaveAs(Path.Combine(Server.MapPath("~/Appfile"), ImageName));
                }
                db.TraneeInfoes.Add(T);
                db.SaveChanges();
            }
            else
            {
                string updateImage = "";
                if (update.Image != null)
                {
                    updateImage = update.Image;
                    if (Image != null)
                    {
                        if (updateImage != null)
                        {
                            FileInfo fi = new FileInfo(Path.Combine(Server.MapPath("~/Appfile"), updateImage));
                            fi.Delete();

                        }

                        string F = Path.GetFileNameWithoutExtension(Image.FileName);
                        string E = Path.GetExtension(Image.FileName);
                        string ImageName = F + DateTime.Now.ToString("yymmssff") + E;

                        Image.SaveAs(Path.Combine(Server.MapPath("~/Appfile"), ImageName));
                        updateImage = ImageName;
                        update.Image = ImageName;
                    }

                }
                update.TraneeId = T.TraneeId;
                update.TraneeName = T.TraneeName;
                update.Phone = T.Phone;
                update.DistrictId = T.DistrictId;
                update.Upazilaid = T.Upazilaid;
                update.division_id = T.division_id;
                update.TraneeTypeId = T.TraneeTypeId;
                update.Email = T.Email;
                update.Image = updateImage;
                update.JoiningDate = T.JoiningDate;
                update.NID = T.NID;
                update.DOB = T.DOB;
                update.GenderId = T.GenderId;
                update.EStatusId = T.EStatusId;
                update.PStatusId = T.PStatusId;
                update.percentage = T.percentage;
                update.BloodGroup = T.BloodGroup;
               
                //update.UName = T.UName;
                //update.Password = T.Password;
                db.SaveChanges();
            }
            T = new TraneeInfo();
            return View(T);
        }
        public ActionResult delTraneeEntry(int? TId)
        {
            TraneeInfo getId = db.TraneeInfoes.Where(x => x.TraneeId == TId).FirstOrDefault();
            if (getId == null)
            {
                getId = new TraneeInfo();
            }
            string ImageName = getId.Image;
            db.TraneeInfoes.Remove(getId);
            db.SaveChanges();
            if (ImageName != null)
            {
                FileInfo fi = new FileInfo(Path.Combine(Server.MapPath("~/Appfile"), ImageName));
                fi.Delete();
            }
            return RedirectToAction("TraneeEntry");
        }

        public JsonResult GetDisAPI(int? divid)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var DisList = db.DistrictInfoes.Where(x => x.division_id == divid).ToList();
            return Json(DisList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetUpAPI(int? disId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var UpList = db.UpazilaInfoes.Where(x => x.DistrictId == disId).ToList();
            return Json(UpList, JsonRequestBehavior.AllowGet);
        }
        #endregion TraneeEntry

        #region TraneeTypeEntry
        [HttpGet]
        public ActionResult TraneeTypeEntry(int? TyId)
        {
            TTypeInfo getId = db.TTypeInfoes.Where(x => x.TraneeTypeId == TyId).FirstOrDefault();
            if (getId == null)
            {
                getId = new TTypeInfo();
            }
            return View(getId);
        }
        [HttpPost]
        public ActionResult TraneeTypeEntry(TTypeInfo TTp)
        {
            var update = db.TTypeInfoes.Where(x => x.TraneeTypeId == TTp.TraneeTypeId).FirstOrDefault();
            if (update == null)
            {
                db.TTypeInfoes.Add(TTp);
                db.SaveChanges();
                //return View(Typ);
            }
            else
            {
                update.TraneeTypeId = TTp.TraneeTypeId;
                update.TraneeTypeName = TTp.TraneeTypeName;
                db.SaveChanges();
            }
            TTp = new TTypeInfo();
            return View(TTp);
        }
        public ActionResult delTraneeTypeEntry(int? TyId)
        {
            TTypeInfo getId = db.TTypeInfoes.Where(x => x.TraneeTypeId == TyId).FirstOrDefault();
            if (getId == null)
            {
                getId = new TTypeInfo();
            }
            db.TTypeInfoes.Remove(getId);
            db.SaveChanges();
            return RedirectToAction("TraneeTypeEntry");
        }
        #endregion TraneeTypeEntry

        #region InstituteEntry
        [HttpGet]
        public ActionResult InstituteEntry(int? TnId)
        {
            InstituteInfo getId = db.InstituteInfoes.Where(x => x.InstituteId == TnId).FirstOrDefault();
            if (getId == null)
            {
                getId = new InstituteInfo();
            }
            return View(getId);
        }
        [HttpPost]
        public ActionResult InstituteEntry(InstituteInfo Ins)
        {
            var update = db.InstituteInfoes.Where(x => x.InstituteId == Ins.InstituteId).FirstOrDefault();
            if (update == null)
            {
                db.InstituteInfoes.Add(Ins);
                db.SaveChanges();
            }
            else
            {
                update.InstituteId = Ins.InstituteId;
                update.InsName = Ins.InsName;
                update.InsShortName = Ins.InsShortName;
                update.division_id = Ins.division_id;
                update.DistrictId = Ins.DistrictId;
                update.Upazilaid = Ins.Upazilaid;
                update.InsTypeId = Ins.InsTypeId;
                update.StatusId = Ins.StatusId;
                update.GrantedMemberId = Ins.GrantedMemberId;
                db.SaveChanges();
            }
            Ins = new InstituteInfo();
            return View(Ins);

        }
        public ActionResult delInstituteEntry(int? TnId)
        {
            InstituteInfo getId = db.InstituteInfoes.Where(x => x.InstituteId == TnId).FirstOrDefault();
            if (getId == null)
            {
                getId = new InstituteInfo();
            }
            db.InstituteInfoes.Remove(getId);
            db.SaveChanges();
            return RedirectToAction("InstituteEntry");
        }
        #endregion InstituteEntry

        #region InsTypeEntry
        [HttpGet]
        public ActionResult InsTypeEntry(int? InTId)
        {
            InsTypeInfo getId = db.InsTypeInfoes.Where(x => x.InsTypeId == InTId).FirstOrDefault();
            if (getId == null)
            {
                getId = new InsTypeInfo();
            }
            return View(getId);
        }
        [HttpPost]
        public ActionResult InsTypeEntry(InsTypeInfo TnTy)
        {
            var update = db.InsTypeInfoes.Where(x => x.InsTypeId == TnTy.InsTypeId).FirstOrDefault();
            if (update == null)
            {
                db.InsTypeInfoes.Add(TnTy);
                db.SaveChanges();   
            }
            else
            {
                update.InsTypeId = TnTy.InsTypeId;
                update.InsType = TnTy.InsType;
                db.SaveChanges();
            }
            TnTy = new InsTypeInfo();
            return View(TnTy);
        }
        public ActionResult delInsTypeEntry(int? InTId)
        {
            InsTypeInfo getId = db.InsTypeInfoes.Where(x => x.InsTypeId == InTId).FirstOrDefault();
            if (getId == null)
            {
                getId = new InsTypeInfo();
            }
            db.InsTypeInfoes.Remove(getId);
            db.SaveChanges();
            return RedirectToAction("InsTypeEntry");
        }
        #endregion InsTypeEntry

        #region BranchEntry
        [HttpGet]
        public ActionResult BranchEntry(int? BId)
        {
            BranchInfo getId = db.BranchInfoes.Where(x => x.BranchId == BId).FirstOrDefault();
            if (getId == null)
            {
                getId = new BranchInfo();
            }
            return View(getId);
        }
        [HttpPost]
        public ActionResult BranchEntry(BranchInfo Ban)
        {
            var update = db.BranchInfoes.Where(x => x.BranchId == Ban.BranchId).FirstOrDefault();
            if (update == null)
            {
                db.BranchInfoes.Add(Ban);
                db.SaveChanges();
            }
            else
            {
                update.BranchId = Ban.BranchId;
                update.BranchName = Ban.BranchName;
                db.SaveChanges();
            }
            Ban = new BranchInfo();
            return View(Ban);
        }
        public ActionResult delBranchEntry(int? BId)
        {
            BranchInfo getId = db.BranchInfoes.Where(x => x.BranchId == BId).FirstOrDefault();
            if (getId == null)
            {
                getId = new BranchInfo();
            }
            db.BranchInfoes.Remove(getId);
            db.SaveChanges();
            return RedirectToAction("BranchEntry");
        }
        #endregion BranchEntry
    
        #region YearEntry
        [HttpGet]
        public ActionResult YearEntry(int? YId)
        {
            Yearinfo getId = db.Yearinfoes.Where(x => x.YearId == YId).FirstOrDefault();
            if (getId == null)
            {
                getId = new Yearinfo();
            }
            return View(getId);
        }
        [HttpPost]
        public ActionResult YearEntry(Yearinfo Y)
        {
            var update = db.Yearinfoes.Where(x => x.YearId == Y.YearId).FirstOrDefault();
            if (update == null)
            {
                db.Yearinfoes.Add(Y);
                db.SaveChanges();
            }
            else
            {
                update.YearId = Y.YearId;
                update.Year = Y.Year;
                db.SaveChanges();
            }
            return RedirectToAction("YearEntry");
        }
        public ActionResult delYearEntry(int? YId)
        {
            Yearinfo getId = db.Yearinfoes.Where(x => x.YearId == YId).FirstOrDefault();
            if (getId == null)
            {
                getId = new Yearinfo();
            }
            db.Yearinfoes.Remove(getId);
            db.SaveChanges();
            return RedirectToAction("YearEntry");
        }
        #endregion YearEntry

        #region ClassEntry
        [HttpGet]
        public ActionResult ClassEntry(int? CId)
        {
            ClassInfo getId = db.ClassInfoes.Where(x => x.ClassId == CId).FirstOrDefault();
            if (getId == null)
            {
                getId = new ClassInfo();
            }
            return View(getId);
        }
        [HttpPost]
        public ActionResult ClassEntry(ClassInfo C)
        {
            var update = db.ClassInfoes.Where(x => x.ClassId == C.ClassId).FirstOrDefault();
            if (update == null)
            {
                db.ClassInfoes.Add(C);
                db.SaveChanges();
            }
            else
            {
                update.ClassId = C.ClassId;
                update.ClassName = C.ClassName;
                db.SaveChanges();
            }
            C = new ClassInfo();
            return View(C);
        }
        public ActionResult delClassEntry(int? CId)
        {
            ClassInfo getId = db.ClassInfoes.Where(x => x.ClassId == CId).FirstOrDefault();
            if (getId == null)
            {
                getId = new ClassInfo();
            }
            db.ClassInfoes.Remove(getId);
            db.SaveChanges();
            return RedirectToAction("ClassEntry");
        }
        #endregion ClassEntry

        #region PayMethodEntry
        [HttpGet]
        public ActionResult PayMethodEntry(int? PaId)
        {
            PaymentmethodInfo getId = db.PaymentmethodInfoes.Where(x => x.PaymentMethodId == PaId).FirstOrDefault();
            if (getId == null)
            {
                getId = new PaymentmethodInfo();
            }
            return View(getId);
        }
        [HttpPost]
        public ActionResult PayMethodEntry(PaymentmethodInfo Pay)
        {
            var update = db.PaymentmethodInfoes.Where(x => x.PaymentMethodId == Pay.PaymentMethodId).FirstOrDefault();
            if (update == null)
            {
                db.PaymentmethodInfoes.Add(Pay);
                db.SaveChanges();
            }
            else
            {
                update.PaymentMethodId = Pay.PaymentMethodId;
                update.PayMethodName = Pay.PayMethodName;
                db.SaveChanges();
            }
            Pay = new PaymentmethodInfo();
              return View(Pay);
        }
        public ActionResult delPayMethodEntry(int? PaId)
        {
            PaymentmethodInfo getId = db.PaymentmethodInfoes.Where(x => x.PaymentMethodId == PaId).FirstOrDefault();
            if (getId == null)
            {
                getId = new PaymentmethodInfo();
            }
            db.PaymentmethodInfoes.Remove(getId);
            db.SaveChanges();
            return RedirectToAction("PayMethodEntry");
        }
        #endregion PayMethodEntry

        #region FeeEntry
        [HttpGet]
        public ActionResult FeeEntry(int? FId)
        {
            FeeEntryInfo getId = db.FeeEntryInfoes.Where(x => x.FeeEntryId == FId).FirstOrDefault();
            if (getId == null)
            {
                getId = new FeeEntryInfo();
            }
            return View(getId);
        }
        [HttpPost]
        public ActionResult FeeEntry(FeeEntryInfo FE)
        {
            var update = db.FeeEntryInfoes.Where(x => x.FeeEntryId == FE.FeeEntryId).FirstOrDefault();
            if (update == null)
            {
                FE.PaymentStatusId = 0;
                FE.ApprovedId = 0;
                db.FeeEntryInfoes.Add(FE);
                db.SaveChanges();
            }
            else
            {
                update.FeeEntryId = FE.FeeEntryId;
                update.InstituteId = FE.InstituteId;
                update.BranchId = FE.BranchId;
                update.YearId = FE.YearId;
                update.MonthId = FE.MonthId;
                update.ClassId = FE.ClassId;
                update.TotalStudent = FE.TotalStudent;
                update.PayDate = FE.PayDate;
                update.FeeperStudent = FE.FeeperStudent;
                update.TotalCost = FE.TotalCost;
                update.GrantedMemberId = FE.GrantedMemberId;
                db.SaveChanges();
            }
            FE = new FeeEntryInfo();
            return View(FE);
        }
        public ActionResult delFeeEntry(int? FId)
        {
            FeeEntryInfo getId = db.FeeEntryInfoes.Where(x => x.FeeEntryId == FId).FirstOrDefault();
            if (getId == null)
            {
                getId = new FeeEntryInfo();
            }
            db.FeeEntryInfoes.Remove(getId);
            db.SaveChanges();
            return RedirectToAction("FeeEntry");
        }
        #endregion FeeEntry

        #region PayAapprovalEntry
        [HttpGet]
        public ActionResult PayAapprovalEntry()
        {
            return View();
        }
        //public JsonResult GetPayAapprovalAPI(int? TnId, int? TId, int? BId, int? YId, int? sMId, int? eMId)
        //{
        //    db.Configuration.ProxyCreationEnabled = false;

        //    for (var MonthId = sMId; MonthId <= eMId; MonthId++)
        //    {
        //        db.Configuration.ProxyCreationEnabled = false;
        //        var PayAprovalList = db.FeeEntryInfoes.Where(x => x.InstituteId == TnId && x.GrantedMemberId == TId && x.BranchId == BId && x.YearId == YId && x.MonthId == sMId && x.MonthId == eMId).ToList();
        //        List<PayAprovalListModel> PList = new List<PayAprovalListModel>();

        //        foreach (var item in PayAprovalList)
        //        {
        //            PayAprovalListModel p = new PayAprovalListModel();
        //            p.Institute = db.InstituteInfoes.Where(x => x.InstituteId == item.InstituteId).Select(x => x.InsName).FirstOrDefault();
        //            p.Branch = db.BranchInfoes.Where(x => x.BranchId == item.BranchId).Select(x => x.BranchName).FirstOrDefault();
        //            p.Year = db.Yearinfoes.Where(x => x.YearId == item.YearId).Select(x => x.Year).FirstOrDefault();
        //            p.Month = db.MonthInfoes.Where(x => x.MonthId == item.MonthId).Select(x => x.MonthName).FirstOrDefault();
        //            p.Class = db.ClassInfoes.Where(x => x.ClassId == item.ClassId).Select(x => x.ClassName).FirstOrDefault();
        //            //p.TotalStudent = item.TotalStudent;

        //            PList.Add(p);

        //            //p.GrantedMember = db.TraneeInfoes.Where(x => x.TraneeId == item.GrantedMemberId).Select(x => x.TraneeName).FirstOrDefault();   
        //        }
        //    }
        //    return Json(PList, JsonRequestBehavior.AllowGet);
            
        // }
        #endregion PayAapprovalEntry

                #region MemberSearch
        [HttpGet]
        public ActionResult MemberSearch()
        {
            return View();
        }
        public JsonResult GetMemberAPI(int? TyId, int? divid, int? DisId, int? Upid, int? EId, int? PId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var MemberList = db.TraneeInfoes.Where(x => x.TraneeTypeId == TyId && x.division_id == divid && x.DistrictId == DisId && x.Upazilaid == Upid && x.EStatusId == EId && x.PStatusId == PId).ToList();
            List<MemberSearchModel> MList = new List<MemberSearchModel>();
            foreach (var item in MemberList)
            {
                MemberSearchModel m = new MemberSearchModel();
                m.TraneeName = item.TraneeName;
                m.Gender = db.GenderInfoes.Where(x => x.GenderId == item.GenderId).Select(x => x.GenName).FirstOrDefault();
                m.Phone = item.Phone;
                m.Email = item.Email;
                m.JoiningDate = item.JoiningDate;
                m.Image = item.Image;
                m.DOB = item.DOB;
                m.percentage = Convert.ToString(item.percentage);
                MList.Add(m);
            }
            return Json(MList, JsonRequestBehavior.AllowGet);
        }
        #endregion MemberSearch

        #region InstituteSearch
        [HttpGet]
        public ActionResult InstituteSearch()
        {
            return View();
        }
        public JsonResult GetInstituteAPI(int? TnId, int? divid, int? DisId, int? Upid,int? SId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var InstituteList = db.InstituteInfoes.Where(x => x.InsTypeId == TnId && x.division_id == divid && x.DistrictId == DisId && x.Upazilaid == Upid && x.StatusId== SId).ToList();
            List<InstituteSearchModel> IList = new List<InstituteSearchModel>();
            foreach (var item in InstituteList)
            {
                InstituteSearchModel i = new InstituteSearchModel();
                i.InsName = item.InsName;
                i.InsShortName = item.InsShortName;
                i.Status = db.StatusInfoes.Where(x => x.StatusId == item.StatusId).Select(x => x.Status).FirstOrDefault();
                i.GrantedMember = db.TraneeInfoes.Where(x => x.TraneeId == item.GrantedMemberId).Select(x => x.TraneeName).FirstOrDefault();

                IList.Add(i);
            }
            return Json(IList, JsonRequestBehavior.AllowGet);
        }
        #endregion InstituteSearch

    }
}
