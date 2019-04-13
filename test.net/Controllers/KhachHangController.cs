using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using CuaHangDAL;

namespace test.net.Controllers
{
    public class KhachHangController : Controller
    {
        // GET: KhachHang
        public ActionResult Index(int? page )
        {
           
            int pagesize = 5;
            int pagenumber = (page ?? 1);
            IEnumerable<KhachHang> lstkh = KhachHangMager.paglistKH(pagenumber, pagesize);
            return View(lstkh);
        }
       [HttpGet]
        public ActionResult Edit(int id)
        {
           KhachHang kh = KhachHangMager.GetKhachHangByID(id);
            return View(kh);
        }
        [HttpPost]
        public ActionResult Edit(KhachHang kh)
        {
            kh.Status = "trong";
            KhachHangMager.uppdateKhachHang(kh);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            KhachHang kh = KhachHangMager.GetKhachHangByID(id);
            return View(kh);
        }
        [HttpPost]
        public ActionResult Delete (int id ,FormCollection f)
        {
            
            KhachHangMager.delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
           
            return View();
        }

        [HttpPost] // luu tt khach hang, tao tai khoan kh
        public ActionResult Create(KhachHang item)
        {
            KhachHangMager.insertKhachhang(item);

            return RedirectToAction("Index");
        }
    }
}