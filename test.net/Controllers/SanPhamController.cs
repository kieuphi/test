using BLL;
using CuaHangDAL;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace test.net.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        public ActionResult Index()
        {
            List<DanHMuc> dm = DanhMucMager.getAllDanhMuc();
            ViewBag.danhmuc = new SelectList(dm, "MaDM", "TenDM");
            List<SanPham> lstsp = SanPhamMager.getAllSanPham();
            return View(lstsp);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Ktdangnhap() == true)
            {
                List<DanHMuc> dm = DanhMucMager.getAllDanhMuc();
                ViewBag.danhmuc = dm;
                SanPham sp = SanPhamMager.GetSanPhamByID(id);
                return View(sp);
            }
            else return RedirectToAction("Index");
        }

        [HttpPost] //  sua sp co luu ten nhan vien sua
        public ActionResult Edit(SanPham sp)
        {
            try
            {
                TaiKhoan tk = (TaiKhoan)Session["USER_SESSION"];
                int id = tk.MaTK;
                NhanVien nv = NhanVienMager.GetbyTK(id);
                sp.MaNVchinhsua = nv.MaNV;
                SanPhamMager.uppdateSanPham(sp);
                TempData["message"] = "sua thanh tong";
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Edit", sp.Masp);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (Ktdangnhap() == true)
            {
                SanPham sp = SanPhamMager.GetSanPhamByID(id);
                return View(sp);
            }
            else return RedirectToAction("Index");
        }

        [HttpPost]  // xoa san pham , luu tt nhan vien xoa
        public ActionResult Delete(int id, FormCollection f)
        {
            TaiKhoan tk = (TaiKhoan)Session["USER_SESSION"];
            int idtk = tk.MaTK;
            NhanVien nv = NhanVienMager.GetbyTK(idtk);
            var spxoa = SanPhamMager.delete(id);
            spxoa.MaNVchinhsua= nv.MaNV;
            spxoa.Ngaycapnhap = DateTime.Now;
            SanPhamMager.uppdateSanPham(spxoa);

            if (spxoa != null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Seacrh(int? danhmuc, string TenSp, decimal? GiaNhap)
        {
            List<DanHMuc> dm = DanhMucMager.getAllDanhMuc();
            ViewBag.danhmuc = new SelectList(dm, "MaDM", "TenDM");

            List<SanPham> lstsp = SanPhamMager.GetSPbyDM(danhmuc);
            List<SanPham> lstsp1 = SanPhamMager.GetSPbytensp(TenSp);
            lstsp.AddRange(lstsp1);

            List<SanPham> lstsp2 = SanPhamMager.GetSpByGiaNhap(GiaNhap);
            lstsp.AddRange(lstsp2);
            return View("Index", lstsp);
        }

        public bool Ktdangnhap()
        {
            TaiKhoan tk = (TaiKhoan)Session["USER_SESSION"];
            if (tk != null)
            {
                if (tk.Loaitk == "nhan vien")
                    return true;
                else return false;
            }
            else
                return false;
        } // h kiem tra session tai khoan  nhan vien
        [HttpGet]
        public ActionResult Create()
        {

            List<DanHMuc> dm = DanhMucMager.getAllDanhMuc();
            ViewBag.danhmuc = dm;
            return View();
        }
        [HttpPost]
        public ActionResult Create(SanPham item)
        {
            SanPham sp = SanPhamMager.insertSanPham(item);
            return RedirectToAction("Index");

        }
        //public ActionResult kthang()
        //{
        // List<SanPham>  
        //}
    }
}