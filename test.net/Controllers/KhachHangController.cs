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
        public ActionResult Index()
        {
            List<KhachHang> lstkh = KhachHangMager.GetAllKhachHang();
            return View(lstkh);
        }
       [HttpGet]
        public ActionResult Edit(int id)
        {
            string makh = id.ToString();
           KhachHang kh = KhachHangMager.GetKhachHangByID(makh);
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
        public ActionResult Delete(int id)
        {
            string makh = id.ToString();
            KhachHang kh = KhachHangMager.GetKhachHangByID(makh);
            return View(kh);
        }
        [HttpPost]
        public ActionResult Delete (int id ,FormCollection f)
        {
            
            KhachHangMager.DeleteKhachHang(id.ToString());
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

            return RedirectToAction("DangkyKH", "TaiKhoan", item);
        }
    }
}