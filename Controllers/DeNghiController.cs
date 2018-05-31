using QLMT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLMT.Controllers
{
    public class DeNghiController : Controller
    {
        // GET: DeNghiCho
        public ActionResult Index()
        {
            DeNghiList dnList = new DeNghiList();
            List<DeNghi> obj = dnList.getDN(0);
            return View(obj);
        }
        //get đề nghị đã duyệt
        public ActionResult DaDuyet()
        {
            DeNghiList deNghiList = new DeNghiList();
            List<DeNghi> obj = deNghiList.getDN(1);
            return View(obj);
        }

        //Tao moi de nghi
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost] //update thong tin len may chu
        public ActionResult Create(DeNghi deNghi)
        {
            if (ModelState.IsValid)
            {
                DeNghiList dnList = new DeNghiList();
                dnList.AddDeNghi(deNghi);
                return RedirectToAction("Index");
            }
            return View();
        }
        //Đề nghị chờ duyệt
        

        //sua de nghi
        public ActionResult Edit(int id)
        {
            DeNghiList dnList = new DeNghiList();
            List<DeNghi> obj = dnList.getDNMa(id);
            return View(obj.FirstOrDefault()); //lấy id đầu tiên trong danh sách

        }
        [HttpPost]
        public ActionResult Edit(DeNghi maDN)
        {
            DeNghiList dnList = new DeNghiList();
            dnList.EditDN(maDN);
            return RedirectToAction("Index");
        }
        //xoa
        public ActionResult Delete(int MaDN)
        {
            DeNghiList dnList = new DeNghiList();
            List<DeNghi> obj = dnList.getDNMa(MaDN);
            return View(obj.FirstOrDefault()); //lấy idmay đầu tiên trong danh sách máy
        }
        [HttpPost]
        public ActionResult Delete(DeNghi maDN)
        {
            DeNghiList dnList = new DeNghiList();
            dnList.DeleteDN(maDN);
            return RedirectToAction("Index");
        }
        //chi tiet may
        public ActionResult Detail(int maDN)
        {
            DeNghiList dnList = new DeNghiList();
            List<DeNghi> obj = dnList.getDNMa(maDN);
            return View(obj.FirstOrDefault());
        }
    }
}