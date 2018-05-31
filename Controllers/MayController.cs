using QLMT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLMT.Controllers
{
    public class MayController : Controller
    {
        // GET: May 
        public ActionResult May()
        {
            MayList mayList = new MayList();
            List<May> obj = mayList.getMay(string.Empty);
            return View(obj);
        }
        //Lay may trong trang thai chua su dung
        public ActionResult chuasudung()
        {
            MayList mayList = new MayList();
            List<May> obj = mayList.getTrangThai(0);
            return View(obj);
        }
        //Lay may trong trang thai dang su dung
        public ActionResult dangsudung()
        {
            MayList mayList = new MayList();
            List<May> obj = mayList.getTrangThai(1);
            return View(obj);
        }
        //viet phuong thuc tạo
        public ActionResult themmaytinh()
        {
            return View();
        }
        [HttpPost] //update thong tin len may chu
        public ActionResult themmaytinh (May may)
        {
            if(ModelState.IsValid)
            {
                MayList mayList = new MayList();
                mayList.AddMay(may);
                return RedirectToAction("May");
            }
            return View();
        }

        public ActionResult chinhsuamaytinh(string idmay="")
        {
            MayList mayList = new MayList();
            List<May> obj = mayList.getMay(idmay);
            return View(obj.FirstOrDefault()); //lấy idmay đầu tiên trong danh sách máy

        }
        [HttpPost]
        public ActionResult chinhsuamaytinh(May may)
        {
            MayList mayList = new MayList();
            mayList.UpdateMay(may);
            return RedirectToAction("May");
        }
        //xoa
        public ActionResult xoamaytinh(string idmay ="")
        {
            MayList mayList = new MayList();
            List<May> obj = mayList.getMay(idmay);
            return View(obj.FirstOrDefault()); //lấy idmay đầu tiên trong danh sách máy
        }
        [HttpPost]
        public ActionResult xoamaytinh(May may)
        {
            MayList mayList = new MayList();
            mayList.DeleteMay(may);
            return RedirectToAction("May");
        }
        //chi tiet may
        public ActionResult Detail(string idmay="")
        {
            MayList mayList = new MayList();
            List<May> obj = mayList.getMay(idmay);
            return View(obj.FirstOrDefault());
        }
    }
}