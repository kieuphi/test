using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CuaHangDAL;
using BLL;
using PagedList;


namespace test.net.Controllers
{
    public class NhanVienController : Controller
    {
        // GET: NhanVien
        public ActionResult Index()
        {
                 
            List<NhanVien> lst = NhanVienMager.getAll();
            return View(lst);
        }
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost] // luu thong tin nhan vien tao tai khoan nhan vien
        public ActionResult Create(NhanVien nv)
        {
            NhanVienMager.insert(nv);

            return RedirectToAction("dangky", "TaiKhoan",nv);
        }
      public ActionResult chucnang(int page = 1, int pagesize=1)
        {
            try
            {
                if (Ktdangnhap() == true)
                {
                    //ViewBag.sanpham = SanPhamMager.getAllSanPham();
                    var lstpage = SanPhamMager.phantrang(page, pagesize);
                    return View(lstpage);

                }
                else { return RedirectToAction("Index"); }
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
        // h kiem tra session tai khoan  nhan vien
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
        } 
        public ActionResult caidatthamso( FormCollection f)
        {
            int id = int.Parse(f["Masp"]);
            SanPham sp = SanPhamMager.GetSanPhamByID(id);
            int thamso = int.Parse( f["ThamSoN"]);
            sp.ThamSoN = thamso;
            SanPhamMager.uppdateSanPham(sp);

            return RedirectToAction("chucnang");
        }
        //[HttpPost]
        //public ActionResult chucnang(IEnumerable<SanPham> lstpage, int page = 1, int pagesize = 1)
        //{

        //}
    }
}

