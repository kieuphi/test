using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CuaHangDAL;
using BLL;
namespace test.net.Controllers
{
    public class TaiKhoanController : Controller
    {
        // GET: TaiKhoan
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string TenTk, string MatKhau)
        {
            TaiKhoan tk = TaiKhoanMager.Login(TenTk, MatKhau);
            if (tk != null)
            {
                Session["taikhoan"] = tk;
                return RedirectToAction("Index", "SanPham");
            }

            else
            {
             
                return RedirectToAction("Index", "Home");
            }
            
           
        }
        public ActionResult Logout()
        {
            Session["taikhoan"] = null;
            return RedirectToAction("Index", "Home");
        }
        
        public ActionResult DangKy(NhanVien nv)
        {
            ViewBag.TenNV = nv.TenNv;
            ViewBag.MaNV = nv.MaNV;
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(TaiKhoan tk, FormCollection x)
        {
            string id = x["id"].ToString();
            int idnv = int.Parse(id);
         TaiKhoanMager.insert(tk);
            int idtk = tk.MaTK;
           
            NhanVienMager.saveTK(idnv, idtk);
            return RedirectToAction("Index", "NhanVien");
        }
        [HttpGet]
        public ActionResult DangkyKH(KhachHang item)
        {
            ViewBag.TenKH = item.TenKH;
            ViewBag.MaNV = item.MaKh;
            return View();
        }
        [HttpPost]
        public ActionResult DangKyKH(TaiKhoan tk, FormCollection x)
        {
            string id = x["id"].ToString();
            int idnv = int.Parse(id);
            TaiKhoanMager.insert(tk);
            int idtk = tk.MaTK;

            KhachHangMager.saveTK(idnv, idtk);
            return RedirectToAction("Index", "KhachHang");
        }
    }
}